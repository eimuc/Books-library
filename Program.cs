using System;

namespace BooksLibrary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool runApp = true;
            bool welcomeMessage = true;
            string input;
            string[] commands;
            var library = new Library();

            while (runApp)
            {
                try
                {
                    if (welcomeMessage)
                    {
                        Console.WriteLine(Message.Welcome);
                        welcomeMessage = false;
                    }

                    input = Console.ReadLine();
                    commands = input.Split(" ");
                    input = commands[0].ToLower();

                    switch (commands[0])
                    {
                        case "exit":
                            runApp = false;
                            break;

                        case "commands":
                            Console.WriteLine(Message.Commands);
                            break;

                        case "add":
                            var name = commands[1];
                            var author = commands[2];
                            var category = commands[3];
                            var language = commands[4];
                            var date = int.Parse(commands[5]);
                            var isbn = long.Parse(commands[6]);
                            Console.WriteLine(library.Add(name, author, category, language, date, isbn));
                            break;

                        case "take":
                            var takeName = commands[1];
                            var takeUser = commands[2];
                            var days = int.Parse(commands[3]);
                            Console.WriteLine(library.Take(takeName, takeUser, days));
                            break;

                        case "return":
                            var returnName = commands[1];
                            var returnUser = commands[2];
                            Console.WriteLine(library.Return(returnName, returnUser));
                            break;

                        case "list":
                            var filter = commands[1].ToLower();
                            Console.WriteLine(library.List(filter));
                            break;

                        case "delete":
                            var bookName = commands[1];
                            Console.WriteLine(library.Delete(bookName));
                            break;

                        default:
                            throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(Message.UndefinedCommand);
                }
                catch (Exception e)
                {
                    runApp = false;
                    Console.WriteLine(e);
                }
            }
        }
    }
}