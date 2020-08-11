# Panoptes .NET Client
A .NET client for accessing the Panoptes API

## General
This repo contains three projects: a `ConsoleApp` (to test calls while developing), the `PanoptesNetClient`, and a separate `PanoptesNetClientTests` project to cover testing.

## Requirements
In order to run this client, an app must have a config transform with two config files (debug and release) to account for the Config class calling the `ConfigurationManager`.

In this repo, the `ConsoleApp` contains an example of how config files should be set up to run the client (`App.Debug.config` and `App.Release.Config`).  
Ex: `<add key="Environment" value="Debug" xdt:Transform="Replace" xdt:Locator="Match(key)" />`

Each config file should contain four keys: `Environment`, `ApiHost`, `ApplicationId`, and `StatsHost`. Note: these keys should also be contained in the main `App.Config` as empty strings.

## NuGet?
The Panoptes [.NET client](https://www.nuget.org/packages/PanoptesNetClient) is hosted on NuGet, which is a package manager for the Microsoft development platform. Should you need to publish any changes on NuGet, Microsoft has a nice [guide](https://docs.microsoft.com/en-us/nuget/nuget-org/publish-a-package) on how to publish. There's also some more detailed information [here](https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools) on getting the NuGet cli set up.

If this API key is expired, you'll need to regenerate a new API key by [logging into](https://www.nuget.org/account/ApiKeys) the NuGet account using the Zooniverse Microsoft credentials. Once you're in, you can regenerate a new key and use that key to push changes to NuGet.

## Making a Request

### GET

A GET request can be made a couple different ways, depending on the return value and need to send a query.  
`ApiClient client = new ApiClient();`

Get a single resource:  
`Workflow workflow = await client.Workflows.Get("1234");`

Get a list of queued subjects for a project:
```
NameValueCollection query = new NameValueCollection();
query.Add("workflow_id", "1234");
List<Subject> subjects = await client.Subjects.GetList("queued", query);
```
