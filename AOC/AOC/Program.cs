using System;
using AOC.Input;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
ConfigureServices(services);


Console.WriteLine("Hello, World!");

return;


void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<InputProvider>(client =>
    {
        client.BaseAddress = new Uri("https://adventofcode.com");
        client.DefaultRequestHeaders.Add("Cookie", Environment.GetEnvironmentVariable("AOC_TOKEN"));
    });
}
