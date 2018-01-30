using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet.Commands.Parameters;

namespace SearchLibrary
{
    public class Highlights
    {
        public static HighlightingParameters BuildParameters()
        {
            HighlightingParameters parameters = new HighlightingParameters();

            parameters.Fields = new List<string>()
            {
                "coursetitle", "description"
            };

            parameters.Fragsize = 2000;

            //parameters.BeforeTerm = "<span style='color:red'>";
            //parameters.AfterTerm = "</span";

            return parameters;
        }
    }
}
