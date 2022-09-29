using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S9000C
{
    public class ServiceSubTest : IServiceSubTest
    {
        public ServiceSubTest(ILogger<ServiceSubTest> log, IConfiguration config)
        {
            _log = log;
            _config = config;
            _log.LogInformation("[MT]\tCreating ServiceSubTest object.");

            _autoResetEvent = new AutoResetEvent(false);
            _sendTimer = new Timer(TimerFunction, _autoResetEvent, 1000, 60000);
        }


        //---------------------------------------------------------------------
        // [[0]] typedef, enum, member variables
        //---------------------------------------------------------------------
        private readonly ILogger<ServiceSubTest> _log;
        private readonly IConfiguration _config;
        private AutoResetEvent _autoResetEvent;
        private Timer _sendTimer;



        //---------------------------------------------------------------------
        // [[1]] Property
        //---------------------------------------------------------------------



        //---------------------------------------------------------------------
        // [[2]] Method
        //---------------------------------------------------------------------
        public void Run()
        {
            _log.LogInformation("[BT]\tServiceSubTest.Run()");
        }

        public void ShowMenu()
        {
            _log.LogInformation("[MT]\tServiceSubTest.showMenu()");
            ConsoleKeyInfo consoleKeyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("    S9000C TEST PROGRAM MENU       ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. Quick Test");
                Console.WriteLine("2. Reserved");
                Console.WriteLine("3. Reserved");
                Console.WriteLine("4. Reserved");
                Console.WriteLine("5. Reserved");
                Console.WriteLine("6. Reserved");
                Console.WriteLine("7. Reserved");
                Console.WriteLine("8. Reserved");
                Console.WriteLine("9. Reserved");
                Console.WriteLine("A. Reserved");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Q. Quit");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("");
                consoleKeyInfo = Console.ReadKey();


                switch (consoleKeyInfo.KeyChar)
                {
                    case '1':
                        QuickTest.showMenu();
                        break;

                    case '2':
                        Console.WriteLine("Reserved...");
                        break;

                    case '3':
                        Console.WriteLine("Reserved...");
                        break;

                    case '4':
                        Console.WriteLine("Reserved...");
                        break;

                    case '5':
                        Console.WriteLine("Reserved...");
                        break;

                    case '6':
                        Console.WriteLine("Reserved...");
                        break;

                    case '7':
                        Console.WriteLine("Reserved...");
                        break;

                    case '8':
                        Console.WriteLine("Reserved...");
                        break;

                    case '9':
                        Console.WriteLine("Reserved...");
                        break;

                    case 'A':
                    case 'a':
                        Console.WriteLine("Reserved...");
                        break;


                    case 'Q':
                    case 'q':
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

            }
            while (consoleKeyInfo.KeyChar != 'Q' && consoleKeyInfo.KeyChar != 'q');
        }



        //---------------------------------------------------------------------
        // [[3]] User-defined functions
        //---------------------------------------------------------------------




        //---------------------------------------------------------------------
        // [[4]] Event Handler, Message Handler, Callback Functions
        //---------------------------------------------------------------------
        public async void TimerFunction(Object stateInfo)
        {
            try
            {
                // no use in current version
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;


                // get configurations from appsettings.json
                bool isRunUploadCheck = _config.GetValue<bool>("IsRunUploadCheck");
                string dataHierFolder = _config.GetValue<string>("DataHierFolder");


                // do something
                if (isRunUploadCheck == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "[UC]\tException occurred on ServiceSubTest class");
            }
            finally
            {

            }
        }



        //---------------------------------------------------------------------
        // [[5]] Override functions
        //---------------------------------------------------------------------
    }
}
