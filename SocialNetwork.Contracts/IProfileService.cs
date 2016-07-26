using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Contracts
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> GetProfileForAsync();
        Task<bool> UpdateProfileAsync(Profile profile);
        Task<int> InserProfiletAsync(Profile newProfile);
    }
}