using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Contracts;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.IoC;

namespace SocialNetwork.Concrets
{
    public class CommentService :ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService()
        {
            _commentRepository = Factory.Resolver<ICommentRepository>();
        }
        public async Task<IEnumerable<Comment>> GetCommentForAsync()
        {
            return await _commentRepository.GetForAsync().ConfigureAwait(false);
        }

        public async Task<bool> ApprovedCommentAsync(int idComment)
        {
            return await _commentRepository.ApprovedAsync(idComment).ConfigureAwait(false);
        }

        public async Task<bool> UpdateCommentAsync(Comment comment)
        {
            return await _commentRepository.UpdateAsync(comment).ConfigureAwait(false);
        }

        public async Task<int> InsertCommnetAsync(Comment newComment)
        {
            return await _commentRepository.InsertAsync(newComment).ConfigureAwait(false);
        }
    }
}
