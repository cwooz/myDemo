# MyDemo API Assesment 💾

Simple RESTful API built with ASP.NET Core 3.1 to show how to create RESTful services using a decoupled, maintainable architecture.

```http://localhost:1028/api/people``` [API Base Route](http://localhost:1028/api/people).

```http://localhost:1028/swagger/index.html``` [Swagger Docs](http://localhost:1028/swagger/index.html).

```http://localhost:1028/swagger/v1/swagger.json``` [Swagger Object Shape](http://localhost:1028/swagger/v1/swagger.json).

##### Try version `1.0.0-beta` using the following [link](#). Thanks!

## Frameworks and Libraries
- [ASP.NET Core 3.1](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-3.1)
- [AutoMapper](https://automapper.org/) (for mapping resources and models)
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) (API documentation)
- [NLog](https://nlog-project.org/) (assist with logging)

## How To Test

> First, install latest version of [.NET Core](https://dotnet.microsoft.com/download). Then, open the terminal at the API root path **/src/myDemo/** and run the following commands in sequence:

```bash
# Build Project
dotnet build
# Run Webserver
dotnet run
```

Navigate to ```http://localhost:1028/api/people``` to check if the API is working.

Navigate to ```http://localhost:1028/swagger``` to check the API documentation.

<img alt='Screen Shot' src="./public/img/localhost_1028_swagger.png" width="888">
<img alt='Screen Shot' src="./public/img/localhost_1028_api_people.png" width="888">