using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    /// <summary>
    /// MVC Controller class
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private bool _usingApplication;

        //
        // declare ConsoleView and Salesperson objects for the Controller to use
        // Note: There is no need for a Salesperson or ConsoleView property given only the Controller 
        //       will access the ConsoleView object and will pass the Salesperson object to the ConsoleView.
        //
        private ConsoleView _consoleView;
        private Salesperson _salesperson;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            InitializeController();

            //
            // instantiate a Salesperson object
            //
            _salesperson = new Salesperson();

            //
            // instantiate a ConsoleView object
            //
            _consoleView = new ConsoleView();

            //
            // begins running the application UI
            //
            ManageApplicationLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the controller 
        /// </summary>
        private void InitializeController()
        {
            _usingApplication = true;
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageApplicationLoop()
        {
            MenuOption userMenuChoice;

            _consoleView.DisplayWelcomeScreen();

            //
            // application loop
            //
            while (_usingApplication)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (userMenuChoice)
                {
                    case MenuOption.None:
                        break;
                    case MenuOption.SetupAccount:
                        SetupAccount();
                        break;
                    case MenuOption.Travel:
                        Travel();
                        break;
                    case MenuOption.Buy:
                        Buy();
                        break;
                    case MenuOption.Sell:
                        Sell();
                        break;
                    case MenuOption.DisplayInventory:
                        DisplayInventory();
                        break;
                    case MenuOption.DisplayCities:
                        DisplayCities();
                        break;
                    case MenuOption.DisplayAccountInfo:
                        DisplayAccountInfo();
                        break;
                    case MenuOption.SaveAccountInfo:
                        DisplaySaveAccountInfo();
                        break;
                    case MenuOption.LoadAccountInfo:
                        DisplayLoadAccountInfo();
                        break;
                    case MenuOption.Exit:
                        _usingApplication = false;
                        break;
                    default:
                        break;
                }
            }

            _consoleView.DisplayClosingScreen();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        private void SetupAccount()
        {
            _salesperson = _consoleView.DisplaySetupAccount();
        }

        /// <summary>
        /// add the next city location to the list of cities
        /// </summary>
        private void Travel()
        {
            string nextCity = _consoleView.DisplayGetNextCity();

            //
            // do not add empty strings to list for city names
            //
            if (nextCity != "")
            {
                _salesperson.CitiesVisited.Add(nextCity);
            }
        }

        /// <summary>
        /// buy widgets
        /// </summary>
        private void Buy()
        {
            int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToBuy(_salesperson.CurrentStock);
            _salesperson.CurrentStock.AddProducts(numberOfUnits);
        }

        /// <summary>
        /// sell widgets
        /// </summary>
        private void Sell()
        {
            int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToSell(_salesperson.CurrentStock);
            _salesperson.CurrentStock.SubtractProducts(numberOfUnits);

            if (_salesperson.CurrentStock.OnBackorder)
            {
                _consoleView.DisplayBackorderNotification(_salesperson.CurrentStock, numberOfUnits);
            }
        }

        /// <summary>
        /// display inventory
        /// </summary>
        private void DisplayInventory()
        {
            _consoleView.DisplayInventory(_salesperson.CurrentStock);
        }

        /// <summary>
        /// display all cities traveled to
        /// </summary>
        private void DisplayCities()
        {
            _consoleView.DisplayCitiesTraveled(_salesperson);
        }

        /// <summary>
        /// display account information
        /// </summary>
        private void DisplayAccountInfo()
        {
            _consoleView.DisplayAccountInfo(_salesperson);
        }

        /// <summary>
        /// display save account information
        /// </summary>
        private void DisplaySaveAccountInfo()
        {
            bool maxAttemptsExceeded = false;
            bool saveAccountInfo = false;

            saveAccountInfo = _consoleView.DisplaySaveAccountInfo(_salesperson, out maxAttemptsExceeded);

            if (saveAccountInfo && !maxAttemptsExceeded)
            {
                CsvServices csvServices = new CsvServices(DataSettings.dataFilePathCsv);
                csvServices.WriteSalespersonToDataFile(_salesperson);

                _consoleView.DisplayConfirmSaveAccountInfo();
            }
        }

        /// <summary>
        /// display load account information
        /// </summary>
        private void DisplayLoadAccountInfo()
        {
            bool maxAttemptsExceeded = false;
            bool loadAccountInfo = false;

            //
            // note: rather than pass null value, method is overloaded
            //
            if (_salesperson.AccountID != "")
            {
                loadAccountInfo = _consoleView.DisplayLoadAccountInfo(_salesperson, out maxAttemptsExceeded);
            }
            else
            {
                loadAccountInfo = _consoleView.DisplayLoadAccountInfo(out maxAttemptsExceeded);
            }

            if (loadAccountInfo && !maxAttemptsExceeded)
            {
                CsvServices csvServices = new CsvServices(DataSettings.dataFilePathCsv);
                _salesperson = csvServices.ReadSalespersonFromDataFile();

                _consoleView.DisplayConfirmLoadAccountInfo(_salesperson);
            }
        }

        #endregion
    }
}
