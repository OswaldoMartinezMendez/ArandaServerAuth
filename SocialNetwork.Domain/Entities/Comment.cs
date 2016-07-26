using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLengthAttribute(250)]
        public string Subject { get; set; }
        [Required]
        [MaxLengthAttribute(500)]
        public string Description { get; set; }
        public bool Approved { get; set; }

        public virtual User User { get; set; } 
    }
}
