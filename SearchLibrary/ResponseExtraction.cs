using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchLibrary.Models;
using SolrNet;
using SolrNet.Impl;

namespace SearchLibrary
{
    public class ResponseExtraction
    {
        public void SetHeader(QueryResponse queryResponse, SolrQueryResults<Course> solrResult)
        {
            queryResponse.QueryTime = solrResult.Header.QTime;
            queryResponse.Status = solrResult.Header.Status;
            queryResponse.TotalHits = solrResult.NumFound;
        }

        public void SetBody(QueryResponse queryResponse, SolrQueryResults<Course> solrResult)
        {
            queryResponse.Result = solrResult as List<Course>;

            foreach (var course in queryResponse.Result)
            {
                if (solrResult.Highlights.ContainsKey(course.CourseId))
                {
                    HighlightedSnippets snippets = solrResult.Highlights[course.CourseId];

                    if (snippets.ContainsKey("coursetitle"))
                    {
                        course.CourseTitle = snippets["coursetitle"].FirstOrDefault();
                    }

                    if (snippets.ContainsKey("description"))
                    {
                        course.Description = snippets["description"].FirstOrDefault();
                    }
                }
            }
        }
    }
}

