using PlanEnseignementExcel.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.BLL
{
    public class BLL_TypePeriode
    {
        public static List<TypePeriode> GetAll()
        {
            return DAL_TypePeriode.SelectAll();
        }
    }
}
