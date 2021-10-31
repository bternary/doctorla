using Data.Domain;
using Domain.Interfaces.Base;
using Domain.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IBlogService : IService<Blog>
    {
        GenericServiceListModel<Blog> GetBlogs(string postCategory, string postTag, SortingPagingInfo paging);
        List<string> GetTagsInBlogs();
    }
}
