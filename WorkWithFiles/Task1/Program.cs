using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь до папки, которую нужно почистить (т.е. удалить файлы и папки, которые не использовались более 30 минут)");
            string path = Console.ReadLine();
            
            CleanFolder(path); //   Вызов метода очистки папки
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
