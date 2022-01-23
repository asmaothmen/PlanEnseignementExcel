using Microsoft.Data.SqlClient;
using PlanEnseignement.Utilities;
using PlanEnseignementExcel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PlanEnseignement.Models.DAL
{
    public class DAL_Parcours
    {
        private static Parcours GetEntityFromDataRow(DataRow dataRow)
        {
            Parcours parcours = new Parcours();
            parcours.Id = (long)(dataRow["Id"] == DBNull.Value ? null : dataRow["Id"]);
            parcours.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            parcours.IdFiliere = (long)(dataRow["IdFiliere"] == DBNull.Value ? null : dataRow["IdFiliere"]);
            parcours.IntituleAbrg = dataRow["IntituleAbrg"] == DBNull.Value ? null : (string)dataRow["IntituleAbrg"];
            parcours.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            parcours.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            parcours.PeriodeHabilitation = dataRow["PeriodeHabilitation"] == DBNull.Value ? null : (string)dataRow["PeriodeHabilitation"];
            parcours.PeriodeDebut = dataRow["PeriodeDebut"] == DBNull.Value ? null : (string)dataRow["PeriodeDebut"];
            parcours.PeriodeFin = dataRow["PeriodeFin"] == DBNull.Value ? null : (string)dataRow["PeriodeFin"];

            return parcours;
        }
        private static List<Parcours> GetListFromDataTable(DataTable dt)
        {
            List<Parcours> list = new List<Parcours>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<Parcours> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM Parcours ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
