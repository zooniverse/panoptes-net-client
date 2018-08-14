# Panoptes .NET Client
A .NET client for accessing the Panoptes API

## General
This repo contains three projects: a `ConsoleApp` (to test calls while developing), the `PanoptesNetClient`, and a separate `PanoptesNetClientTests` project to cover testing.

## Requirements
In order to run this client, an app must have a config transform with two config files (debug and release) to account for the Config class calling the `ConfigurationManager`.

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
