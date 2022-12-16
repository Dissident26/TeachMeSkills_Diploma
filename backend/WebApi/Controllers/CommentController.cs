using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Dtos;
using Services.Interfaces;
using WebApi.Constants;
using Microsoft.IdentityModel.Tokens;

namespace WebApi
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServices _commentServices;
        private readonly IRepliedCommentServices _repliedCommentServices;
        public CommentController(ICommentServices commentServices, IRepliedCommentServices repliedCommentServices)
        {
            _commentServices = commentServices;
            _repliedCommentServices = repliedCommentServices;
        }
        [HttpGet]
        [Route(RouteConstants.Get)]
        public async Task<CommentDto> GetComment(int id)
        {
            var comment = await _commentServices.Get(id);
            var repliedComments = await _repliedCommentServices.GetListByComment(id);

            if (!repliedComments.IsNullOrEmpty())
            {
                comment.RepliedComments = repliedComments;
            }

            return comment;
        }
        [HttpGet]
        [Route(RouteConstants.GetById)]
        public async Task<List<CommentDto>> GetCommentByPostId(int id)
        {
            var comments = await _commentServices.GetListByPost(id);

            foreach (var comment in comments)
            {
                var repliedComments = await _repliedCommentServices.GetListByComment(comment.Id);
                if (!repliedComments.IsNullOrEmpty())
                {
                    comment.RepliedComments = repliedComments;
                }
            }

            return comments;
        }
        [HttpPost]
        [Route(RouteConstants.GetById)]
        public async Task<List<CommentDto>> GetComment([FromBody] GetByIdsRequest request)
        {
            return await _commentServices.Get(request.Ids);
        }
        [HttpGet]
        [Route(RouteConstants.GetList)]
        public async Task<List<CommentDto>> GetCommentsList()
        {
            return await _commentServices.GetList();
        }
        [HttpPost]
        [Route(RouteConstants.Add)]
        public async Task<CommentDto> AddComment([FromBody] CommentDto comment)
        {
            return await _commentServices.Create(comment);
        }
        [HttpPut]
        [Route(RouteConstants.Update)]
        public async Task<CommentDto> UpdateComment([FromBody] CommentDto comment)
        {
            return await _commentServices.Update(comment);
        }
        [HttpDelete]
        [Route(RouteConstants.Delete)]
        public async Task<CommentDto> DeleteComment(int id)
        {
            return await _commentServices.Delete(id);
        }
    }
}