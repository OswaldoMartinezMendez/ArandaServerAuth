using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Phone { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Subject { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
