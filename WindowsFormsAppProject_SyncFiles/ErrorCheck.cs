using System.IO;

namespace WindowsFormsAppProject_SyncFiles
{
    public class ErrorCheck
    {
        public ErrorCheck ()
        {

        }

        public string StartCheck(
            string PathToFilesOnPc,
            string PathToFilesOnExternal)
        {
            if (!Directory.Exists(PathToFilesOnPc))
            {
                return $"Error: Sorry the path on your PC: {PathToFilesOnPc} does not exist. Please try again.";
            }

            if (!Directory.Exists(PathToFilesOnExternal))
            {
                return $"Error: Sorry the path on your External Drive: {PathToFilesOnExternal} does not exist. Please try again.";
            }

            string pathA = Path.GetFileName(PathToFilesOnPc);
            string pathB = Path.GetFileName(PathToFilesOnExternal);

            if (Path.GetFileName(pathA) != Path.GetFileName(pathB))
            {
                return $"Error: Sorry the end of path: {PathToFilesOnPc} does not match the end of path {PathToFilesOnExternal}. Please try again.";
            }

            return null;
        }
    }
}
