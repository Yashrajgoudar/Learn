namespace OOPSConcept
{
    public class Student
    {
        public string Name;
        public int Age;
        public string Grade;

        // 1. Default Constructor
        public Student()
        {
            Name = "Unknown";
            Age = 0;
            Grade = "Not Assigned";
            Console.WriteLine("Default Constructor Called");
        }

        // 2. Constructor with one parameter
        public Student(string name)
        {
            Name = name;
            Age = 0;
            Grade = "Not Assigned";
            Console.WriteLine("Constructor with 1 parameter Called");
        }

        // 3. Constructor with two parameters
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            Grade = "Not Assigned";
            Console.WriteLine("Constructor with 2 parameters Called");
        }

        // 4. Constructor with all parameters
        public Student(string name, int age, string grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
            Console.WriteLine("Constructor with 3 parameters Called");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Grade: {Grade}");
        }
    }

    public class ProgramConstructorOverloading
    {
        public static void Main()
        {
            Student s1 = new Student();                         // Default constructor
            Student s2 = new Student("Alice");                  // 1 parameter
            Student s3 = new Student("Bob", 20);                // 2 parameters
            Student s4 = new Student("Charlie", 22, "A");       // 3 parameters

            s1.DisplayInfo();
            s2.DisplayInfo();
            s3.DisplayInfo();
            s4.DisplayInfo();
        }
    }

}
