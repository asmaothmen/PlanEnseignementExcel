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
    public class DAL_AnneeUniversitaireNiveauParcoursPeriode
    {
        private static AnneeUniversitaireNiveauParcoursPeriode GetEntityFromDataRow(DataRow dataRow)
        {
            AnneeUniversitaireNiveauParcoursPeriode Unite = new AnneeUniversitaireNiveauParcoursPeriode();
          
            Unite.Id =(long)( dataRow["Id"] == DBNull.Value ? null : dataRow["Id"]);
            Unite.IdFiliere= (long)(dataRow["IdFiliere"] == DBNull.Value ? null : dataRow["IdFiliere"]);
            Unite.NbGroupesCi = int.Parse(dataRow["NbGroupesCi"] == DBNull.Value ? null : (string)dataRow["NbGroupesCi"]);
            Unite.NbGroupesTp = int.Parse(dataRow["NbGroupesTp"] == DBNull.Value ? null : (string)dataRow["NbGroupesTp"]);
            Unite.NbGroupesTd = int.Parse(dataRow["NbGroupesTd"] == DBNull.Value ? null : (string)dataRow["NbGroupesTd"]);
            Unite.NbGroupesC = int.Parse(dataRow["NbGroupesC"] == DBNull.Value ? null : (string)dataRow["NbGroupesC"]);
            Unite.NbEtudiants = int.Parse(dataRow["NbEtudiants"] == DBNull.Value ? null : (string)dataRow["NbEtudiants"]);
            Unite.IdParcours = (long)(dataRow["IdParcours"] == DBNull.Value ? null : dataRow["IdParcours"]);
            Unite.IdNiveau = (long)(dataRow["IdNiveau"] == DBNull.Value ? null : dataRow["IdNiveau"]);
            Unite.Periode = dataRow["Periode"] == DBNull.Value ? null : (string)dataRow["Periode"];
            Unite.CodeAnneeUniversitaire = dataRow["CodeAnneeUniversitaire"] == DBNull.Value ? null : (string)dataRow["CodeAnneeUniversitaire"];
            return Unite;
        }
        private static List<AnneeUniversitaireNiveauParcoursPeriode> GetListFromDataTable(DataTable dt)
        {
            List<AnneeUniversitaireNiveauParcoursPeriode> list = new List<AnneeUniversitaireNiveauParcoursPeriode>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }
        public static List<AnneeUniversitaireNiveauParcoursPeriode> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM AnneeUniversitaireNiveauParcoursPeriode";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
