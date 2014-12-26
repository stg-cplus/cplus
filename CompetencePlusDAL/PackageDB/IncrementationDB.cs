using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetencePlus.PackageDB
{
   public class IncrementationDB
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        string increment;

        public string Increment
        {
            get { return increment; }
            set { increment = value; }
        }
        string decrement;

        public string Decrement
        {
            get { return decrement; }
            set { decrement = value; }
        }
    }
}
