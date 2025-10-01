Under maintenance. New docker-compose setup.



# Setting up the DBPASSWORD



1. Open cmd, and clone the project



![dockercompose](images/cmd1.png)



2\. Open the solution in Visual Studio



![dockercompose](images/solution2.png)



3\. Right click the docker-compose text, and hover over Add, then click New Item.



![dockercompose](images/add3.png)



4\. Name the file .env



![dockercompose](images/env4.png)



5\. In .env, type DBPASSWORD= and then the password recieved by @dovidee. If not, send a message. Make sure the appsettings.json also contains the password in Pwd=, otherwise it will not work.



![dockercompose](images/apppass5.png)



6\. If you face any errors with the password still. Open cmd, list with «docker volume ls» and then do «docker volume rm {VOLUMENAME HERE}». If it says volume is in use, go to docker desktop and delete the container. Try running the project again.



![dockercompose](images/volume6.png)



![dockercompose](images/deletecompose7.png)



# Running the project



7. Select docker-compose as the main project.



![dockercompose](images/selectdockercompose8.png)



8\. Run the docker-compose project.



![dockercompose](images/rundockercompose9.png)



9\. Observe that all three containers have started.



![dockercompose](images/observedockercompose10.png)















