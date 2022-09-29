using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;


namespace S9000C
{
    class QuickTest
    {
        public static void showMenu()
        {
            ConsoleKeyInfo consoleKeyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("+-----------------------------------------------+");
                Console.WriteLine("|            QUICK TEST PROGRAM MENU            |");
                Console.WriteLine("+-----------------------------------------------+");
                Console.WriteLine("1. General Quick Test");
                Console.WriteLine("2. Reserved");
                Console.WriteLine("3. Reserved");
                Console.WriteLine("4. Reserved");
                Console.WriteLine("5. Reserved");
                Console.WriteLine("6. Reserved");
                Console.WriteLine("7. Reserved");
                Console.WriteLine("8. Reserved");
                Console.WriteLine("9. Reserved");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("E. Exit to Main Menu");
                Console.WriteLine("Q. Quit");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("");
                consoleKeyInfo = Console.ReadKey();


                switch (consoleKeyInfo.KeyChar)
                {
                    case '1':
                        GeneralQuickTest();
                        break;

                    case '2':
                        Console.WriteLine("Reserved Test");
                        break;

                    case '3':
                        Console.WriteLine("Reserved Test");
                        break;

                    case '4':
                        Console.WriteLine("Reserved Test");
                        break;

                    case '5':
                        Console.WriteLine("Reserved Test");
                        break;

                    case 'E':
                    case 'e':
                        break;

                    case 'Q':
                    case 'q':
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

            }
            while (consoleKeyInfo.KeyChar != 'E' && consoleKeyInfo.KeyChar != 'e');

        }

        
        
        static public void GeneralQuickTest()
        {
            Console.Clear();
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine("|              GENERAL QUICK TEST               |");
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine("");


            Console.Write("Press any key to continue....");
            Console.ReadKey();
        }
    }
}
