using ClassList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1.Task_Execution_Classes
{
    public class Logger
    {
        public static Credentials GenerateCredentials(string UserName, string Password)
        {
            Credentials UserCredentials = new Credentials(UserName, Password);

            return UserCredentials;
        }

        public static Credentials MyCredentials = Logger.GenerateCredentials("morms@abv.bg", "Ebalsumgo9302");

        public static HttpClient Client = new HttpClient();

        public static async Task<LoginResult> PostCredentials(Credentials UserCredentials)
        {
            string UriString = "https://api-tst.aproplan.com/rest/loginsecure?" + QueryBuilder.PostCredentialsQueryBuilder("15", "a6c9a942-da1e-464f-a487-e9d0e6f8ece0");

            LoginResult Authentication = null;

            HttpResponseMessage Response = await Client.PostAsJsonAsync(UriString, UserCredentials);


            Response.EnsureSuccessStatusCode();

            if (Response.IsSuccessStatusCode)
            {
                Authentication = await Response.Content.ReadAsAsync<LoginResult>();


            }

            return Authentication;
        }

    }

}
    
