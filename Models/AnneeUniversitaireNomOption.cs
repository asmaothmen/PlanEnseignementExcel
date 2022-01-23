using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class AnneeUniversitaireNomOption
    {
        public long Id { get; set; }
        public string Intitule { get; set; }
        public string IntituleAbrg { get; set; }
        public long? IdModule { get; set; }
        public string CodeAnneeUniversitaire { get; set; }

        public virtual AnneeUniversitaire CodeAnneeUniversitaireNavigation { get; set; }
        public virtual Module IdModuleNavigation { get; set; }
    }
}
