namespace DelegateHomework.EventsExamples;

public class FileProcessing
{
	string? _pathWhereFileLocated = string.Empty;    

	public FileProcessing(string? pathWhereFileLocated)
	{
        _pathWhereFileLocated = pathWhereFileLocated;
    }

    public void CheckFileExistance()
    {
        if (string.IsNullOrEmpty(_pathWhereFileLocated) == false)
        {
            var filesAndDirs = new List<string>();

            var files = Directory.GetFiles(_pathWhereFileLocated);
            var directories = Directory.GetDirectories(_pathWhereFileLocated);

            filesAndDirs.AddRange(files);
            filesAndDirs.AddRange(directories);

            foreach (var file in filesAndDirs)
            {
                if (IsFolder(file) == false)
                {
                    Console.WriteLine($"This is file {file}");
                    OnFileFound(this, new FileArgs { FileName = Path.GetFileName(file) });
                }
                else
                {
                    Console.WriteLine($"This is directory {file}");
                    Console.WriteLine();
                }
            }
        }
    }

    public bool IsFolder(string path)
    {
        return ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory);
    }

    public event EventHandler<FileArgs>? FileFound;
    public void OnFileFound(object sender, FileArgs args)
    {
        FileFound?.Invoke(this, args);
    }
}