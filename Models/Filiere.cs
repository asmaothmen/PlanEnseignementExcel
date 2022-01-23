using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class Filiere
    {
        public Filiere()
        {
            AnneeUniversitaireFiliere = new HashSet<AnneeUniversitaireFiliere>();
            AnneeUniversitaireNiveauParcoursPeriode = new HashSet<AnneeUniversitaireNiveauParcoursPeriode>();
            Niveau = new HashSet<Niveau>();
            Parcours = new HashSet<Parcours>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string IntituleFr { get; set; }
        public string IntituleAr { get; set; }
        public string IntituleAbrege { get; set; }
        public string Domaine { get; set; }
        public string Mention { get; set; }
        public string PeriodeHabilitation { get; set; }
        public int? NombrePeriodes { get; set; }
        public string CodeTypePeriode { get; set; }
        public string CodeDepartement { get; set; }
        public string CodeTypeDiplome { get; set; }

        public virtual Departement CodeDepartementNavigation { get; set; }
        public virtual TypeDiplome CodeTypeDiplomeNavigation { get; set; }
        public virtual TypePeriode CodeTypePeriodeNavigation { get; set; }
        public virtual ICollection<AnneeUniversitaireFiliere> AnneeUniversitaireFiliere { get; set; }
        public virtual ICollection<AnneeUniversitaireNiveauParcoursPeriode> AnneeUniversitaireNiveauParcoursPeriode { get; set; }
        public virtual ICollection<Niveau> Niveau { get; set; }
        public virtual ICollection<Parcours> Parcours { get; set; }
    }
}
