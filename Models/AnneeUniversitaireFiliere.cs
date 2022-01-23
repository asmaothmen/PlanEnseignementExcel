using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class AnneeUniversitaireFiliere
    {
        public long Id { get; set; }
        public long IdFiliere { get; set; }
        public string CodeAnneeUniversitaire { get; set; }

        public virtual AnneeUniversitaire CodeAnneeUniversitaireNavigation { get; set; }
        public virtual Filiere IdFiliereNavigation { get; set; }
    }
}
