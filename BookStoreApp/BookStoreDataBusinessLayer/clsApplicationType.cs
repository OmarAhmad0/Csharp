using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessLayer;

namespace BusinessLayer
{
    public class clsApplictionType
    {
        public int ApplictionTypeID { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }


        public clsApplictionType(int _ID, string _Description, decimal _Fees)
        {
            ApplictionTypeID = _ID;
            Description = _Description;
            Fees = _Fees;
        }

        static public DataTable GetAllAppType()
        {
            return ApplictionsTypes.GetAllApplicationTypes();
        }

        static public clsApplictionType IsExisitAppTypeByID(int AppID)
        {
            string _Description = ""; decimal _Fees = 0;
            if (ApplictionsTypes.FindApplictionTypeByID(AppID, ref _Description, ref _Fees))
            {
                return new clsApplictionType(AppID, _Description, _Fees);
            }
            else
            {
                return null;
            }
        }

        private bool _UpdateAppType()
        {
            return ApplictionsTypes.UpdateAppliction(ApplictionTypeID, Description, Fees);
        }

        public bool Save()
        {
            return _UpdateAppType();
        }
    }
}
