using DelegateHomework.CustomExtensionDelegateMethod;
using DelegateHomework.EventsExamples;

internal class Program
{
    private async static Task Main(string[] args)
    {
        Console.WriteLine("Delegate homework");
        Console.WriteLine();

        Console.WriteLine("Delegate demonstration");

        var exampleOfUsingCustomExtensionMethod = new UseMaxExtensionMethod();
        exampleOfUsingCustomExtensionMethod.RunMaxExtensionMethodExample();
        exampleOfUsingCustomExtensionMethod = null;

        Console.WriteLine();
        Console.WriteLine("Event demonstration");
        Console.WriteLine();

        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancelTokenSource.Token;
        var currentDirectoryPath = Environment.CurrentDirectory;
        var fileProcessing = new FileProcessing(currentDirectoryPath);
        fileProcessing.FileFound += OnFileFound;
        Task task = new Task(() => fileProcessing.CheckFileExistance(cancellationToken), cancellationToken);
        task.Start();

        Console.WriteLine("Press \"Q\" to cancel checking files...");

        ConsoleKey keyInfo = Console.ReadKey().Key;
        if (keyInfo == ConsoleKey.Q)
            cancelTokenSource.Cancel();

        Console.WriteLine();
        Console.WriteLine("End of program (Wait for Task will be aborted)");

        Console.ReadKey();

        fileProcessing.FileFound -= OnFileFound;
        fileProcessing = null;
        cancelTokenSource.Dispose();
    }

    static void OnFileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"[Event->OnFileFound] File found: {e.FileName}");
        Console.WriteLine();
    }
}