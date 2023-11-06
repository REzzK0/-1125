using System;
using System.Collections.Generic;
using System.IO;

namespace StudentExcuses
{
    class Program
    {
        static List<string> excuses = new List<string>();

        static void Main(string[] args)
        {
            LoadExcusesFromFile();

            while (true)
            {
                Console.WriteLine("Введите команду:");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "exit":
                        SaveExcusesToFile();
                        return;
                    case "create":
                        AddExcuse();
                        break;
                    case "list":
                        PrintExcuses();
                        break;
                    case "help":
                        PrintRandomExcuse();
                        break;
                    default:
                        Console.WriteLine("Нет такой команды. Введите одну из следующих команд: exit, create, list, help");
                        break;
                }
            }
        }


        static void AddExcuse()
        {
            Console.WriteLine("ну придумывай отмазку, братитк:");
            string newExcuse = Console.ReadLine();
            excuses.Add(newExcuse);
            Console.WriteLine("Еще одна причина не идти добавлена!");
        }


        static void PrintExcuses()
        {
            if (excuses.Count == 0)
            {
                Console.WriteLine("Ничего нет");
            }
            else
            {
                Console.WriteLine("твои отмазки, братик:");
                foreach (string excuse in excuses)
                {
                    Console.WriteLine(excuse);
                }
            }
        }


        static void PrintRandomExcuse()
        {
            if (excuses.Count == 0)
            {
                Console.WriteLine("Ничего нет");
            }
            else
            {
                Random random = new Random();
                int index = random.Next(excuses.Count);
                Console.WriteLine("Случайная отмазка: " + excuses[index]);
            }
        }


        static void LoadExcusesFromFile()
        {
            if (File.Exists("excuses.txt"))
            {
                string[] lines = File.ReadAllLines("excuses.txt");

                foreach (string line in lines)
                {
                    excuses.Add(line);
                }
            }
        }


        static void SaveExcusesToFile()
        {
            File.WriteAllLines("excuses.txt", excuses);
        }
    }
}