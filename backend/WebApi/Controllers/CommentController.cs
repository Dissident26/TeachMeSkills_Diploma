using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using WebApi.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Authentication.Helpers;

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
            return await _commentServices.Get(id);
        }
        [HttpGet]
        [Route(RouteConstants.GetById)]
        public async Task<List<CommentDto>> GetListByPost(int id)
        {
            return await _commentServices.GetListByPost(id);
        }
        [HttpGet]
        [Route(RouteConstants.GetList)]
        public async Task<List<CommentDto>> GetList()
        {
            return await _commentServices.GetList();
        }
        [HttpPost]
        [Route(RouteConstants.Add)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<CommentDto> AddPostComment(CommentDto comment)
        {
            int userId = JwtToken.GetUserIdFromToken(Request.Headers);

            comment.UserId = userId;
            comment.CreationDate = DateTime.UtcNow;

            return await _commentServices.Create(comment);
        }
        [HttpPost]
        [Route(RouteConstants.AddReply)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task AddRepliedComment(CommentDto comment)
        {
            int userId = JwtToken.GetUserIdFromToken(Request.Headers);

            comment.UserId = userId;
            comment.CreationDate = DateTime.UtcNow;

            await _commentServices.CreateRepliedComment(comment);
        }
        [HttpPut]
        [Route(RouteConstants.Update)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<CommentDto> UpdateComment(CommentDto comment)
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