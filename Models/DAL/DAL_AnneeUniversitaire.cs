using Microsoft.Data.SqlClient;
using PlanEnseignement.Models.DAL;
using PlanEnseignement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Models.DAL
{
    public class DAL_AnneeUniversitaire
    {
        private static AnneeUniversitaire GetEntityFromDataRow(DataRow dataRow)
        {
            AnneeUniversitaire anneeUni = new AnneeUniversitaire();
            anneeUni.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            anneeUni.EtatPlanEtudes = dataRow["EtatPlanEtudes"] == DBNull.Value ? null : (string)dataRow["EtatPlanEtudes"];
            anneeUni.EtatCharges = dataRow["EtatCharges"] == DBNull.Value ? null : (string)dataRow["EtatCharges"];
            anneeUni.DateFin = (DateTime)(dataRow["DateFin"] == DBNull.Value ? null : dataRow["DateFin"]);
            anneeUni.DateDebut = (DateTime)(dataRow["(DateTime)"] == DBNull.Value ? null : dataRow["(DateTime)"]);
            return anneeUni;
        }
        private static List<AnneeUniversitaire> GetListFromDataTable(DataTable dt)
        {
            List<AnneeUniversitaire> list = new List<AnneeUniversitaire>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<AnneeUniversitaire> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM AnneeUniversitaire ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}