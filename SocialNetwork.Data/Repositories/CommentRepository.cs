using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Data.DataContext;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommentsDb _commentDbContext;

        public CommentRepository()
        {
            _commentDbContext = new CommentsDb();
        }

        public async Task<IEnumerable<Comment>> GetForAsync()
        {
            return await _commentDbContext.Comments.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> ApprovedAsync(int idComment)
        {
            var comment = await _commentDbContext.Comments.FirstAsync(c => c.Id.Equals(idComment)).ConfigureAwait(false);
            comment.Approved = !comment.Approved;
            return await _commentDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            var existing =
                await _commentDbContext.Comments.FirstAsync(c => c.Id.Equals(comment.Id)).ConfigureAwait(false);

            if (existing == null) return false;
            existing.User = comment.User;
            existing.Approved = comment.Approved;
            existing.Date = DateTime.Now;
            existing.Description = comment.Description;
            existing.Subject = comment.Subject;

            return await _commentDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<int> InsertAsync(Comment newComment)
        {
            var user = newComment.User;
            newComment.User = null;
            _commentDbContext.Comments.Add(newComment);
            await _commentDbContext.SaveChangesAsync().ConfigureAwait(false);

            _commentDbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[Comments] SET [User_Id] =" + user.Id + " WHERE Id = " + newComment.Id);

            return newComment.Id;
        }

        public async Task<bool> RemoveAsync(int idComment)
        {
            var comment = await _commentDbContext.Comments.FirstAsync(c => c.Id.Equals(idComment)).ConfigureAwait(false);
            _commentDbContext.Comments.Remove(comment);
            return await _commentDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<bool> RemoveIdUserAsync(int iduser)
        {
            var profile = await _commentDbContext.Comments.Where(c => c.User.Id.Equals(iduser)).ToListAsync().ConfigureAwait(false);
            _commentDbContext.Comments.RemoveRange(profile);
            return await _commentDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }

    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetForAsync();
        Task<bool> ApprovedAsync(int idComment);
        Task<bool> UpdateAsync(Comment comment);
        Task<int> InsertAsync(Comment newComment);
        Task<bool> RemoveAsync(int idComment);
        Task<bool> RemoveIdUserAsync(int iduser);
    }
}