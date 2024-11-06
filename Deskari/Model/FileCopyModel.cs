using System;
using System.IO;

namespace Deskari.Model
{
    public class FileCopyModel
    {

        public event EventHandler CopyCompleted;

        /**
         *  Function to copy files from source to destination, and update progress
         */
        public void CopyFiles(string sourceDir, string destDir, IProgress<int> progress)
        {
            try
            {
                Directory.CreateDirectory(destDir);

                var files = Directory.GetFiles(sourceDir);
                int totalFiles = files.Length;
                int filesCopied = 0;

                foreach (var file in files)
                {
                    var destFile = Path.Combine(destDir, Path.GetFileName(file));
                    File.Copy(file, destFile, true);
                    filesCopied++;

                    progress?.Report((filesCopied * 100) / totalFiles);
                }

                var directories = Directory.GetDirectories(sourceDir);
                int totalDirectories = directories.Length;

                foreach (var directory in directories)
                {
                    var destDirectory = Path.Combine(destDir, Path.GetFileName(directory));
                    CopyFiles(directory, destDirectory, progress);
                }

                CopyCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
