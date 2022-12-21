using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Dtos;
using Services.Interfaces;
using WebApi.Constants;
using Authentication.Helpers;

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
        [HttpPost]
        [Route(RouteConstants.PostById)]
        public async Task<List<PostDto>> GetPost([FromBody] GetByIdsRequest request)
        {
            return await _postServices.Get(request.Ids);
        }
        [HttpGet]
        [Route(RouteConstants.GetList)]
        public async Task<List<PostDto>> GetPostsList()
        {
            return await _postServices.GetList();
        }
        [HttpPost]
        [Route(RouteConstants.Add)]
        public async Task<PostDto> AddPost([FromBody] PostDto post)
        {
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