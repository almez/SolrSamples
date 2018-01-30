using SearchLibrary.Models;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace SearchLibrary
{
    public class CourseSearch
    {
        private SolrConnection _connection;

        public CourseSearch()
        {
            this._connection = new SolrConnection("http://desktop-nphjedv:8983/solr/courses");
        }

        public QueryResponse DoSearch(CourseQuery query)
        {
            //create response
            QueryResponse queryResponse = new QueryResponse();

            //save query
            queryResponse.OriginalQuery = query;

            //get solr
            ISolrOperations<Course> solr = _connection.GetSolrInstance();

            //query
            QueryOptions options = new QueryOptions()
            {
                Rows = query.Rows,
                StartOrCursor = new StartOrCursor.Start(query.Start),
                Highlight = Highlights.BuildParameters()
            };

            //execute the query
            ISolrQuery solrQuery = new SolrQuery(query.Query);
            SolrQueryResults<Course> solrResult = solr.Query(solrQuery, options);

            //Set response
            ResponseExtraction responseExtractions = new ResponseExtraction();

            responseExtractions.SetHeader(queryResponse, solrResult);
            responseExtractions.SetBody(queryResponse, solrResult);

            return queryResponse;
        }
    }
}