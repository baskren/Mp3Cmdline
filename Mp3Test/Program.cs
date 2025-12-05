
namespace Mp3Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (System.Reflection.Assembly.GetExecutingAssembly().Location is not string dllPath)
                throw new Exception("Unable to get path for executing assembly dll");
            if (Path.GetDirectoryName(dllPath) is not string folderPath)
                throw new Exception("Unable to folder path for executing assembly");
            var mp3Path = Path.Combine(folderPath, "Alarm.mp3");

            if (OperatingSystem.IsWindows())
            {
                var playerPath = Path.Combine(folderPath, "cmdmp3win.exe");
                Shell.ExecuteCommand(playerPath, mp3Path, out string output, out string error);
                return;
            }        

            if (OperatingSystem.IsMacOS())
            {
                Shell.ExecuteCommand("afplay", mp3Path, out string output, out string error);
                return;
            }

            if (OperatingSystem.IsLinux())
            {
                Shell.ExecuteCommand("ffplay", mp3Path, out string output, out string error);
                return;
            }

            throw new Exception("Unsupported OS");
        }

    }


}
