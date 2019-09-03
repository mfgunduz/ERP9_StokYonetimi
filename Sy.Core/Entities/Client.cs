using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sy.Core.Abstracts;
using System.ComponentModel.DataAnnotations; // required için ekledik
using System.ComponentModel.DataAnnotations.Schema; // table için ekledik

namespace Sy.Core.Entities
{
    [Table(name: "Clients")]
    public class Client : BaseEntity<int>
    {
        [Required,StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string SurName { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }

    }
}
