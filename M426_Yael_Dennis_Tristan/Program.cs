using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.ConsoleService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace M426_Yael_Dennis_Tristan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            Casino casino = new Casino(host);
            casino.Play();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<INumberCaller, NumberCaller>();
                services.AddTransient<IBingoConsoleService, BingoConsoleService>();
            });
    }
}
