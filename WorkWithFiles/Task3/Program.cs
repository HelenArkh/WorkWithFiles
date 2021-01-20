using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь до папки");
            string path = Console.ReadLine();

            long size = GetFolderSize(path); //   Вызов метода подсчета размера папки

            Console.WriteLine($"Исходный размер папки: {size} байт");

            CleanFolder(path); //   Вызов метода очистки папки с сохранением файлов и папок, использованных менее 30 минут            

            long sizeAfterClean = GetFolderSize(path); //   Вызов метода подсчета размера папки

            Console.WriteLine($"Освобождено: {size - sizeAfterClean} байт");

            Console.WriteLine($"Текущий размер папки: {sizeAfterClean} байт");
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

        static void CleanFolder(string path)
        {
            try
            {
                if (Directory.Exists(path)) // Проверим, что папка существует
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);

                    foreach (FileInfo f in dirInfo.GetFiles())
                    {
                        if ((DateTime.Now - f.LastAccessTime) > TimeSpan.FromMinutes(30))
                        f.Delete();
                    }

                    foreach (DirectoryInfo d in dirInfo.GetDirectories())
                    {
                        if ((DateTime.Now - d.LastAccessTime) > TimeSpan.FromMinutes(30))
                        d.Delete(true);
                    }
                }
                else
                {
                    Console.WriteLine($"Папка по заданному адресу не существует, возможно, указан некорректный путь: {path}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
