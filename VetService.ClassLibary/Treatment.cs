using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetService.ClassLibary
{
    public class Treatment
    {
        private string treatmentID;
        private string petID;
        private string petName;
        private int ownerID;
        private int procedureID;
        private DateTime date;
        private string notes;
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public int ProcedureID
        {
            get { return procedureID; }
            set { procedureID = value; }
        }


        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }


        public string PetName
        {
            get { return petName; }
            set { petName = value; }
        }


        public string PetID
        {
            get { return petID; }
            set { petID = value; }
        }


        public string TreatmentID
        {
            get { return treatmentID; }
            set { treatmentID = value; }
        }

    }
}
