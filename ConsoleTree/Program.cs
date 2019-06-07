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
                    ShowHelp();
                    return;
                }
            }

            explorer.DisplayTree(Environment.CurrentDirectory);
        }

        private static void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Консольное приложение, которые выводит содержимое текущего и вложенных каталогов в виде дерева");
            Console.WriteLine("Дополнительные агрументы при запуске приложения:");
            Console.WriteLine("-d или --depth - задать глубину вложенности. Сама глубина задается целым числом, указываемым после аргумента");
            Console.WriteLine("-s или --size - отображать размер файлов");
            Console.WriteLine("-h или --human-readable - отображать размер файлов в удобном для восприятия виде");
            Console.WriteLine("--help или -? - справка");
            Console.ResetColor();
        }
    }
}
