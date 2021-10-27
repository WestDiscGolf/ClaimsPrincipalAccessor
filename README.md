# ClaimsPrincipalAccessor
A demo to show how to parse and consume the claims principle when using Azure Functions with Azure Static Web Apps and access it through dependency injection.

This method is inspired by how ASP.NET Core processes and uses the `IHttpContextAccessor` to access the current request `HttpContext`.

## Prerequisits

You will need the Azure Static Web App cli to be installed. This can be done by running the following command:

`npm i @azure/static-web-apps-cli`

## How to run

1. Clone source
2. Navigate to the root of the repo in a terminal
3. Run the following command

`swa start http://localhost:5118 --run "cd .\src\client && dotnet watch run" --api .\src\api`

This will start the Azure Static Web App cli emulator running the blazor client app under port 5118 and the Azure Functions application under "api".

4. Now open browser and navigate to http://localhost:4280
