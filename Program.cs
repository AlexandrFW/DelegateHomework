using DelegateHomework.CustomExtensionDelegateMethod;
using DelegateHomework.EventsExamples;

internal class Program
{
    private static void Main(string[] args)
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

        var currentDirectoryPath = Environment.CurrentDirectory;
        var fileProcessing = new FileProcessing(currentDirectoryPath);
        fileProcessing.FileFound += OnFileFound;
        fileProcessing.CheckFileExistance();

        Console.ReadKey();

        fileProcessing.FileFound -= OnFileFound;
        fileProcessing = null;
    }

    static void OnFileFound(object? sender, FileArgs e)
    {
        Console.WriteLine($"[Event->OnFileFound] File found: {e.FileName}");
        Console.WriteLine();
    }
}