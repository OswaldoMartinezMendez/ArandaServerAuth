using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SocialNetwork.Data.DataContext;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommentsDb _CommentDbContext;

        public CommentRepository()
        {
            _CommentDbContext = new CommentsDb();
        }

        public async Task<IEnumerable<Comment>> GetForAsync()
        {
            return await _CommentDbContext.Comments.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> ApprovedAsync(int idComment)
        {
            var comment = await _CommentDbContext.Comments.FirstAsync(c => c.Id.Equals(idComment)).ConfigureAwait(false);
            comment.Approved = !comment.Approved;
            return await _CommentDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            var existing =
                await _CommentDbContext.Comments.FirstAsync(c => c.Id.Equals(comment.Id)).ConfigureAwait(false);

            if (existing == null) return false;
            existing.User = comment.User;
            existing.Approved = comment.Approved;
            existing.Date = DateTime.Now;
            existing.Description = comment.Description;
            existing.Subject = comment.Subject;

            return await _CommentDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<int> InsertAsync(Comment newComment)
        {
            _CommentDbContext.Comments.Add(newComment);
            await _CommentDbContext.SaveChangesAsync().ConfigureAwait(false);
            return newComment.Id;
        }
    }

    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetForAsync();
        Task<bool> ApprovedAsync(int idComment);
        Task<bool> UpdateAsync(Comment comment);
        Task<int> InsertAsync(Comment newComment);
    }
}