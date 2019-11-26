using System;

namespace Lab_11_Delegates
{
    class Program
    {
        // matchning delegate 
        public delegate void Delegate01();

        // non-trivial delegate
        delegate int Delegate02(int x);
        static void Main(string[] args)
        {
            // dalegate can bbe referenced as a class
            // use new keyword

            var delegateInstance = new Delegate01(MyMethod01);

            // cal the delegate instances
            delegateInstance(); // call the method
            // trivial cases can be simplify (same result)
            Delegate01 delegateInstance2 = MyMethod01; // same as the above
            delegateInstance2(); // call

            // final trival case
            // action DELEGATE IS VOID AND TAKES NO PARAMETERS
            Action delegateInstance03 = MyMethod01; // same as the above
            delegateInstance03();

            //  Action delegateInstance4 = MyMethod02;  <-- will never work because of the type delegate does not have return type
            // whereas MyMethod 02 does have a return type of string.

            Delegate02 delegateInstance4 = (x) => { return (x * x * x); };  // LAMBDA
                                                                            // INPUT PARAMS   { // CODE BODY } 
            Delegate02 delegateInstance5 = x => (x * x * x);  //  EASIER WAY OF IMPLEMENTING LAMBDA


            checked
            {
                Console.WriteLine(MyMethod03(delegateInstance5(delegateInstance5(10))));

            }
        }

        static void MyMethod01() 
        {
            Console.WriteLine("Running method01");
        }

        static string MyMethod02()
        {
            return "Running method02";
        }

        static int MyMethod03(int x) 
        {
            return x * x;
        }
    }
}
