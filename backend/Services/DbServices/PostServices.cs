﻿using Microsoft.EntityFrameworkCore;

using DataBase.Contexts;
using Services.Dtos;
using Services.Interfaces;
using Services.Exceptions;

namespace Services.DbServices
{
    public class PostServices : IPostServices
    {
        private readonly DbContextMain _dbContext;
        public PostServices(DbContextMain context)
        {
            _dbContext = context;
        }
        public async Task<PostDto> Create(PostDto model)
        {
            model.PostTags.AddRange(model.Tags.Select(tag => new PostTagDto()
            {
                TagId = tag.Id,
                Tag = tag.MapToEntity()
            }));

            model.Tags = null;

            var entity = model.MapToEntity();
            await _dbContext.Posts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new PostDto() { Id = entity.Id };
        }
        public async Task<List<PostDto>> Create(List<PostDto> models)
        {
            var mappedModels = models.Select(model => model.MapToEntity());
            await _dbContext.Posts.AddRangeAsync(mappedModels);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Posts.AsNoTracking()
                .Select(post => new PostDto(post)).ToListAsync();
        }
        public async Task<PostDto> Delete(int id)
        {
            var entity = await _dbContext.Posts.SingleOrDefaultAsync(entity => entity.Id == id);

            _dbContext.Posts.Remove(entity);

            if (entity is null)
            {
                throw new PostNotFoundException();  //add text??
            }

            await _dbContext.SaveChangesAsync();

            return new PostDto(entity);
        }
        public async Task<PostDto> Get(int id)
        {
            var post = await _dbContext.Posts
                .AsNoTracking()
                .Where(post => post.Id == id).Select(post => new PostDto(post)
                {
                    User = new UserDto(post.User),
                    CommentsCount = post.Comments.Count(),
                    Tags = post.Tags.Select(tag => new TagDto(tag)).ToList()
                }
            ).SingleOrDefaultAsync();

            if (post is null)
            {
                throw new PostNotFoundException();  //add text??
            }

            return post;
        }
        public async Task<List<PostDto>> GetList()
        {
            return await _dbContext.Posts
                .AsNoTracking()
                .Select(post => new PostDto(post) {
                    User = new UserDto(post.User),
                    CommentsCount = post.Comments.Count(), 
                    Tags = post.Tags.Select(tag => new TagDto(tag)).ToList()
                }).ToListAsync();
        }
        public async Task<PostDto> Update(PostDto newModel)
        {
            var entity = await _dbContext.Posts.SingleOrDefaultAsync(entity => entity.Id == newModel.Id);

            if (entity is null)
            {
                throw new PostNotFoundException();  //add text??
            }

            entity.Content = newModel.Content;

            await _dbContext.SaveChangesAsync();

            return new PostDto(entity);
        }
        public async Task<List<PostDto>> GetPostsByTagId(int id)
        {
            return await _dbContext.Posts
                .AsNoTracking()
                .Where(post => post.Tags.Any(tag => tag.Id == id))
                .Select(post => new PostDto(post)
                {
                    User = new UserDto(post.User),
                    CommentsCount = post.Comments.Count(),
                    Tags = post.Tags.Select(tag => new TagDto(tag)).ToList()
                }).ToListAsync();
        }
    }
}
