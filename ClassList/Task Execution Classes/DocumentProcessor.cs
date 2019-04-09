using Json.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace ClassList
{
    public class DocumentProcessor
    {
        public async Task<List<string>> GetEntities(LoginResult Authentication, string[] ProjectId)
        {
            string[] ParamList = { Authentication.Token, "15", "a6c9a942-da1e-464f-a487-e9d0e6f8ece0", ProjectId[0] };

            string URIString = "https://api-tst.aproplan.com/rest/documents?" + QueryBuilder.GetDocumentListQueryBuilder(ParamList);

            HttpClient Client = new HttpClient();

            HttpResponseMessage Response = await Client.GetAsync(URIString);

            Response.EnsureSuccessStatusCode();

            List<string> EntityData = new List<string>();

            List<Dictionary<string, string>> obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(await Response.Content.ReadAsStringAsync());

            foreach (Dictionary<string, string> lst in obj)
            {
                foreach (KeyValuePair<string, string> item in lst)
                {
                    EntityData.Add(item.Value);
                }
            }

            return EntityData;
        }

        public async Task<string[]> GetDocumentIds(LoginResult Authentication, string[] ProjectId)
        {
            string[] ParamList = { Authentication.Token, "15", "a6c9a942-da1e-464f-a487-e9d0e6f8ece0", ProjectId[0] };

            string URIString = "https://api-tst.aproplan.com/rest/documentsids?" + QueryBuilder.GetDocumentListQueryBuilder(ParamList);

            HttpClient Client = new HttpClient();

            HttpResponseMessage Response = await Client.GetAsync(URIString);

            Response.EnsureSuccessStatusCode();

            string[] DocumentIds = { };

            if (Response.IsSuccessStatusCode)
            {
                DocumentIds = await Response.Content.ReadAsAsync<string []> ();
       
            }


            return DocumentIds;
        }

        public async Task <string> DownloadDocuments (LoginResult Authenticiation, string [] ProjectId, string DocumentId)
        {

                HttpClient Client = new HttpClient();

               string ServerResponce = "";

                string[] ParamList = { Authenticiation.Token, "15", "a6c9a942-da1e-464f-a487-e9d0e6f8ece0", ProjectId[0] };

                string URIString = "https://api-tst.aproplan.com/rest/downloadfile?" + QueryBuilder.DownloadDocumentsQueryBuilder(ParamList, DocumentId, "source"); 

                HttpResponseMessage Response = await Client.GetAsync(URIString);

                if (Response.IsSuccessStatusCode)
                {
                    ServerResponce = await Response.Content.ReadAsStringAsync();

                }

                return ServerResponce;

        } 

    }
}