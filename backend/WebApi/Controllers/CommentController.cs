using Microsoft.AspNetCore.Mvc;
using Services.DbServices;
using Services.Dtos;
using Services.Interfaces;
using WebApi.Constants;

namespace WebApi
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServices _commentServices;
        public CommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }
        [HttpGet]
        [Route(RouteConstants.Get)]
        public async Task<CommentDto> GetComment(int id)
        {
            return await _commentServices.Get(id);
        }
        [HttpPost]
        [Route(RouteConstants.GetByIds)]
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