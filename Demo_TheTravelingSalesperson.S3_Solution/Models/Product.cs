﻿namespace Demo_TheTravelingSalesperson
{
    /// <summary>
    /// Product MVC Model class
    /// </summary>
    public class Product
    {
        #region ENUMERABLES

        public enum ProductType
        {
            NONE,
            FURRY,
            SPOTTED,
            DANCING
        }

        #endregion

        #region FIELDS

        private ProductType _type;
        private int _numberOfUnits;
        private bool _onBackorder;

        #endregion

        #region PROPERTIES

        public ProductType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        //
        // this property is read only 
        // changes in this property are managed by public methods
        //
        public int NumberOfUnits
        {
            get { return _numberOfUnits; }
        }
        
        public bool OnBackorder
        {
            get { return _onBackorder; }
            set { _onBackorder = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Product()
        {
            _type = ProductType.NONE;
            _numberOfUnits = 0;
        }

        public Product(ProductType type, int numberOfUnits, bool onBackorder)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
            _onBackorder = onBackorder;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// add widgets to the inventory
        /// </summary>
        /// <param name="unitsToAdd">number of units to add</param>
        public void AddProducts(int unitsToAdd)
        {
            _numberOfUnits += unitsToAdd;
        }

        /// <summary>
        /// subtract widgets from the inventory
        /// note: when number of units sold exceeds inventory, backorder status set
        /// </summary>
        /// <param name="unitsToSubtract">number of units to subtract</param>
        public void SubtractProducts(int unitsToSubtract)
        {
            if (_numberOfUnits < unitsToSubtract)
            {
                _onBackorder = true;
            }
            _numberOfUnits -= unitsToSubtract;
        }

        #endregion
    }
}
