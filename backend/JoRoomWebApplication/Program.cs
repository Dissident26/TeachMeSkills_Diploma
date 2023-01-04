using JoRoomWebApplication;

CreateHostBuilder(args)
    .Build()
    .Run();

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<StartUp>();
               });
}