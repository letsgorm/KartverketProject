# Kartverket Project

## Description
Seamlessly register and view obstacles on the map even offline.

### Offline map

To be able to see the map, download the 1.17 GB ZIP below.

http://github.com/letsgorm/KartverketProject/releases/latest/download/norway.zip

Unzip the folder and place the norway.mbtiles file in KartverketProject/KartverketProject/wwwroot/


### Seeded data

## Format
username:password

johnd:admin (NLA, admin)
janed:admin (NLA, reviewer)
bobs:admin (NLA, user)
janiced:admin (Luftsforsvaret, reviewer)


### Getting started


1. Open cmd, and clone the project


![dockercompose](images/cmd1.png)


2. Open the solution in Visual Studio


![dockercompose](images/solution2.png)


3. Right click the docker-compose text, and hover over Add, then click New Item.


![dockercompose](images/add3.png)


4. Name the file .env


![dockercompose](images/env4.png)


5. In .env, type DBPASSWORD= and then any random password. Make sure the appsettings.json also contains the password in Pwd=, otherwise it will not work.


![dockercompose](images/apppass5.png)

6. Select docker-compose as the main project.


![dockercompose](images/selectdockercompose8.png)


7. Run the docker-compose project.


![dockercompose](images/rundockercompose9.png)


8. Observe that all three containers have started.


![dockercompose](images/observedockercompose10.png)


### Password does not work

1. Open cmd, list with «docker volume ls» and then do «docker volume rm {VOLUMENAME HERE}». If it says volume is in use, go to docker desktop and delete the container.

![dockercompose](images/volume6.png)


![dockercompose](images/deletecompose7.png)

2. Run the project as docker-compose to set up the volume again.


## Resetting migrations


1. Delete migrations folder


![dockercompose](images/migrations15.png)

2. Switch to KartverketProject 


![dockercompose](images/selectdockercompose8.png)


3. In Visual Studio:


Tools -> NuGet Package Manager -> Package Manager Console


4. Type all commands in order.


Apply-Migrations InitialCreate -Context ApplicationDbContext

Apply-Migrations InitialCreate -Context AuthenticationDbContext

Update-Database -Context ApplicationDbContext

Update-Database -Context AuthenticationDbContext


## System architecture

### MVC

MVC makes it easier to code, debug and test something that only has one job.

![dockercompose](images/mvc14.png)

The model represents the business logic or operations. This can be in forms of error messages or storing data transfer objects. 

The view is responsible for presenting content through the user interface. This includes layouts and pages.

The controller handles user interaction and controls how the app responds to a given request. This includes model validating, page routing and application programming interfaces.

Together these three complement each other, as the controller redirects the user through routes to the corresponding view. The view then shows a button that saves the model state, then it moves that data to the controller for further validation.


### Frontend

The frontend is stored on the wwwroot, where it stores HTML, CSS and JavaScript. While CSS allows styling on the web page, JavaScript enables developers to handle actions such as forms and interactions between the user and the elements. The project uses Tailwind CSS in order to show icons.

### Backend

The backend comprises of the Dockerfile, Docker-compose, Data folder, Controllers and Models. Docker gets its images from the dockerfile, where the containers get the necessary images in order to build the corresponding services in docker-compose.yml; The containers are built on images and use volumes. The volumes stores tables, databases, passwords and additional information about the database. 


### Execution

After docker is finished, program.cs starts; the application adds services to the views to allow for controller interactions, registers the DBContext, runs a third party API called Scalar, and automatically applies migrations through a helper service called migrate. If the appsettings.json password, .env password and the dbcontext are applied correctly; the server starts on port 8082.

### System context diagram

![dockercompose](images/systemcontextdiagram11.png)

Based on the C4 model: https://c4model.com/diagrams/system-context

### Container diagram

![dockercompose](images/containerdiagram12.png)

Based on the C4 model: https://c4model.com/diagrams/container

## Unit testing

### Scenarios

UPDATING

### Results
 
![dockercompose](images/unittesting13.png)

### Security

## ZAP

ZAP only revealed Content Security Policy issues as high risk.
The use of Tailwind CDN, HTTP and unset Content-Type is a security risk.
Due to the reason that this is a local project, during production; we would actually store local Tailwind.
In addition, HTTP would be moved to HTTPS so Tileserver-GL could render the map safely;
Right now unsafe eval in CSP allows for XSS be injected, but most forms are secure due to parsing + serialization

[View ZAP report](security/zapscan.html)

## Stack trace

Stack trace can reveal errors which can be used for error-based SQL or XSS.
By using an exception handler, it redirects the user to an error page rather than showing the stack trace.

![dockercompose](images/stacktrace16.png)

## Brute force

In insecure web pages, attackers can find out the username due to

1. The username showing "Username/email already taken" which can allow attackers to find out the login detail.
2. The password showing "Incorrect password" which can allow the attacker to find the correct password.

In this website, we are only showing "Invalid login attempt" and restricting attempted logins to 5 only;
which then locks the account for 15 minutes until the attacker can log in again.

![dockercompose](images/locked22.png)

This renders brute force essentially useless.

## XSS

XSS can inject JavaScript on other users pages.
Say the attacker uses {}; alert(0); // in BurpSuite.
Then encodes the payload in URL encoding for further requests;

![dockercompose](images/xss17.png)

They can then show the alert on the page.

![dockercompose](images/alert18.png)

With parsing and serialization, the attacker can no longer do XSS.

![dockercompose](images/register19.png)

## IDOR

Authenticated users can see their own reports.
But insecure direct object reference can change the ID in the header to get another users id.

code here 204-207

We changed the code in order to prevent users from getting others reports.
In addition, reviewers are also restricted if they do not fulfill these criteria:

1. Own the report
2. The report is not shared with them
3. They are not part of the same department

![dockercompose](images/idor21.png)

This way, we stop users from editing and deleting reports that belongs to other users.

## Credits

A special thank you to DAkintola94 for assisting us and allowing us to reuse his code for Core Identity.

You can find his project here:

https://github.com/DAkintola94/MatFrem/tree/main

