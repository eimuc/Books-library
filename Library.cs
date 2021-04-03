using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace BooksLibrary
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public string Add(string name, string author, string category, string language, int date, long isbn)
        {
            var validBooks = Books.Find(book => book.Name.Equals(name));

            if (validBooks == null)
            {
                if (date.ToString().Length != 4) return "\nDate format is invalid!\n";
                if (isbn.ToString().Length != 10) return "\nISBN must be 10 numbers!\n";

                Books.Add(new Book(name, author, category, language, date, isbn));
                System.IO.File.WriteAllText(@"C:\Users\Eimantas\source\repos\BooksLibrary\books.json", 
                    JsonConvert.SerializeObject(Books));
                return "\nBook was successfully added!\n";
            }
            return "\nBook already exists!\n";
        }

        public string List(string filter)
        {
            var itemList = new StringBuilder();
            foreach (var book in Books)
            {
                if (book.Available)
                {
                    switch (filter)
                    {
                        case "all":
                            itemList.Append($"\n{book.Name} {book.Author} {book.Category} {book.Language} " +
                                $"{book.Date} {book.ISBN}\n");
                            break;

                        case "author":
                            itemList.Append($"\n{book.Author}\n");
                            break;

                        case "category":
                            itemList.Append($"\n{book.Category}\n");
                            break;

                        case "language":
                            itemList.Append($"\n{book.Language}\n");
                            break;

                        case "isbn":
                            itemList.Append($"\n{book.ISBN}\n");
                            break;

                        case "name":
                            itemList.Append($"\n{book.Name}\n");
                            break;

                        case "available":
                            itemList.Append($"\n{book.Available}\n");
                            break;
                    }
                }
            }
            return itemList.Length > 0 ? itemList.ToString() : "\nNo books in the library!\n";
        }

        public string Delete(string name)
        {
            var bookToRemove = Books.Find(book => book.Name == name);

            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                return "\nBook was successfully deleted!\n";
            }
            else
            {
                return "\nBook has already been removed!\n";
            }
        }

        public string Take(string name, string userName, int days)
        {
            var validName = Books.Find(book => book.Name.Equals(name));
            var isValid = Books.Find(x => x.Name == name).Available;
            var validUser = Users.Find(user => user.Name.Equals(userName));

            if (validName != null && isValid == true)
            {
                if (validUser == null)
                {
                    var newUser = new User(userName);
                    Users.Add(newUser);
                }
                else
                {
                    Users.Find(user => user.Name == userName).Counter++;
                }
                foreach (var user in Users)
                {
                    if (user.Counter > 3) return "\nYou can take only 3 books!\n";
                }
                if (days > 60) return "\nBook can be taken for maximum 60 days!\n";

                Books.Find(x => x.Name == name).Available = false;
                Users.Find(user => user.Name == userName).Days = days;
                return $"\nThanks for taking {name}!\n";
            }
            return "\nBook is not in the library!\n";
        }

        public string Return(string name, string userName)
        {
            var validName = Books.Find(book => book.Name.Equals(name));
            var isValid = Books.Find(book => book.Name == name).Available;
            var validUser = Users.Find(user => user.Name.Equals(userName));
            var validDays = Users.Find(user => user.Name == userName).Days;

            if (validName != null && isValid == false)
            {
                Books.Find(book => book.Name == name).Available = true;
                return $"\nThanks for returning {name}!\n";
            }
            return "\nBook has already been returned!!\n";
        }
    }
}

// add Titanic JohnSnow Romance English 2010 5458569874