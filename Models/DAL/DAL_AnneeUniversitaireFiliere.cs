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
    public class DAL_AnneeUniversitaireFiliere
    {
        private static AnneeUniversitaireFiliere GetEntityFromDataRow(DataRow dataRow)
        {
            AnneeUniversitaireFiliere anneeFiliere = new AnneeUniversitaireFiliere();
            anneeFiliere.CodeAnneeUniversitaire = dataRow["CodeAnneeUniversitaire"] == DBNull.Value ? null : (string)dataRow["CodeAnneeUniversitaire"];
            anneeFiliere.IdFiliere = (long)(dataRow["IdFiliere"] == DBNull.Value ? null : dataRow["IdFiliere"]);
            anneeFiliere.Id = (long)(dataRow["Id"] == DBNull.Value ? null : dataRow["Id"]);

            return anneeFiliere;
        }
        private static List<AnneeUniversitaireFiliere> GetListFromDataTable(DataTable dt)
        {
            List<AnneeUniversitaireFiliere> list = new List<AnneeUniversitaireFiliere>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<AnneeUniversitaireFiliere> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM AnneeUniversitaireFiliere ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}