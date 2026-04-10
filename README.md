# CMPT291_Project_Team5
this repository serve as the repository for the CMPT 291 Project.

Setup note:
First setup a SQL server authentication your machine and setup a 
username and password.
Once completed, setup the DB using the create & insert files.

Copy `MovieRental_Team5/MovieRental_Team5/App.template.config` to `MovieRental_Team5/MovieRental_Team5/App.config` on your own machine, then fill in your local SQL Server connection details. `App.config` is gitignored so credentials and LAN IPs stay out of the repository.

Other way to do it is creating a App.config file in the visual studio or an xml file and renaming it.


The App.config requires your own SQL server authentication so make sure to set up the DB beforehand.
In the app.config make sure youre using your own IP address for the connection string or server address.

In a scenario where you are using a server instance:
Replace the line where its suppose to be your IP and port number with your server instance
ex. Server=YOUR_SERVER_IP,1433; -> Server=YOUR_SERVER_NAME;

to find your connection string go to the command prompt and run ipconfig
find your ipv4 address then copy and paste it into your app.config 
