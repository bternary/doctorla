using Data.Domain;
using Data.Interfaces;
using Domain.Interfaces.Base;
using Domain.Models;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Extensions;

namespace Services
{
    public class BlogService : Service<Blog>, IBlogService
    {
        public BlogService(IRepository<Blog> blogRepo) : base(blogRepo)
        {

        }

        public List<string> GetTagsInBlogs()
        {
            var tags = _repository.Where(p => p.IsActive && !p.IsDeleted).Select(x => x.Tags).ToList();
            if (tags == null)
            {
                return null;
            }
            var tagTexts = new List<string>();
            foreach (var tag in tags)
            {
                tagTexts.AddRange(tag.Split(','));
            }
            tagTexts = tagTexts.Distinct().ToList();
            tagTexts.Sort();
            return tagTexts;
        }

        public GenericServiceListModel<Blog> GetBlogs(string postCategory, string postTag, SortingPagingInfo sorting)
        {
            var postsList = _repository.Where(p => p.IsActive && !p.IsDeleted)
                .OrderBy(!string.IsNullOrEmpty(sorting.SortField) ? sorting.SortField : "IDate", sorting.SortDirection)
                .ToList();
            List<Blog> posts = new List<Blog>();
            if (postCategory != null)
            {
                posts.AddRange(postsList.Where(post => post.Category.Split(",").Contains(postCategory) == true).ToList());
            }
            else if (postTag != null)
            {
                posts.AddRange(postsList.Where(post => post.Tags.Split(",").Contains(postTag) == true).ToList());
            }
            else
                posts = postsList;
            var result = new GenericServiceListModel<Blog>();
            result.TotalCount = posts.Count();
            result.CurrentPage = sorting.PageIndex;
            if (sorting.PageIndex > 0)
                result.Items = posts.Skip(sorting.PageSize * (sorting.PageIndex - 1))
              .Take(sorting.PageSize);
            else
            {
                result.Items = posts;
                result.PageSize = result.TotalCount;
            }
            return result;
        }
    }
}
