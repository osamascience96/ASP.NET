# BASIC dotnet Command List

## Create a New Project using a dotnet command
***dotnet*** **new _webapp_ -o MyWebApp _--no-https_** 
- **Please review the details for the parameters**
- **new**: This Parameter is used to create a new application using the dotnet utility.
- **webapp**: This paramter specifies the template, when creating the application
- **-o MyWebApp**: This parameter(-o) creates a directory named __MyWebApp__ where my application data is stored.
- **--no-https**: This parameter raise the flag to not to enable the ssl or https, as this app is created on a localhost

## What Command is used to run the Project?
1. ***dotnet*** *watch*
   - This command is used to run the Project and it'll run the Project on your browser at the very specified port configured in the lauchsettings.json

## 4 Main Points to foucs on.
1. ***Program.cs***
   - This file contains the app startup code and **middleware configuration**.
2. ***Pages Directory***
   - This directory contains the web pages of the Project
3. ***MyWebApp.csproj***
   - This file contains the configuration of the project like version of .NET SDK etc.
4. ***launchsettings.json***
   - This file contains the launch settings of the project where you can see the profile object, in which there is a port automatically defined at the creation of the project from 5000-5300. And also you can see the other servers configurations like IISExpress etc. 

## What is middleware configuration
   - The **Middleware Configuration** is a configuration that is set on the pipeline of the project to handle the http request and response.    
