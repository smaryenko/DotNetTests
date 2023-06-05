# DotNetTests

### Technologies
- Programming language: C# (.NET 7.0)
- Test Framework: NUnit, Specflow
- HttpClient: RestSharp
- Webdriver: Selenium

### Structure
- Tests.Framework: src/main which includes:
	- configuration provider
	- utils and helpers
- Tests.ApiTests:
	- Tests for petstore api
	- Test configuration: appsettings.json (put API key and Token values before run)
- Trello.ApiTests:
	- Step definitions and Test Runner
	- Test configuration: appsettings.json
	- Feature files
  - Page Objects
  - Hooks to include Extend Report (Tests.UI\TestsResult folder)

### Run
- Using .NET Core:

    `dotnet test --logger trx`

- Using NUnit Console:

    https://specflow.org/documentation/Reporting/
