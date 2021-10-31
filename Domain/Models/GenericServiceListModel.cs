using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class GenericServiceListModel<T>
    {
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
