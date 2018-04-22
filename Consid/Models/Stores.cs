using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Consid.Models
{
    public class Stores
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Companies")]
        public int CompanyId { get; set; }
        public Companies Companies { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(512)]
        public string Adress { get; set; }

        [Required]
        [StringLength(512)]
        public string City { get; set; }

        [Required]
        [StringLength(16)]
        public string Zip { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(15)]
        public string Longitude { get; set; }

        [StringLength(15)]
        public string Latitude { get; set; }    

    }
}