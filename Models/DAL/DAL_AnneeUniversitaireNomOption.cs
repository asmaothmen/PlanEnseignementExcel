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
    public class DAL_AnneeUniversitaireNomOption
    {
        private static AnneeUniversitaireNomOption GetEntityFromDataRow(DataRow dataRow)
        {
            AnneeUniversitaireNomOption AnneeOption = new AnneeUniversitaireNomOption();
            AnneeOption.CodeAnneeUniversitaire = dataRow["CodeAnneeUniversitaire"] == DBNull.Value ? null : (string)dataRow["CodeAnneeUniversitaire"];
            AnneeOption.Intitule = dataRow["Intitule"] == DBNull.Value ? null : (string)dataRow["Intitule"];
            AnneeOption.Id = (long)(dataRow["Id"] == DBNull.Value ? null : dataRow["Id"]);
            AnneeOption.IntituleAbrg = dataRow["IntituleAbrg"] == DBNull.Value ? null : (string)dataRow["IntituleAbrg"];
           
            return AnneeOption;
        }
        private static List<AnneeUniversitaireNomOption> GetListFromDataTable(DataTable dt)
        {
            List<AnneeUniversitaireNomOption> list = new List<AnneeUniversitaireNomOption>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<AnneeUniversitaireNomOption> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM AnneeUniversitaireNomOption ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}