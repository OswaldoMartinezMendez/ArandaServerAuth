using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.DataContext
{
    public class ProfilesDb : DbContext
    {
        public ProfilesDb() : base("DefaultConnection")
        {
            
        }
        public DbSet<Profile> Profiles { get; set; }
    }
}
