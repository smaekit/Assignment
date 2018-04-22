using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Consid.Models
{
    public class Companies
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Komigen försök att komma på ett namn..")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int OrganisationNumber { get; set; }
        public string Notes { get; set; }
    }
}