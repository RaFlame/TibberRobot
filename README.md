# Tibber Robot Movement
## Problem Specification
Tibber platform consists of swarm of micro services running as Docker containers. Primary development platforms are .NET Core and Node JS in conjunction with other platforms. Backed mostly using PostgreSQL as relational/document storage and Amazon S3 as blob storage.

Create a new micro service that could fit into the Tibber Platform environment as described above. The service will simulate a robot moving in an office space and cleaning the places the robot visits. The path of the robot movement is described by start coordinates and move commands. After the cleaning has been done the robot reports the number of unique places cleaned, and the service will store the result into the database. The service listens to HTTP protocol on port 5000.

Request method: POST

Request path: /tibber-developer-test/enter-path

Input criteria:

0 ≤ number of commmands elements ≤ 10000

−100 000 ≤ x ≤ 100 000

−100 000 ≤ y ≤ 100 000

direction ∈ {north, east, south, west}

0 < steps < 100 000

Request body example:

```
{
    "start": {
        "x": 10,
        "y": 22
    },
    "commmands": [
        {
            "direction": "east",
            "steps": 2
        },
        {
            "direction": "north",
            "steps": 1
        }
    ]
}
```


The resulting value will be stored in a table named executions together with timestamp of insertion, number of command elements and duration of the calculation in seconds.

Stored record example:

| id  | timestamp | commmands | result | duration
| ------------- | ------------- | ------------- | ------------- | ------------- |
| 1234  | 2018-05-12 12:45:10.851596 +02:00 | 2 | 4 | 0.000123 |


## Technical Specification

**Language**: C#

**Framework**: .NET Core 2.1

**Project Dependencies**: 
- [Microsoft.EntityFrameworkCore](https://github.com/aspnet/EntityFrameworkCore)
- [Npgsql.EntityFrameworkCore.PostgreSQL](https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL)
- [Npgsql.EntityFrameworkCore.PostgreSQL.Design](https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL)
- [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Swashbuckle.AspNetCore.SwaggerGen](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Swashbuckle.AspNetCore.SwaggerUi](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [AutoMapper.Extensions.Microsoft.DependencyInjection](https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection)
- [xunit](https://github.com/xunit/xunit)
- [Moq](https://githudb.com/moq/moq4)

## Setup environment
**Prerequisite**: Make sure you have installed .NET Core SDK 2.1.1 and PostgreSQL 11.5.

You can run the backend service in two ways.
#### Visual Studio
- Open TibberRobot.sln.
- Clean and rebuild the solution Debug menu.
- Configure your database from appsettings.json/ and appsettings.development.json
- Execute Update-Database
- Run application from debug menu.

#### Command Line
- Open a command line on the solution folder. 
- And use the following commands.

```dotnet restore```

```dotnet build ```
- Configure your database from appsettings.json/ and appsettings.development.json and execute

```dotnet ef database update```

```dotnet run```

### Run docker container
- Open root folder
- Open command line on that folder
- Execute following commands

```docker-compose build```

```docker-compose up```

