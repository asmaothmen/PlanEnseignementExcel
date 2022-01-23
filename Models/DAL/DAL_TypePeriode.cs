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
    public class DAL_TypePeriode
    {
        private static TypePeriode GetEntityFromDataRow(DataRow dataRow)
        {
            TypePeriode typePeriode = new TypePeriode();
            typePeriode.Code = dataRow["Code"] == DBNull.Value ? null : (string)dataRow["Code"];
            typePeriode.IntituleAr = dataRow["IntituleAr"] == DBNull.Value ? null : (string)dataRow["IntituleAr"];
            typePeriode.IntituleFr = dataRow["IntituleFr"] == DBNull.Value ? null : (string)dataRow["IntituleFr"];
            typePeriode.IntituleAbrg = dataRow["IntituleAbrg"] == DBNull.Value ? null : (string)dataRow["IntituleAbrg"];
            typePeriode.Type = dataRow["Type"] == DBNull.Value ? null : (string)dataRow["Type"];
            return typePeriode;
        }
        private static List<TypePeriode> GetListFromDataTable(DataTable dt)
        {
            List<TypePeriode> list = new List<TypePeriode>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<TypePeriode> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM TypePeriode ";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}