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
        public string Name { get; set; }
        public string Action { get; set; }

        public virtual User Country { get; set; }
    }
}
