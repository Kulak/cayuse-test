# README

This project is for .NET Core 2.2 and is maintained in `Visual Studio Code`.

As a result it doesnot have a typical "Visual Studio" solution file out of the box.

## STATUS

work in progress

## Command Line Reference

All commands assume that you are in the root directory of this repository.

If running from directory of the target project (web service app or test project), then project identification is not necessary.

### Build

    dotnet build

### Run Web Service

    dotnet run --project .\Demo-WebApp\Demo-WebApp.csproj

And then go to URL:

    https://localhost:5001/api/weather/byzip?zipcode=99037

### Run Tests

    dotnet test .\Demo-WebApp-Test\

or if you want to see output generated by tests:

    dotnet test .\Demo-WebApp-Test\ -l:trx

and check content of *.trx files in TestResults directory.
