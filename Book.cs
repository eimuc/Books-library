namespace BooksLibrary
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int Date { get; set; }
        public long ISBN { get; set; }
        public bool Available { get; set; }

        public Book(string name, string author, string category, string language, int date,
            long isbn, bool available = true)
        {
            Name = name;
            Author = author;
            Category = category;
            Language = language;
            Date = date;
            ISBN = isbn;
            Available = available;
        }
    }
}