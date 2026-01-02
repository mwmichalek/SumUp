// See https://aka.ms/new-console-template for more information

using ClickUp.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = config["ClickUp:ApiKey"] ?? throw new InvalidOperationException("API Key not found in user secrets.");

Console.WriteLine("Hello, World!");

// 1. Setup Authentication (ClickUp expects "Authorization" header)
var authProvider = new ApiKeyAuthenticationProvider(
    apiKey, 
    "Authorization", 
    ApiKeyAuthenticationProvider.KeyLocation.Header
);

// 2. Setup the Request Adapter
var adapter = new HttpClientRequestAdapter(authProvider);

// 3. Instantiate your Client
var client = new ClickUpApiClient(adapter);

var task = await client.V2.Task["86b7eh98z"].GetAsync();

Console.WriteLine($"Task Name: {task.Name}");