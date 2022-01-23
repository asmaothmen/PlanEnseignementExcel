using PlanEnseignementExcel.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.BLL
{
    public class BLL_AnneeUniversitaireNomOption
    {
        public static List<AnneeUniversitaireNomOption> GetAll()
        {
            return DAL_AnneeUniversitaireNomOption.SelectAll();
        }
    }
}
