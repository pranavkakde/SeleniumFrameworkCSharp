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
dotnet test SeleniumFramework.csproj -e gridUrl=http://<ipaddress>:4444 -e browserName=chrome
```

If selenium grid is not setup then skip the gridUrl parameter and the framework will launch driver using local browser instance.
```
dotnet test SeleniumFramework.csproj -e browserName=chrome
```

For setting up selenium grid using docker run; 

>Pre-requisite - Install Docker Desktop

```
docker compose up -d 
```

For building the docker image for test framework;

```
docker build -t seleniumframeworkcsharp .
```

To run the tests using docker container;
```
docker run --name seleniumcsharp_test_run seleniumframeworkcsharp:latest -e gridUrl=http://192.168.20.27:4444 -e browserName=edge --logger trx
```

Once test execution is complete using docker, run docker cp to get test results files.
```
docker cp seleniumcsharp_test_run:/testrun/TestResults <host directory>
```

2. CI/CD pipeline using Azure Devops and Github Actions.
