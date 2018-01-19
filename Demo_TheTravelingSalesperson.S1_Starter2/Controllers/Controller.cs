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


            //
            // instantiate a ConsoleView object
            //


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

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// add the next city location to the list of cities
        /// </summary>
        private void Travel()
        {

        }

        /// <summary>
        /// display all cities traveled to
        /// </summary>
        private void DisplayCities()
        {

        }

        /// <summary>
        /// display account information
        /// </summary>
        private void DisplayAccountInfo()
        {

        }

        #endregion
    }
}
