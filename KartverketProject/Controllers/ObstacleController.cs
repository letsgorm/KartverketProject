using KartverketProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;

// Site logic for submission

namespace KartverketProject.Controllers
{
    [Authorize(Policy = "AuthenticatedAll")] // Kun for bruker, reviewer, admin
    public class ObstacleController : Controller
    {
        // registrer service som gir loos kobling
        private readonly ObstacleService _service;

        public ObstacleController(ObstacleService service)
        {
            _service = service;
        }

        // GET: /Obstacle/DataForm
        // blir kalt etter at vi trykker på "Register Obstacle" lenken i Index viewet
        [HttpGet]
        public ActionResult DataForm() => View();


        // POST: /Obstacle/DataForm
        // blir kalt etter at vi trykker på "Submit Data" knapp i DataForm viewet
        // nå med støtte for trygg bildeopplasting
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DataForm(Obstacle obstacledata, IFormFile? ObstacleImage)
        {
            if (!ModelState.IsValid)
                return View(obstacledata);

            //  Trygg bildeopplasting
            if (ObstacleImage != null && ObstacleImage.Length > 0)
            {
                long MAX_FILE_BYTES = 5 * 1024 * 1024; // 5 MB
                var allowedExt = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                { ".jpg", ".jpeg", ".png", ".gif" };

                var ext = Path.GetExtension(ObstacleImage.FileName).ToLowerInvariant();

                // Avvis XML og SVG (XXE / script fare)
                if (ext == ".xml" || ext == ".svg")
                {
                    ModelState.AddModelError("ObstacleImage", "SVG and XML files are not allowed.");
                    return View(obstacledata);
                }

                if (!allowedExt.Contains(ext))
                {
                    ModelState.AddModelError("ObstacleImage", "Only JPG, PNG, or GIF files are allowed.");
                    return View(obstacledata);
                }

                if (ObstacleImage.Length > MAX_FILE_BYTES)
                {
                    ModelState.AddModelError("ObstacleImage", "File too large (max 5 MB).");
                    return View(obstacledata);
                }

                // Les filen i minne for å sjekke signatur (magic bytes)
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    await ObstacleImage.CopyToAsync(ms);
                    fileBytes = ms.ToArray();
                }

                if (!IsImageSignatureValid(fileBytes))
                {
                    ModelState.AddModelError("ObstacleImage", "Uploaded file is not a valid image.");
                    return View(obstacledata);
                }

                //  Lagre trygt utenfor wwwroot
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + ext;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);

                // Lagre kun filnavnet i databasen
                obstacledata.ImagePath = uniqueFileName;
            }

            //  Legg til dato og bruker-ID
            obstacledata.ObstacleSubmittedDate = DateTime.Now;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var saved = await _service.AddObstacleAsync(obstacledata, userId);

            //  Gå til oversiktssiden etter innsending
            return RedirectToAction("Overview", new { id = saved.ObstacleId });
        }


        // GET: /Obstacle/Overview/{id}
        // hent hindre med id
        [HttpGet]
        public async Task<IActionResult> Overview(int id)
        {
            var obstacle = await _service.GetObstacleByIdAsync(id);
            if (obstacle == null) return NotFound();

            return View(obstacle);
        }


        // GET: /Obstacle/GetImage?fileName=<guid>.jpg
        // Trygg måte å vise opplastede bilder på
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetImage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return BadRequest();

            // Regex: sjekk at filnavn ser ut som en GUID + gyldig extension
            if (!Regex.IsMatch(fileName, @"^[0-9a-fA-F\-]{36}\.(jpg|jpeg|png|gif)$", RegexOptions.IgnoreCase))
                return NotFound();

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var ext = Path.GetExtension(filePath).ToLowerInvariant();
            var contentType = ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };

            return PhysicalFile(filePath, contentType);
        }


        // Hjelpemetode: sjekk ekte bildeformat via magic bytes
        private bool IsImageSignatureValid(byte[] bytes)
        {
            if (bytes == null || bytes.Length < 4) return false;

            // JPEG (FF D8 FF)
            if (bytes.Length >= 3 &&
                bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF)
                return true;

            // PNG (89 50 4E 47)
            if (bytes.Length >= 8 &&
                bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47)
                return true;

            // GIF (GIF)
            if (bytes[0] == (byte)'G' && bytes[1] == (byte)'I' && bytes[2] == (byte)'F')
                return true;

            return false;
        }
    }
}
