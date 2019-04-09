using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    public class ProjectsProcessor
    {
        public async Task <string []> GetProjectId (LoginResult Authentication)
        {
            string URIString = "https://api-tst.aproplan.com/rest/projectsids?" + QueryBuilder.GetProjectIdQueryBuilder(Authentication.Token, "15", "a6c9a942-da1e-464f-a487-e9d0e6f8ece0");

            string [] ProjectId = { };

            HttpClient Client = new HttpClient();

            HttpResponseMessage Response = await Client.GetAsync(URIString);
           
            Response.EnsureSuccessStatusCode();

            
            if (Response.IsSuccessStatusCode)
            {
                ProjectId = await Response.Content.ReadAsAsync<string []>();
            }
         

            return ProjectId;
        }
    }
}
