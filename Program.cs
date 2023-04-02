using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Program
    {
        enum Menu
        {
            Capture = 1,
            Check,
            Show,
            Exit
        }

        static void Main(string[] args)
        {
            bool run = true;
            bool number;
            string options;
            int option;
            List<CaptureData> Information = new List<CaptureData>();
            List <String> Stats = new List<String>();

            while (run)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. Capture Details");
                Console.WriteLine("2. Check credit qualification");
                Console.WriteLine("3. Show qualification stats");
                Console.WriteLine("4. Exit");

                Console.WriteLine(Environment.NewLine + "Please choose an option");
                options = Console.ReadLine();

                number = int.TryParse(options, out option);

                if (number == true && option > 0 && option < 5)
                {
                    switch ((Menu)option)
                    {
                        case Menu.Capture:
                            Information = Capture();
                            break;
                        case Menu.Check:
                            Stats = Calculate(Information);
                            break;
                        case Menu.Show:
                            Show(Stats);
                            break;
                        case Menu.Exit:
                            run = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid option");
                            break;
                    }
                }
                else
                {
                    Console.ReadLine();
                }

            }
            Console.ReadLine();

        }

        static List<CaptureData> Capture()
        {
            List<CaptureData> ListInformation = new List<CaptureData>();

            bool add = true;
            string name = "", status = "";
            int yearsjob = 0, yearsresidence = 0, children = 0;
            float salary = 0, debt = 0;
            string option;
            string file = @"Applicants.txt";                // Can't specify speciic location for lecturer computer not the same

            CaptureData information;

            while (add == true)
            {
                Console.WriteLine("Please enter your name");
                name = Console.ReadLine();

                Console.WriteLine("Please enter your employment status");
                status = Console.ReadLine();

                Console.WriteLine("Please enter your years in job (if any)");
                yearsjob = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter years at current residence");
                yearsresidence = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter your monthly salary");
                salary = float.Parse(Console.ReadLine());

                Console.WriteLine("Please enter your amount of non-mortgage debt");
                debt = float.Parse(Console.ReadLine());

                Console.WriteLine("Please enter your number of children");
                children = int.Parse(Console.ReadLine());

                information = new CaptureData(name, status, yearsjob, yearsresidence, children, salary, debt);
                ListInformation.Add(information);

                if (!File.Exists(file))                             
                {
                    File.Create(file);
                    TextWriter tw = new StreamWriter(file);                     
                    tw.WriteLine("Apllicants that applied");
                    tw.WriteLine("_______________________");
                    tw.WriteLine(information.Name+"     "+ information.Status);
                    tw.Close();
                }
                else if (File.Exists(file))
                {
                    TextWriter tw = new StreamWriter(file);
                    tw.WriteLine(information.Name + "     " + information.Status);
                    tw.Close();
                }

                Console.WriteLine("Do you still want to capture any more applicants yes (Y) or no (N)");
                option = Console.ReadLine();

                if (option.ToUpper() == "Y")
                {
                    add = true;
                }
                else if (option.ToUpper() == "N")
                {
                    add = false;
                }
                else
                {
                    Console.WriteLine("Enter Y or N");
                }
            }

            return ListInformation;
        }

        static List<String> Calculate(List<CaptureData> Information)
        {
            List<String> Stats = new List<string>();
            
            int denied = 0;
            int access = 0;

            foreach (var item in Information)
            {
                if (item.Status.ToLower() == "employed" && item.Yearsjob > 1 && item.Yearsresidence > 1 && item.Children<7 && !(item.Debt == 2))
                {
                    Stats.Add(item.Name);
                    access++;
                }
                else if (item.Debt == 2 || item.Children > 6)
                {
                    denied++;
                }
            }
            Console.ReadLine();
            Stats.Add("Qualified:"+Environment.NewLine+access + "    have qualified for credit");
            Stats.Add(denied + "    have not qualified for credit");
            return Stats;
        }

        static void Show(List<String> Stats)
        {
            Console.WriteLine("Credit qualification statistics");
            Console.WriteLine("________________________________");

            foreach (var item in Stats)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }


}
