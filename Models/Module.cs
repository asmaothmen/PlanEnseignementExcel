using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class Module
    {
        public Module()
        {
            AnneeUniversitaireNomOption = new HashSet<AnneeUniversitaireNomOption>();
        }

        public long IdModule { get; set; }
        public long IdUniteEnseignement { get; set; }
        public string CodeFiliere { get; set; }
        public string CodeParcours { get; set; }
        public string CodeNiveau { get; set; }
        public int Periode { get; set; }
        public string Code { get; set; }
        public string IntituleFr { get; set; }
        public string IntituleAbrege { get; set; }
        public float Credits { get; set; }
        public float Coefficients { get; set; }
        public string UniteVolumeHoraire { get; set; }
        public float VolumeCours { get; set; }
        public float VolumeTd { get; set; }
        public float VolumeTp { get; set; }
        public float VolumeCi { get; set; }
        public float VolumeTutorat { get; set; }
        public string RegimeExamen { get; set; }

        public virtual UniteEnseignement IdUniteEnseignementNavigation { get; set; }
        public virtual ICollection<AnneeUniversitaireNomOption> AnneeUniversitaireNomOption { get; set; }
    }
}
