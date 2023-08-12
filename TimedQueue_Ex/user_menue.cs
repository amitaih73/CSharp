using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;

namespace timedQueue_Ex_
{
    class UserMenue
    {
        static public void Add(string a_message, int a_delayTime, ref TimeQueue a_queueMessage)
        {
            a_queueMessage.Enqueue(new Node(a_message, a_delayTime));
        }

        static public void Show(Node a_data)
        {
            int delayMilliseconds = a_data.DelayTime();
            System.Threading.Thread.Sleep(delayMilliseconds);
            Console.WriteLine(a_data.Message());
        }



        static string Exit()
        {
            return "exit";
        }

    }
    class Test
    {
        static public void Main()
        {
            TimeQueue timeQAueue = new TimeQueue();
            Console.WriteLine("welcome to queue message");
            while (true) {
                int choice = 0;
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. to Add messaage");
                Console.WriteLine("2. to show message");
                Console.WriteLine("3. to Exit program");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
                else if (choice == 1)
                {
                    Console.WriteLine("insert your message");
                    string message = Console.ReadLine();
                    UserMenue.Add(message, 10, ref timeQAueue);

                }
                else if (choice == 2)
                {
                    UserMenue.Show(timeQAueue.Dequeue().Data);
                }
                else if (choice == 3)
                {
                    return;
                }
            }
        }
    }
}
