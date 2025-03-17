using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsAppProject_SyncFiles
{
    public class SyncFilesFromPcToExternalDrive
    {
        string _pathToFilesOnPc;
        string _pathToFilesOnExternal;

        string _shortPathToFilesOnPc;
        string _shortPathToFilesOnExternal;

        SortedDictionary<string, FileInfoHolder> allSortedFilesFromPcPath;
        SortedDictionary<string, FileInfoHolder> allSortedFilesFromFromExternalDrive;

        HelperFunctions hf = new HelperFunctions();

        public SyncFilesFromPcToExternalDrive()
        {
            // Empty
        }

        public void SetPaths(string PathToFilesOnPc, string PathToFilesOnExternal)
        {
             _pathToFilesOnPc = PathToFilesOnPc;
             _pathToFilesOnExternal = PathToFilesOnExternal;
            _shortPathToFilesOnPc = hf.ShortenedPath(_pathToFilesOnPc);
            _shortPathToFilesOnExternal = hf.ShortenedPath(_pathToFilesOnExternal);
        }

        public void SyncFiles()
        {
            allSortedFilesFromFromExternalDrive = hf.CheckForChanges($@"{_pathToFilesOnExternal}\Changes.txt");

            if (allSortedFilesFromFromExternalDrive.Count == 0)
            {
                List<string> directoriesFromExternal = hf.GetAllDirectories(_pathToFilesOnExternal);
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

            return;
        }
    }
}

