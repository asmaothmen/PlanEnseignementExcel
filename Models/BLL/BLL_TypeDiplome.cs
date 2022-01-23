using PlanEnseignementExcel.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.BLL
{
    public class BLL_TypeDiplome
    {
        public static List<TypeDiplome> GetAll()
        {
            return DAL_TypeDiplome.SelectAll();
        }
    }
}
