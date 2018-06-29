using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetService.ClassLibary
{
    public class ProcedureView
    {
        private int procedureID;
        private string description;
        private decimal price;
        private string petID;

        public string PetID
        {
            get { return petID; }
            set { petID = value; }
        }


        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public int ProcedureID
        {
            get { return procedureID; }
            set { procedureID = value; }
        }

    }
}
