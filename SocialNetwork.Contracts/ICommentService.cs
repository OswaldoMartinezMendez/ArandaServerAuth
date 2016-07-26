using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentForAsync();
        Task<bool> ApprovedCommentAsync(int idComment);
        Task<bool> UpdateCommentAsync(Comment comment);
        Task<int> InsertCommnetAsync(Comment newComment);
        Task<bool> RemoveProfiletAsync(int idComment);
    }
}