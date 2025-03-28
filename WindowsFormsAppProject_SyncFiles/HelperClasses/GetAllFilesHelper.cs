using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsAppProject_SyncFiles.Interfaces;

namespace WindowsFormsAppProject_SyncFiles.HelperClasses
{
    public class GetAllFilesHelper
    {
        private IAppendColoredText _appendColoredText;
        private string _startingDirectory;

        public GetAllFilesHelper(IAppendColoredText appendColoredText)
        {
            _appendColoredText = appendColoredText;
        }

        public SortedDictionary<string, FileInfoHolder> CheckForChanges(string pathToChangesFile)
        {
            SortedDictionary<string, FileInfoHolder> sortedFiles = new SortedDictionary<string, FileInfoHolder>();

            try
            {
                if (File.Exists(pathToChangesFile))
                {
                    string newPathRoot = Path.GetPathRoot(pathToChangesFile);
                    string[] lines = File.ReadAllLines(pathToChangesFile);

                    for (int i = 0; i < lines.Length - 1; i += 2)
                    {
                        var fih = new FileInfoHolder("", DateTime.Parse(lines[i + 1]).ToUniversalTime());
                        string oldPathRoot = Path.GetPathRoot(lines[i]);
                        sortedFiles.Add(lines[i].Replace(oldPathRoot, newPathRoot), fih);
                    }

                    _appendColoredText.AppendColoredText($@"File found. Done getting all files from: {pathToChangesFile}", Color.Blue);
                }
                else
                {
                    _appendColoredText.AppendColoredText($"Cannot find: {pathToChangesFile} | Moving to collect directories and files.", Color.YellowGreen);
                }
            }
            catch (Exception ex)
            {
                _appendColoredText.AppendColoredText(ex.Message, Color.Red);
            }

            return sortedFiles;
        }

        public List<string> GetAllDirectories(string startingDirectory)
        {
            _startingDirectory = startingDirectory;
          
            _appendColoredText.AppendColoredText($@"Getting all folders from: {_startingDirectory}", Color.Blue);
            
            List<string> allDirectories =
                Directory.GetDirectories(startingDirectory)
                .Where(dir => !dir.Contains("GitHub"))
                .ToList();

            try
            {
                for (int i = 0; i < allDirectories.Count; i++)
                {
                    try
                    {
                        allDirectories.AddRange(Directory.GetDirectories(allDirectories[i]));
                    }
                    catch (Exception ex)
                    {
                        _appendColoredText.AppendColoredText(ex.Message, Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                _appendColoredText.AppendColoredText(ex.Message, Color.Red);
            }

            _appendColoredText.AppendColoredText($@"Done getting all folders from: {_startingDirectory}", Color.Blue);
            return allDirectories;
        }

        public SortedDictionary<string, FileInfoHolder> GetAllFiles(List<string> allDirectories)
        {
            _appendColoredText.AppendColoredText($@"Getting all files from: {_startingDirectory}", Color.Blue);
            
            SortedDictionary<string, FileInfoHolder> allSortedFiles = new SortedDictionary<string, FileInfoHolder>();
            ConcurrentBag<FileInfoHolder> bagOfAllFiles = new ConcurrentBag<FileInfoHolder>();

            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.ForEach(allDirectories, options, directory =>
            {
                ConcurrentGetFiles(directory, bagOfAllFiles);
            });

            foreach (var fih in bagOfAllFiles)
            {
                if (!allSortedFiles.ContainsKey(fih.FullFilePath))
                {
                    allSortedFiles.Add(fih.FullFilePath, fih);
                }
            }

            _appendColoredText.AppendColoredText($@"Done getting all files from: {_startingDirectory}", Color.Blue);
            return allSortedFiles;
        }

        private void ConcurrentGetFiles(string directory, ConcurrentBag<FileInfoHolder> bagOfAllFiles)
        {
            List<string> files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(directory, "*"));

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    FileInfoHolder fih = new FileInfoHolder(file, fi.LastWriteTimeUtc);
                    bagOfAllFiles.Add(fih);
                }
            }
            catch (Exception ex)
            {
                _appendColoredText.AppendColoredText(ex.Message, Color.Red);
            }
        }
    }
}
