using PlanEnseignementExcel.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.BLL
{
    public class BLL_AnneeUniversitaire
    {
        public static List<AnneeUniversitaire> GetAll()
        {
            return DAL_AnneeUniversitaire.SelectAll();
        }
    }
}
