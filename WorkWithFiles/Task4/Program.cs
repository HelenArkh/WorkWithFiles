using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // сохраняем путь к файлу (допустим, я его скачала на рабочий стол)
            string filePath = @"C:\Users\alena\Desktop\Students.dat";

            // создаем на рабочем столе директорию Students
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\alena\Desktop\Students");
            if (!dirInfo.Exists)
                dirInfo.Create();

            // при запуске проверим, что файл существует
            if (File.Exists(filePath))
            {
                // строковая переменная, в которую будем считывать данные
                string stringValue;

                // считываем, после использования высвобождаем задействованный ресурс BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    stringValue = reader.ReadString();
                }

                // Вывод
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(stringValue);
            }


        }
    }
}
