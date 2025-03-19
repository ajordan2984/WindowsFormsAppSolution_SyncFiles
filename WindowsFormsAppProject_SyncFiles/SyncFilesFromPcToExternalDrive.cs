using System.Collections.Generic;
using System.Drawing;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles
{
    public class SyncFilesFromPcToExternalDrive
    {
        private IAppendColoredText _appendColoredText;

        private string _pathToFilesOnPc;
        private string _pathToFilesOnExternal;

        private string _shortPathToFilesOnPc;
        private string _shortPathToFilesOnExternal;

        private SortedDictionary<string, FileInfoHolder> allSortedFilesFromPcPath;
        private SortedDictionary<string, FileInfoHolder> allSortedFilesFromFromExternalDrive;

        private HelperFunctions hf;

        public SyncFilesFromPcToExternalDrive()
        {
        }

        public void SetAppendColorText(IAppendColoredText appendColoredText)
        {
            _appendColoredText = appendColoredText;
            hf = new HelperFunctions(_appendColoredText);
        }

        public void SetPaths(string PathToFilesOnPc, string PathToFilesOnExternal)
        {
             _pathToFilesOnPc = PathToFilesOnPc;
             _pathToFilesOnExternal = PathToFilesOnExternal;
            _shortPathToFilesOnPc = hf.ShortenedPath(_pathToFilesOnPc);
            _shortPathToFilesOnExternal = hf.ShortenedPath(_pathToFilesOnExternal);
        }

        public bool SyncFiles()
        {
            _appendColoredText.AppendColoredText($@"Checking for the file: { _pathToFilesOnExternal}\Changes.txt", Color.Blue);
            
            allSortedFilesFromFromExternalDrive = hf.CheckForChanges($@"{_pathToFilesOnExternal}\Changes.txt");

            if (allSortedFilesFromFromExternalDrive.Count == 0)
            {
                _appendColoredText.AppendColoredText($@"Getting all folders from: { _pathToFilesOnExternal}", Color.Blue);
                
                List<string> directoriesFromExternal = hf.GetAllDirectories(_pathToFilesOnExternal);
                
                _appendColoredText.AppendColoredText($@"Getting all files from: { _pathToFilesOnExternal}", Color.Blue);
                
                allSortedFilesFromFromExternalDrive = hf.GetAllFiles(directoriesFromExternal);
            }

            // Get files from Pc
            List<string> directoriesFromPc = hf.GetAllDirectories(_pathToFilesOnPc);
            allSortedFilesFromPcPath = hf.GetAllFiles(directoriesFromPc);

            hf.CopyFilesFromOneDriveToAnotherDrive(
                allSortedFilesFromPcPath,
                allSortedFilesFromFromExternalDrive,
                _shortPathToFilesOnPc,
                _shortPathToFilesOnExternal
                );

            hf.QuarantineFiles(
            allSortedFilesFromPcPath,
            allSortedFilesFromFromExternalDrive,
            _shortPathToFilesOnPc,
            _shortPathToFilesOnExternal);

            hf.RecursiveRemoveDirectories(_pathToFilesOnExternal);

            hf.UpdateChangesFile($@"{_pathToFilesOnExternal}\Changes.txt", allSortedFilesFromFromExternalDrive);

            return true;
        }
    }
}

