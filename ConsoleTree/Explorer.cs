using System;
using System.IO;

namespace DNSTest
{
    class Explorer
    {
        public bool UseDepth { get; set; }

        public int Depth { get; set; }

        public bool UseSize { get; set; }

        public bool UseReadable { get; set; }

        public void DisplayTree(string folderPath)
        {
            DisplayTree(folderPath, "", 1);
        }

        private void DisplayTree(string folderPath, string line, int currentDepth)
        {
            if (UseDepth && currentDepth > Depth)
                return;

            var currentFolder = new DirectoryInfo(folderPath);

            var files = currentFolder.GetFiles();
            var folders = currentFolder.GetDirectories();

            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];

                if (i == files.Length - 1 && folders.Length == 0)
                    Console.WriteLine($"{line}└──{file.Name}{GetFileSizeView(file)}");
                else
                    Console.WriteLine($"{line}├──{file.Name}{GetFileSizeView(file)}");
            }

            currentDepth++;

            for (int i = 0; i < folders.Length; i++)
            {
                var folder = folders[i];

                if (i == folders.Length - 1)
                {
                    Console.WriteLine($"{line}└──{folder.Name}");
                    DisplayTree(folder.FullName, $"{line}    ", currentDepth);
                }
                else
                {
                    Console.WriteLine($"{line}├──{folder.Name}");
                    DisplayTree(folder.FullName, $"{line}│   ", currentDepth);
                }
            }
        }

        private string GetFileSizeView(FileInfo file)
        {
            if (!UseSize)
                return "";

            if (UseReadable)
                return $" ({GetFileSize(file.Length)})";
            else
                return $" ({file.Length})";
        }

        private string GetFileSize(long length)
        {
            if (!UseReadable)
                return length.ToString();

            var suf = new string[] { " B", " KB", " MB", " GB", " TB" };

            if (length == 0)
                return "empty";

            var bytes = Math.Abs(length);

            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));

            var num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return $"{(Math.Sign(length) * num)}{suf[place]}";
        }
    }
}
