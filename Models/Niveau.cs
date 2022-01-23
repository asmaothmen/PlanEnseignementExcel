using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class Niveau
    {
        public Niveau()
        {
            AnneeUniversitaireNiveauParcoursPeriode = new HashSet<AnneeUniversitaireNiveauParcoursPeriode>();
            UniteEnseignement = new HashSet<UniteEnseignement>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string IntituleFr { get; set; }
        public string IntituleAbrege { get; set; }
        public string IntituleAr { get; set; }
        public long? IdFiliere { get; set; }

        public virtual Filiere IdFiliereNavigation { get; set; }
        public virtual ICollection<AnneeUniversitaireNiveauParcoursPeriode> AnneeUniversitaireNiveauParcoursPeriode { get; set; }
        public virtual ICollection<UniteEnseignement> UniteEnseignement { get; set; }
    }
}
