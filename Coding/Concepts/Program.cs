
namespace BasicConcepts
{
    class Program
    {
        public void NumericDataTypes()
        {
            int x = 10, y = 20;
            long a = 20000000;
            double d = 30.3;
            float f = 1.0f;
            decimal m = 14.99M;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(a);
            Console.WriteLine(d);
            Console.WriteLine(f);
            Console.WriteLine(m);
        }

        public void StringDataTypes()
        {
            string name = "John";
            char letter = 'a';

            string textAge = "-23";
            string textLong = "200000000000";
            string textDouble = "30.3";
            string textFloat = "1.3";
            string textDecimal = "14.99";

            int age = Convert.ToInt32(textAge);   //Convert string to integer
            long a = Convert.ToInt64(textLong);   //Convert string to long
            double d = Convert.ToDouble(textDouble);   //Convert string to long
            float f = Convert.ToSingle(textFloat);   //Convert string to long
            decimal m = Convert.ToDecimal(textDecimal);   //Convert string to long


            Console.WriteLine(name);
            Console.WriteLine(letter);
            Console.WriteLine(age);
            Console.WriteLine(a);
            Console.WriteLine(d);
            Console.WriteLine(f);
            Console.WriteLine(m);
        }

        public void BoolDataTypes()
        {
            bool b = true;
            bool c = false;
            Console.WriteLine(b);
            Console.WriteLine(c);
            b= false;
            Console.WriteLine(b);
        }

        public void VarConstDataType()
        {
            var age = 10; //Implicit type. Compiler will find out the data type based on the value initialized to it.
            int x;      //For exlicit type we can declare a variable first and later we can initialize it but for var type it will throw error if we do notinitialize any value.
            //Example var age; will throw error.

            const int vat = 20;

            Console.WriteLine(age);
            Console.WriteLine(vat);
        }

        public void Operators()
        {
            //Arithmetic Operators
            int a = 10, b = 20;
            Console.WriteLine(a+b);     //Add
            Console.WriteLine(a-b);     //Sub
            Console.WriteLine(a*b);     //Multiply
            Console.WriteLine(a/b);     //Divide
            Console.WriteLine(a%b);     //Remainder (Modulus)
            double c = a / b;  //We can seperately store the calculated value in a variable;
            double age = 23;
            age /= 10;  //Shorthand for age = age/10
            Console.WriteLine(c);
            Console.WriteLine(age);

            //Type Casting
            double cast = (double) a/b;  //Explicit casting to get the required 0.5 value since both a and b are int and the operation output will be int.
            Console.WriteLine(cast);

            //Increment or Decrement Operators            
            Console.WriteLine(a++);  //First Use the value and then increment it. It will print 10 but it has been incremented to 11
            Console.WriteLine(++a);  //First Increment the value and then use it. It will print 12 because we had incremented in the previous step.
            Console.WriteLine(a--);
            Console.WriteLine(--a);

            //Comparison Operator
            Console.WriteLine(a==b);    //Equality
            Console.WriteLine(a!=b);    //Inequality
            Console.WriteLine(a>b);     //Greater than
            Console.WriteLine(a<b);     //Lesser than
            Console.WriteLine(a>=b);    //Greater or equal
            Console.WriteLine(a<=b);    //Lesser or equal
        }

        //Main entry point of a Program.
        public static void Main(string[] args)
        {
            Program program = new Program();
            //program.NumericDataTypes();
            //program.StringDataTypes();
            program.Operators();
        }
    }
}