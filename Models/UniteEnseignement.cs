using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class UniteEnseignement
    {
        public UniteEnseignement()
        {
            Module = new HashSet<Module>();
        }

        public long IdUniteEnseignement { get; set; }
        public string Code { get; set; }
        public string IntituleFr { get; set; }
        public int Periode { get; set; }
        public string Nature { get; set; }
        public string IntituleAr { get; set; }
        public string IntituleAbrg { get; set; }
        public double? Credits { get; set; }
        public double? Coefficient { get; set; }
        public long? IdParcours { get; set; }
        public long? IdNiveau { get; set; }

        public virtual Niveau IdNiveauNavigation { get; set; }
        public virtual Parcours IdParcoursNavigation { get; set; }
        public virtual ICollection<Module> Module { get; set; }
    }
}
