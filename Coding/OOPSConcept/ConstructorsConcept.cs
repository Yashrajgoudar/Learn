namespace OOPSConcept
{
    public class ConstructorsConcept
    {
        public string? Title;
        public string? Author;
        public static int BookCount;

        //Default Constructor
        public ConstructorsConcept()
        {
            Title = "Untitled";
            Author = "Unknown";
            Console.WriteLine("Default Constructor Called");
            BookCount++;
        }

        //Parameterized Constructor
        public ConstructorsConcept(string title, string author)
        {
            Title= title;
            Author= author;
            Console.WriteLine("Parameterized Constructor Called");
            BookCount++;
        }

        //Copy Constructor
        public ConstructorsConcept(ConstructorsConcept constructorsConcept)
        {
            Title = constructorsConcept.Title;
            Author = constructorsConcept.Author;
            Console.WriteLine("Copy Constructor Called");
            BookCount++;
        }

        //Static Constructor
        static ConstructorsConcept()
        {
            BookCount = 0;
            Console.WriteLine("Static Constructor Called - BookCount Initialized");
        }

        // Method to display book info
        public void Display()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}");
        }
    }

    public class Program
    {
        public static void main()   //When you want to use this method change the method name from main to Main.
        {
            Console.WriteLine("--- Creating book1 using Default Constructor ---");
            ConstructorsConcept book1 = new ConstructorsConcept(); // Calls Default Constructor
            book1.Display();

            Console.WriteLine("\n--- Creating book2 using Parameterized Constructor ---");
            ConstructorsConcept book2 = new ConstructorsConcept("Atomic Habits", "James Clear"); // Calls Parameterized Constructor
            book2.Display();

            Console.WriteLine("\n--- Creating book3 using Copy Constructor ---");
            ConstructorsConcept book3 = new ConstructorsConcept(book2); // Calls Copy Constructor
            book3.Display();

            Console.WriteLine($"\nTotal Books Created: {ConstructorsConcept.BookCount}");
        }
    }
}
