# Selenium Framework in C#
This framework is created in Selenium and C#. It uses Page Object model design pattern. This project was originally writter for .net Framework and now it has been upgraded to .net core.

Folder structure :-
1. pages  -> contains page objects and Web element descriptions.
2. tests -> contains test class with Nunit style test cases.
3. util -> contains classes for managing test data from appsettings.json; classes for managing driver for chrome, firefox and edge and Util class with common functions.

appsettings.json contains data e.g. URL and browser config. 

## Gettign started

Clone this project and run to build the project. 

```
dotnet build SeleniumFramework.csproj 
```

To run the tests;
```
dotnet test SeleniumFramework.csproj
```
#### Enhancements
1. Docker support
2. CI/CD pipeline using Azure Devops and Github Actions.