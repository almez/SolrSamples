using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLibrary.Models
{
    public class QueryResponse
    {
        public QueryResponse()
        {
            this.Result = new List<Course>();
        }

        public List<Course> Result { get; set; }

        public int TotalHits { get; set; }

        public int QueryTime { get; set; }

        public int Status { get; set; }

        public CourseQuery OriginalQuery { get; set; }

    }
}
