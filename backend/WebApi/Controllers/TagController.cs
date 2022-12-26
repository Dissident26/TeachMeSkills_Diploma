using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Dtos;
using Services.Interfaces;
using WebApi.Constants;

namespace WebApi
{
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagServices _tagServices;
        public TagController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }
        [HttpGet]
        [Route(RouteConstants.Get)]
        public async Task<TagDto> GetTag(int id)
        {
            return await _tagServices.Get(id);
        }
        [HttpPost]
        [Route(RouteConstants.GetById)]
        public async Task<List<TagDto>> GetTag([FromBody] GetByIdsRequest request)
        {
            return await _tagServices.Get(request.Ids);
        }
        [HttpGet]
        [Route(RouteConstants.GetList)]
        public async Task<List<TagDto>> GetTagsList()
        {
            return await _tagServices.GetList();
        }
        [HttpPost]
        [Route(RouteConstants.Add)]
        public async Task<TagDto> AddTag([FromBody] TagDto tag)
        {
            return await _tagServices.Create(tag);
        }
        [HttpPut]
        [Route(RouteConstants.Update)]
        public async Task<TagDto> UpdateTag([FromBody] TagDto tag)
        {
            return await _tagServices.Update(tag);
        }
        [HttpDelete]
        [Route(RouteConstants.Delete)]
        public async Task<TagDto> DeleteTag(int id)
        {
            return await _tagServices.Delete(id);
        }
        [HttpGet]
        [Route(RouteConstants.GetSuggestTags)]
        public async Task<List<TagDto>> GetSuggestedTags(string input)
        {
            return await _tagServices.GetSuggestedTags(input);
        }
    }
}