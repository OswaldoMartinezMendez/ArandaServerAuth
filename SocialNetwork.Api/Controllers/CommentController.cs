using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using SocialNetwork.Api.Helpers;
using SocialNetwork.Contracts;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CommentController : BaseController
    {
        private static HashHelper _instance;
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public static HashHelper Help
        {
            get { return _instance ?? (_instance = new HashHelper()); }
        }

        [HttpGet]
        //[ResourceAuthorize("Total", "ContactDetails")]
        public async Task<IHttpActionResult> GetAsync()
        {
            var comments = await _commentService.GetCommentForAsync().ConfigureAwait(false);
            return comments.Any() ? Ok(comments) : null;
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(int idcomment)
        {
            var result = await _commentService.ApprovedCommentAsync(idcomment).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(Comment comment)
        {
            var user = Help.GetCurrentUser((ClaimsPrincipal) User);
            comment.User = user;

            var result = await _commentService.InsertCommnetAsync(comment).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletetAsync(int idcomment)
        {
            var result = await _commentService.RemoveProfiletAsync(idcomment).ConfigureAwait(false);
            return Ok(result);
        }
    }
}