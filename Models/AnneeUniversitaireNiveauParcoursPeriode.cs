using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class AnneeUniversitaireNiveauParcoursPeriode
    {
        public long Id { get; set; }
        public string Periode { get; set; }
        public int NbGroupesC { get; set; }
        public int NbGroupesTd { get; set; }
        public int NbGroupesTp { get; set; }
        public int NbGroupesCi { get; set; }
        public int NbEtudiants { get; set; }
        public long IdFiliere { get; set; }
        public long IdParcours { get; set; }
        public string CodeAnneeUniversitaire { get; set; }
        public long IdNiveau { get; set; }

        public virtual AnneeUniversitaire CodeAnneeUniversitaireNavigation { get; set; }
        public virtual Filiere IdFiliereNavigation { get; set; }
        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual Parcours IdParcoursNavigation { get; set; }
    }
}
