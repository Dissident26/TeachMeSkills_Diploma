using Microsoft.AspNetCore.Mvc;
using Services.DbServices;
using Services.Dtos;
using Services.Interfaces;
using WebApi.Constants;

namespace WebApi
{
    [ApiController]
    public class PostTagController : ControllerBase
    {
        private readonly IPostTagServices _postTagServices;
        public PostTagController(IPostTagServices postTagServices)
        {
            _postTagServices = postTagServices;
        }
        [HttpGet]
        [Route(RouteConstants.Get)]
        public async Task<PostTagDto> GetPostTag(int id)
        {
            return await _postTagServices.Get(id);
        }
        [HttpPost]
        [Route(RouteConstants.GetByIds)]
        public async Task<List<PostTagDto>> GetPostTag([FromBody] GetByIdsRequest request)
        {
            return await _postTagServices.Get(request.Ids);
        }
        [HttpGet]
        [Route(RouteConstants.GetList)]
        public async Task<List<PostTagDto>> GetPostTagsList()
        {
            return await _postTagServices.GetList();
        }
        [HttpPost]
        [Route(RouteConstants.Add)]
        public async Task<PostTagDto> AddPostTag([FromBody] PostTagDto postTag)
        {
            return await _postTagServices.Create(postTag);
        }
        [HttpPut]
        [Route(RouteConstants.Update)]
        public async Task<PostTagDto> UpdatePostTag([FromBody] PostTagDto postTag)
        {
            return await _postTagServices.Update(postTag);
        }
        [HttpDelete]
        [Route(RouteConstants.Delete)]
        public async Task<PostTagDto> DeletePostTag(int id)
        {
            return await _postTagServices.Delete(id);
        }
    }
}