using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetService.ClassLibary
{
    public class Procedure
    {
        private int procedureID;
        private string description;
        private decimal price;

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
