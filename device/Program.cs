using System;
using System.Threading.Tasks;
using System.CommandLine;
using System.CommandLine.Invocation;
using ModulaIOT.Device;

namespace device
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var root = new RootCommand("Dotnet Modula IOT Device");

            var run = new Command("run", "Run the device");
            run.Handler = CommandHandler.Create(async () =>
            {
                Console.WriteLine("Run");
                var device = new ModulaIOTDeviceBuilder().Build();
                await device.Run();
                return 0;
            });
            root.AddCommand(run);

            root.Handler = CommandHandler.Create(async () =>
            {
                Console.WriteLine("Executing Default Command, Run..");
                return await run.InvokeAsync(args);
            });

            return await root.InvokeAsync(args);
        }
    }
}
