﻿using System;
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
        [MaxLengthAttribute(250)]
        public string Action { get; set; }

        public virtual User User { get; set; } 
    }
}
