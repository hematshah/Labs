using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace Lab_16_Tasks
{
    class Program
    {
      static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
           
            s.Start();

            var task01 = Task.Run(() => {
                Console.WriteLine("Task01 is running");
                Console.WriteLine($"Task01 completed at time {s.ElapsedMilliseconds}");
               
            });

            // old fashioned way of putting a DELEGATE AS A PARAMETER INTO A TASK
            var actionDelegate = new Action(SpecialActionMethod);
            var task02 = new Task(actionDelegate);
            task02.Start();

            Task[] taskArray = new Task[] // do a hjob eg overnight processing task
            {
                new Task(        () => {}    ),
                new Task(        () => {}    ),
                new Task(        () => {}    ),
                new Task(        () => {}    ),
                new Task(        () => {}    ),
                new Task(        () => {}    )
            };

            foreach (var task in taskArray)
            {
                task.Start();
            }

            // second way
            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() => {
                Thread.Sleep(300);
                Console.WriteLine($"Array Task 0 completing at: {s.ElapsedMilliseconds}");
            });
            //taskArray2 = new Task[3];
            taskArray2[1] = Task.Run(() => {
                Thread.Sleep(200);
                Console.WriteLine($"Array Task 1 completing at: {s.ElapsedMilliseconds}");
            });
           // taskArray2 = new Task[3];
            taskArray2[2] = Task.Run(() => {
                Thread.Sleep(100);
                Console.WriteLine($"Array Task 2 completing at: {s.ElapsedMilliseconds}");
            });


            // wait for one or all array takes to complete
            Task.WaitAny(taskArray2);
            Console.WriteLine($"waiting for first array task to complete at: {s.ElapsedMilliseconds} ");

            // wait for all
            Task.WaitAll(taskArray2);
            Console.WriteLine($"waiting for ALL array task to complete at: {s.ElapsedMilliseconds} ");

            // parallel foreach loop
            var x = s.ElapsedMilliseconds;
            int [] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            // REGULAR FOREACH IS IN ORDER 1...2...3..4..
            // PARALLEL FOREACH JUST KICKS OFF X JOBS AT THE SAME TIME, WAIT FOR ANSWERS
            Parallel.ForEach(myCollection, (item) => {
                Thread.Sleep(item * 100);
                Console.WriteLine($"for each loop item{item} finishing at time: {s.ElapsedMilliseconds}");
            
            }); // fill in one parameter for arrys as it takes multiple values
            Console.WriteLine($"Async loop took{s.ElapsedMilliseconds - x}  ");

            // contrast with sync loop
            var t = s.ElapsedMilliseconds;
            Console.WriteLine($"\n\nNow run as  Sync Loop and starting at time {s.ElapsedMilliseconds}\n");
            foreach (var item in myCollection)
            {
               // Thread.Sleep(item * 100);
                Console.WriteLine($"Sync Foreach Loop item {item} items finishing at time: {s.ElapsedMilliseconds}");
            }
            Console.WriteLine($"My Sync loop took {s.ElapsedMilliseconds-t}");

            // ALSO POWERFUL IS PARALLEL LINQ : DATABASE QUERIES IN PARALLEL
            // FAKE IT HERE : USE LOCAL COLLECTION

            var databaseoutput =
                        (from item in myCollection
                         select item).AsParallel().ToList();
            // could use this on real database query if many queries and each one possibly takes a long time.


            // getting data back from tasks
            var taskWithoutReturningData = new Task(()=> { });
            var TaskWithReturningData = new Task<int>(()=>{

                int total = 0;
                for (int i = 0; i < 100; i++)
                {
                    total += i;
                }

                return total;
            
            });

            TaskWithReturningData.Start(); // always start the task by writing start();


            Console.WriteLine($"I have counted to 100 using a background task so  idon't have"); // check phill notes



            Console.WriteLine($"Main Method : all task completed at time: {s.ElapsedMilliseconds} millisecond to complete");
            // one thick  is 10  to the poer -7 seconds ie 0.1 micro second
           // Console.WriteLine($"Application had finished at the time {s.ElapsedTicks}");
            Console.ReadLine();

            // data type
            int num01 = 1_000_000_000; // a new way of writing big numbers

            // hex
            int num02 = 0x_FF_01;

            // binary
            int num03 = 0b_0101_1100;
            
        }


        static void SpecialActionMethod() 
        {
            Console.WriteLine("This Action Method takes no parameters , returns  nothing , but just" + 
                "performs an action in this case print out ...");
            var total = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                total += i;
            }
            Console.WriteLine(total);
            Thread.Sleep(500);
            Console.WriteLine($"special action method completing at {s.ElapsedMilliseconds}");
        }
    }
}
