using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class SortingPagingInfo
    {
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
    }
}
