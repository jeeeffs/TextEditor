using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Open file");
            Console.WriteLine("2 - Create new file");
            Console.WriteLine("3 - Exit");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: Open(); break;
                case 2: Edit(); break;
                case 3: Exit(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("What is the file path?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Enter your text below (ESC for Exit");
            Console.WriteLine("---------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape); //Enquanto o usuário não pressionar a tecla ESC, ele não vai sair de looping de repetição.

            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Which path to save the file?");
            var path = Console.ReadLine();
            using (var file = new StreamWriter(path))  //Fará com que o arquivo sempre seja fechado após o uso
            {
                file.Write(text);
            }

            Console.WriteLine($"File {path} saved successfully!");
            Console.ReadLine();
            Menu();
        }
        static void Exit()
        {
            System.Environment.Exit(0);
        }
    }
}