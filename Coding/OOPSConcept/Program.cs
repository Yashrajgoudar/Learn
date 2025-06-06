using OOPSConcept;

namespace OOPSConcepts
{
    class Program
    {
        public static void main(string[] args) //When you want to use this method change the method name from main to Main.
        {
            // Creating first object of Person class
            ClassAndObjects classAndObjects1 = new ClassAndObjects();
            classAndObjects1.name = "John";
            classAndObjects1.age = 25;
            string intro1 = classAndObjects1.Introduce();
            Console.WriteLine(intro1);

            // Creating second object of Person class
            ClassAndObjects classAndObjects2 = new ClassAndObjects();
            classAndObjects1.name = "Tom";
            classAndObjects1.age = 30;
            string intro2 = classAndObjects1.Introduce();
            Console.WriteLine(intro2);

        }
    }
}