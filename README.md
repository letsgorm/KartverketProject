# Kartverket Project

## Description
Seamlessly register and view obstacles on the map — even offline.

### Offline map

To be able to see the map, download the 1.17 GB ZIP below.

http://github.com/letsgorm/KartverketProject/releases/latest/download/norway.zip

Unzip the folder and place the norway.mbtiles file in KartverketProject/KartverketProject/wwwroot/

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


2. Run the project as docker-compose (step 6), let it start up its containers and then exit.


3. Set the project to KartverketProject, but do not run it.


3. Delete the migrations folder, and run command 3.1 and 3.2 in NuGet Package Manage Console


![dockercompose](images/migrations15.png)


3.1 Add-Migration InitialCreate

3.2 Update-Database


4. Switch the project back to docker-compose (step 6) and run it. 


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

https://github.com/letsgorm/KartverketProject/blob/61e0adda155e96a1ce9f4199811deffa7794ecdf/KartverketTest/Test1.cs#L12-L28

https://github.com/letsgorm/KartverketProject/blob/61e0adda155e96a1ce9f4199811deffa7794ecdf/KartverketTest/Test1.cs#L33-L52

https://github.com/letsgorm/KartverketProject/blob/61e0adda155e96a1ce9f4199811deffa7794ecdf/KartverketTest/Test1.cs#L65-L90

### Results
 
![dockercompose](images/unittesting13.png)
