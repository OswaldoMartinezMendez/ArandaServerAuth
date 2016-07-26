using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.DataContext
{
    public class CommentsDb : DbContext
    {
         public CommentsDb() : base("DefaultConnection")
        {
            
        }
        public DbSet<Comment> Comments { get; set; }
    }
}
