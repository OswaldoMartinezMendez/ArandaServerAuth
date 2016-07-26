using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Contracts;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.IoC;

namespace SocialNetwork.Concrets
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService()
        {
            _profileRepository = Factory.Resolver<IProfileRepository>();
        }

        public async Task<IEnumerable<Profile>> GetProfileForAsync()
        {
            return await _profileRepository.GetForAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            return await _profileRepository.UpdateAsync(profile).ConfigureAwait(false);
        }

        public async Task<int> InserProfiletAsync(Profile newProfile)
        {
            return await _profileRepository.InsertAsync(newProfile).ConfigureAwait(false);
        }
    }
}