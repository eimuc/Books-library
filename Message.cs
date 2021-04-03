using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    public class Message
    {
        public const string Pattern = "============================================";

        public const string Welcome = Pattern + "\n\tWelcome to the Book Library!\n" + Pattern
            + "\n\nType \"commands\" or \"exit\":\n";

        public const string Commands = "\n1. add \"name\" \"author\" \"category\" \"language\" \"date\" \"isbn\"\nExample: " +
            "add Titanic JohnSnow Romance English 2010 5452569856\n(date must be 4 numbers, isbn 10 numbers!)\n\n" +
            "2. take \"name\" \"username\"\nExample: take Titanic DavidLee\n\n3. return \"name\" \"username\"\nExample: return Titanic " +
            "DavidLee\n\n4. list \"filtername\" - all, author, category, language, isbn, name, available\nExample: " +
            "list author\n\n5. delete \"name\"\nExample: delete Titanic\n\n";

        public const string UndefinedCommand = "\nInccorect command, please try again!\n";
    }
}
