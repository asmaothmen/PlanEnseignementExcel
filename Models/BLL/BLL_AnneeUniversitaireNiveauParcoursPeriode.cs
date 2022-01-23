using PlanEnseignementExcel.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.BLL
{
    public class BLL_AnneeUniversitaireNiveauParcoursPeriode
    {
        public static List<AnneeUniversitaireNiveauParcoursPeriode> GetAll()
        {
            return DAL_AnneeUniversitaireNiveauParcoursPeriode.SelectAll();
        }
    }
}
