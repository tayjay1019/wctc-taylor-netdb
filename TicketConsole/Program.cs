using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            int ticketNumber = -1;
            do
            {
                // ask user a question
                Console.WriteLine("1) View Current Tickets.");
                Console.WriteLine("2) Create another ticket item.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    if(File.Exists(file))
                    {
                        
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            String[] arr = line.Split(',');
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                            ticketNumber++;
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("No File found");
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file, true);
                    Boolean cont = true;
                    do
                    {
                        Console.WriteLine("Enter a new ticket (Y/N)?");
                        String resp = Console.ReadLine().ToUpper();
                        if (resp != "Y") { break; }
                        Console.WriteLine("Please enter a summary -");
                        String smry = Console.ReadLine();
                        String status = "Open";
                        Console.WriteLine("Please enter a priority level -");
                        String level = Console.ReadLine();
                        Console.WriteLine("Please enter your name -");
                        String submitName = Console.ReadLine();
                        Console.WriteLine("Please enter who this is assigned to -");
                        String asgn = Console.ReadLine();
                        Console.WriteLine("Please enter the names of others watching this ticket (Use a | inbetween each name");
                        String watchers = Console.ReadLine();
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketNumber, smry, status, level, submitName, asgn, watchers);
                    } while (cont == true);
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");

         }
    }
}
