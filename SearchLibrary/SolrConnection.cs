using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using SearchLibrary.Models;
using SolrNet;

namespace SearchLibrary
{
    public class SolrConnection
    {
        public static bool IsInitialized { get; set; }


        public SolrConnection(string coreUrl)
        {
            this.Init(coreUrl);
        }

        private void Init(string coreUrl)
        {
            if (!IsInitialized)
            {
                Startup.Init<Course>(coreUrl);
                IsInitialized = true;
            }    
        }

        public ISolrOperations<Course> GetSolrInstance() =>  ServiceLocator.Current.GetInstance<ISolrOperations<Course>>();
    }
}
