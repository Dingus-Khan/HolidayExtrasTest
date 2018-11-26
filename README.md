# HolidayExtrasTest
This repository contains all the code for the technical test, to be completed as part of Holiday Extras' application process.

## Overview
The initial task was to create a simple CRUD API, to allow users to create, read, update, and delete users from the data source.
The applicant had the option to add any extras they wished, as long as it performed at least the basic functionality to a good standard.

## Description
My solution to this problem has 3 main components. 
* Class Library, for most of the functionality
* API Controller, for interacting with the Class Library
* Web App, providing a simple front-end to demonstrate the API

#### Class Library
The class library houses a range of methods, as well as the model class for the user. 
The methods include
* A way to get all of the users, or one using a specified ID
* A way to delete a user based on the ID
* A way to create a user, based on a simple JSON format matching the User model
* A way to update a user, based on the same JSON format, but including the ID
* A "SaveChanges()" method, for saving the changes to the JSON file (which is the main data source for this solution)
* A constructor, which opens the JSON file and loads all of the users

#### API Controller and Web App
The API Controller and the Web App are part of the same project, with the web app acting as a sort of "back-office" style system. 
The idea is that the API endpoints are for any connections, and the web app shows an implementation of that. I saw no reason to split the projects up.
The API controller exposes endpoints for each of the functions in the class library, aside from the constructor and the SaveChanges() method.
The Web App uses AJAX to send requests to those endpoints, to mimic external connections

## Notes
This project should build using the .NET Core 2.1 SDK, and a simple `dotnet build` should successfully compile the project. 

This project uses a JSON file for storing the data, enabling it to last the lifetime of the test. 
Normally, I would use a database, but I was offline while building this and had no database software on either of my systems at home.

I built this using .NET Core for 2 reasons. The first is that I have a lot of experience working with it, and the second is that I felt
I could showcase my skills best with this as, again, I was working without an internet connection so I had no access to documentation or 
updated versions of other software. 
