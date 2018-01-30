using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using Newtonsoft.Json;
using SearchLibrary.Models;
using SolrNet;

namespace SearchLibrary
{
    public class SolrHelper
    {
        public static void ReIndexAllCourses()
        {

            //initialize the connection
            Startup.Init<Course>("http://desktop-nphjedv:8983/solr/courses");

            ISolrOperations<Course> solr = ServiceLocator.Current.GetInstance<ISolrOperations<Course>>();

            //delete all documents
            solr.Delete(SolrQuery.All);

            //load json file
            var courses = JsonConvert.DeserializeObject<List<Course>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "courses.json")));

            //update the index
            foreach (var course in courses)
            {
                solr.Add(course);
            }
            solr.Commit();
        }
    }
}
