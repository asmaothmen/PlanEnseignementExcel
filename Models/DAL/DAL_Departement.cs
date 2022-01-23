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
    public class DAL_Departement
    {
        private static Departement GetEntityFromDataRow(DataRow dataRow)
        {
            Departement Dep = new Departement();
            Dep.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            Dep.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            Dep.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            return Dep;
        }
        private static List<Departement> GetListFromDataTable(DataTable dt)
        {
            List<Departement> list = new List<Departement>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<Departement> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM Departement ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
