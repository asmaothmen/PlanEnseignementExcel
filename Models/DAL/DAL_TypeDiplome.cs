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
    public class DAL_TypeDiplome
    {
        private static TypeDiplome GetEntityFromDataRow(DataRow dataRow)
        {
            TypeDiplome typeDip = new TypeDiplome();
            typeDip.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            typeDip.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            typeDip.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            typeDip.IntituleAbrg = dataRow["IntituleAbrg"] == DBNull.Value ? null : (string)dataRow["IntituleAbrg"];
            return typeDip;
        }
        private static List<TypeDiplome> GetListFromDataTable(DataTable dt)
        {
            List<TypeDiplome> list = new List<TypeDiplome>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<TypeDiplome> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM TypeDiplome ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
