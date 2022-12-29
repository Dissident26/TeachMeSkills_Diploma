using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using WebApi.Constants;
using Authentication.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApi
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postServices;
        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }
        [HttpGet]
        [Route(RouteConstants.Get)]
        public async Task<PostDto> GetPost(int id)
        {
            return await _postServices.Get(id);
        }
        [HttpGet]
        [Route(RouteConstants.GetList)]
        public async Task<List<PostDto>> GetPostsList()
        {
            return await _postServices.GetList();
        }
        [HttpPost]
        [Route(RouteConstants.Add)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<PostDto> AddPost(PostDto post)
        {
            int userId = JwtToken.GetUserIdFromToken(Request.Headers);

            post.UserId = userId;
            post.CreationDate = DateTime.UtcNow;

            return await _postServices.Create(post);
        }
        [HttpPut]
        [Route(RouteConstants.Update)]
        public async Task<PostDto> UpdatePost([FromBody] PostDto post)
        {
            return await _postServices.Update(post);
        }
        [HttpDelete]
        [Route(RouteConstants.Delete)]
        public async Task<PostDto> DeletePost(int id)
        {
            return await _postServices.Delete(id);
        }
        [HttpGet]
        [Route(RouteConstants.GetPostListByTag)]
        public async Task<List<PostDto>> GetPostsByTagId(int id)
        {
            return await _postServices.GetPostsByTagId(id);
        }
        
    }
}