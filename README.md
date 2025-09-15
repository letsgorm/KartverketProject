# Setup

1. Clone the project,
git clone https://github.com/letsgorm/KartverketProject.git

2. Create the container and connect it.
docker run --name mariadbcontainer -e MYSQL_ROOT_PASSWORD= -p 3307:3306 -d docker.io/library/mariadb:11.8

3. Run the project's docker compose

4. You should now have mariadbcontainer and kartverketproject running in docker.

# Connecting to database

5. Create a new .env file inside the docker-compose project.

6. Write "DB_PASSWORD=changeme" or any password you would like.

7. Change Pwd in appsettings.json so that it matches your .env file password.

8. Update the database with "Update-Database" in Nuget Package Manager Console.

9. You should now be connected to the database.

# Migration

10. Delete the migrations folder

11. Add the migration with "Add-Migration -Context ApplicationDbContext" in Nuget Package Manager Console.
