using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Name { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Alias { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Secret { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [MaxLengthAttribute(250)]
        public string Action { get; set; }
        [Required]
        public int Hierarchy { get; set; }

        public virtual User User { get; set; } 
    }
}
