using PlanEnseignementExcel.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.BLL
{
    public class BLL_AnneeUniversitaireFiliere
    {
        public static List<AnneeUniversitaireFiliere> GetAll()
        {
            return DAL_AnneeUniversitaireFiliere.SelectAll();
        }
    }
}
