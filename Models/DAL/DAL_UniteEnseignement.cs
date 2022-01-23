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
    public class DAL_UniteEnseignement
    {
        private static UniteEnseignement GetEntityFromDataRow(DataRow dataRow)
        {
            UniteEnseignement Unite = new UniteEnseignement();
            Unite.IdUniteEnseignement = (long)(dataRow["IdUniteEnseignement"] == DBNull.Value ? null : dataRow["IdUniteEnseignement"]);
            Unite.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            Unite.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            Unite.IntituleAbrg = dataRow["IntituleAbrg"] == DBNull.Value ? null : (string)dataRow["IntituleAbrg"];
            Unite.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            Unite.IdParcours = (long?)(dataRow["IdParcours"] == DBNull.Value ? null : dataRow["IdParcours"]);
            Unite.IdNiveau = (long?)(dataRow["IdNiveau"] == DBNull.Value ? null : dataRow["IdNiveau"]);
            Unite.Periode = Convert.ToInt32(dataRow["Periode"] == DBNull.Value ? null : dataRow["Periode"]);
            Unite.Nature = dataRow["Nature"] == DBNull.Value ? null : (string)dataRow["Nature"];
            Unite.Credits = (float?)(dataRow["Credits"] == DBNull.Value ? null : dataRow["Credits"]);
            Unite.Coefficient = (float?)(dataRow["Coefficient"] == DBNull.Value ? null : dataRow["Coefficient"]);
            return Unite;
        }
        private static List<UniteEnseignement> GetListFromDataTable(DataTable dt)
        {
            List<UniteEnseignement> list = new List<UniteEnseignement>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<UniteEnseignement> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM UniteEnseignement";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}

