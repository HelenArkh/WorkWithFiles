using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь до папки, размер которой нужно посчитать");
            string path = Console.ReadLine();

            long size = GetFolderSize(path); //   Вызов метода подсчета размера папки

            Console.WriteLine($"Размер папки: {size}");
        }

        static long GetFolderSize(string path)
        {
            long size = 0;
            try
            {
                if (Directory.Exists(path)) // Проверим, что папка существует
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (string file in files)
                        size += (new FileInfo(file)).Length;

                    string[] folders = Directory.GetDirectories(path);
                    foreach (string folder in folders)
                        size += GetFolderSize(folder);

                    return size;
                }
                else
                {
                    Console.WriteLine($"Не удалось посчитать размер, т.к. папка по заданному адресу не существует, возможно, указан некорректный путь: {path}");
                    return size;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return size;
            }
        }

    }
}
