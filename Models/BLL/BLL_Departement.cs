using PlanEnseignementExcel.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.BLL
{
    public class BLL_Departement
    {
        public static List<Departement> GetAll()
        {
            return DAL_Departement.SelectAll();
        }
    }
}
