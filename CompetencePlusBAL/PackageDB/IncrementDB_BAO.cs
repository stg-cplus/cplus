using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetencePlus.PackageDB
{
   public class IncrementDB_BAO : IncrementDB_DAO
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="IncDB"></param>
       /// <exception cref="IOException">This exception is thrown if the archive already exists</exception>
       public void Add(IncrementationDB IncDB)   
       {
           DateTime date = DateTime.Now;
           IncDB.DateCreation = date;
           IncDB.Code = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Second + "-" + IncDB.Titre.Trim();
           base.Add(IncDB);
       }



       
    }
}
