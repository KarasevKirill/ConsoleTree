using System;

namespace DNSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var explorer = new Explorer();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-d" || args[i] == "--depth")
                {
                    explorer.UseDepth = true;

                    try
                    {
                        int depth = Convert.ToInt32(args[i + 1]);

                        explorer.Depth = depth;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("При использовании параметров -d или --depth необходимо указать глубину вложенности");
                        Console.ResetColor();
                        return;
                    }
                }

                if (args[i] == "-h" || args[i] == "--human-readable")
                    explorer.UseReadable = true;

                if (args[i] == "-s" || args[i] == "--size")
                    explorer.UseSize = true;

                if (args[i] == "--help" || args[i] == "-?")
                {
                    explorer.ShowHelp();
                    return;
                }
            }

            explorer.DisplayTree(Environment.CurrentDirectory);
        }
    }
}
