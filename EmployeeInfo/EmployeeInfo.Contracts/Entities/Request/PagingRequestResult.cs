using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInfo.Contracts.Entities
{
    public class PagingRequestResult
    {
        public RequestState State { get; set; }
        public string Msg { get; set; }
        public int TotalCount { get; set; }
        public int newPageIndex { get; set; }
        public Object Data { get; set; }
    }

}
