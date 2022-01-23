using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class AnneeUniversitaire
    {
        public AnneeUniversitaire()
        {
            AnneeUniversitaireFiliere = new HashSet<AnneeUniversitaireFiliere>();
            AnneeUniversitaireNiveauParcoursPeriode = new HashSet<AnneeUniversitaireNiveauParcoursPeriode>();
            AnneeUniversitaireNomOption = new HashSet<AnneeUniversitaireNomOption>();
        }

        public string Code { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string EtatPlanEtudes { get; set; }
        public string EtatCharges { get; set; }

        public virtual ICollection<AnneeUniversitaireFiliere> AnneeUniversitaireFiliere { get; set; }
        public virtual ICollection<AnneeUniversitaireNiveauParcoursPeriode> AnneeUniversitaireNiveauParcoursPeriode { get; set; }
        public virtual ICollection<AnneeUniversitaireNomOption> AnneeUniversitaireNomOption { get; set; }
    }
}
