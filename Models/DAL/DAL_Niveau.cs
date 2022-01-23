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
    public class DAL_Niveau
    {
        private static Niveau GetEntityFromDataRow(DataRow dataRow)
        {
            Niveau niveau = new Niveau();
            niveau.Id = (long)(dataRow["Id"] == DBNull.Value ? null : dataRow["Id"]);
            niveau.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            niveau.IntituleAbrege = dataRow["IntituleAbrege"] == DBNull.Value ? null : (string)dataRow["IntituleAbrege"];
            niveau.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            niveau.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            niveau.IdFiliere = (long)(dataRow["IdFiliere"] == DBNull.Value ? null : dataRow["IdFiliere"]);

            return niveau;
        }
        private static List<Niveau> GetListFromDataTable(DataTable dt)
        {
            List<Niveau> list = new List<Niveau>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<Niveau> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM Niveau";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
