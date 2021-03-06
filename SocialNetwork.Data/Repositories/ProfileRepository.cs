﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task<int> InsertAsync(Profile newProfile)
        {
             _ProfileDbContext.Profiles.Add(newProfile);
             await _ProfileDbContext.SaveChangesAsync().ConfigureAwait(false);
            return newProfile.Id;
        }

        public async Task<bool> RemoveAsync(int idProfile)
        {
            var profile = await _ProfileDbContext.Profiles.FirstAsync(c => c.Id.Equals(idProfile)).ConfigureAwait(false);
            _ProfileDbContext.Profiles.Remove(profile);
            return await _ProfileDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<bool> RemoveIdUserAsync(int iduser)
        {
            var profile = await _ProfileDbContext.Profiles.Where(c => c.User.Id.Equals(iduser)).ToListAsync().ConfigureAwait(false);
            _ProfileDbContext.Profiles.RemoveRange(profile);
            return await _ProfileDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<IEnumerable<Profile>> GetByHierarchyAsync(int idUser)
        {
            var list = new List<Profile>();
            var profiles = await
                _ProfileDbContext.Profiles.Where(p => p.User.Id.Equals(idUser))
                    .OrderBy(p => p.Hierarchy)
                    .ToListAsync()
                    .ConfigureAwait(false);
            return profiles.Any() ? profiles : list;
        }

        public IEnumerable<Profile> GetByHierarchy(int idUser)
        {
            var list = new List<Profile>();
            var profiles =
                _ProfileDbContext.Database.SqlQuery<Profile>(
                    "SELECT Id,Name,[Action],Alias,[Secret],[Enabled],Hierarchy FROM Profiles WHERE [User_Id] = " +
                    idUser + " ORDER BY [Hierarchy]");

            return profiles;
        }
    }

    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetForAsync();
        Task<bool> UpdateAsync(Profile profile);
        Task<int> InsertAsync(Profile newProfile);
        Task<bool> RemoveAsync(int idProfile);
        Task<IEnumerable<Profile>> GetByHierarchyAsync(int idUser);
        IEnumerable<Profile> GetByHierarchy(int idUser);
        Task<bool> RemoveIdUserAsync(int iduser);
    }
}