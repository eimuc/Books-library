namespace BooksLibrary
{
    public class User
    {
        public int Counter { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }

        public User(string name)
        {
            Counter = 1;
            Name = name;
            Days = 0;
        }
    }
}