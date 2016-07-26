using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SocialNetwork.Data.DataContext;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfilesDb _ProfileDbContext;

        public ProfileRepository()
        {
            _ProfileDbContext = new ProfilesDb();
        }

        public async Task<IEnumerable<Profile>> GetForAsync()
        {
            return await _ProfileDbContext.Profiles.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(Profile profile)
        {
            var existing =
                await _ProfileDbContext.Profiles.FirstAsync(c => c.Id.Equals(profile.Id)).ConfigureAwait(false);

            if (existing == null) return false;
            existing.User = profile.User;
            existing.Action = profile.Action;
            existing.Name = profile.Name;

            return await _ProfileDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public Task<int> InsertAsync(Profile newProfile)
        {
            throw new NotImplementedException();
        }
    }

    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetForAsync();
        Task<bool> UpdateAsync(Profile profile);
        Task<int> InsertAsync(Profile newProfile);
    }
}