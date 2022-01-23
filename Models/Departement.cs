using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PlanEnseignementExcel.Models
{
    public partial class Departement
    {
        public Departement()
        {
            Filiere = new HashSet<Filiere>();
        }

        public string Code { get; set; }
        public string IntituleFr { get; set; }
        public string IntituleAr { get; set; }

        public virtual ICollection<Filiere> Filiere { get; set; }
    }
}
