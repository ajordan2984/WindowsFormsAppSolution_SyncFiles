﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsAppProject_SyncFiles.HelperClasses;
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

        private ConcurrentDictionary<string, FileInfoHolder> allSortedFilesFromPcPath;
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

        public void SetAllSortedFilesFromPcPath(ConcurrentDictionary<string, FileInfoHolder> files)
        {
            allSortedFilesFromPcPath = files;
        }

        public void SetPaths(string pathToFilesOnPc, string pathToFilesOnExternal)
        {
            _pathToFilesOnPc = pathToFilesOnPc;
            _pathToFilesOnExternal = pathToFilesOnExternal;
            _shortPathToFilesOnPc = hf.ShortenedPath(_pathToFilesOnPc);
            _shortPathToFilesOnExternal = hf.ShortenedPath(_pathToFilesOnExternal);
        }

        public void SyncFiles()
        {
            GetAllFilesHelper gafh = new GetAllFilesHelper(_appendColoredText);
            
            _appendColoredText.AppendColoredText($@"Checking for the file: {_pathToFilesOnExternal}\Changes.txt", Color.Blue);
            allSortedFilesFromFromExternalDrive = gafh.CheckForChanges($@"{_pathToFilesOnExternal}\Changes.txt");

            if (allSortedFilesFromFromExternalDrive.Count == 0)
            {
                allSortedFilesFromFromExternalDrive = gafh.GetAllFiles(gafh.GetAllDirectories(_pathToFilesOnExternal));
            }

            _appendColoredText.AppendColoredText($@"Copying files from: {_pathToFilesOnPc} to {_pathToFilesOnExternal}", Color.Blue);
            hf.CopyFilesFromOneDriveToAnotherDrive(
                allSortedFilesFromPcPath,
                allSortedFilesFromFromExternalDrive,
                _shortPathToFilesOnPc,
                _shortPathToFilesOnExternal
                );
            _appendColoredText.AppendColoredText($@"Done copying files from: {_pathToFilesOnPc} to {_pathToFilesOnExternal}", Color.Blue);

            _appendColoredText.AppendColoredText($@"Quarantining files on: {_pathToFilesOnExternal}", Color.Blue);
            hf.QuarantineFiles(
            allSortedFilesFromPcPath,
            allSortedFilesFromFromExternalDrive,
            _shortPathToFilesOnPc,
            _shortPathToFilesOnExternal);
            _appendColoredText.AppendColoredText($@"Done quarantining files on: {_pathToFilesOnExternal}", Color.Blue);

            _appendColoredText.AppendColoredText($@"Removing any empty folders on: {_pathToFilesOnExternal}", Color.Blue);
            hf.RecursiveRemoveDirectories(_pathToFilesOnExternal);
            _appendColoredText.AppendColoredText($@"Done removing any empty folders on: {_pathToFilesOnExternal}", Color.Blue);

            _appendColoredText.AppendColoredText($"Writing \"Changes.txt\" on: {_pathToFilesOnExternal}", Color.Blue);
            hf.UpdateChangesFile($@"{_pathToFilesOnExternal}\Changes.txt", allSortedFilesFromFromExternalDrive);
            _appendColoredText.AppendColoredText($"Done writing \"Changes.txt\" on: {_pathToFilesOnExternal}", Color.Blue);
        }
    }
}

