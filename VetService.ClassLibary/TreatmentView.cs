using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetService.ClassLibary
{
    public class TreatmentView
    {
        private string petName;
        private string type;
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

        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public string PetName
        {
            get { return petName; }
            set { petName = value; }
        }

    }
}
