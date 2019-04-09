using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ClassList
{
    public class Logger
    {
        public static Credentials GenerateCredentials (string UserName, string Password)
        {
            Credentials UserCredentials = new Credentials(UserName, Password);

            return UserCredentials;
        }

        public static Credentials MyCredentials = Logger.GenerateCredentials("morms@abv.bg", "Ebalsumgo9302");

        public async Task<LoginResult> PostCredentials(Credentials UserCredentials)
        {
             HttpClient Client = new HttpClient();
             
             string UriString = "https://api-tst.aproplan.com/rest/loginsecure?" + QueryBuilder.PostCredentialsQueryBuilder("15", "a6c9a942-da1e-464f-a487-e9d0e6f8ece0");

             LoginResult Authentication = null;   

             HttpResponseMessage Response = await Client.PostAsJsonAsync (UriString, UserCredentials);


             Response.EnsureSuccessStatusCode();

             if (Response.IsSuccessStatusCode)
             {
                Authentication = await Response.Content.ReadAsAsync<LoginResult>();


            }

             return Authentication;
        }

        public static async Task <LoginResult> GetTolken ()
        {
            HttpClient Client = new HttpClient();

            string UriString = "https://api-tst.aproplan.com/rest/renewtoken?" + QueryBuilder.GetTolkenQueryBuilder("15");
            
            HttpResponseMessage Response = await Client.GetAsync(UriString);

            Response.EnsureSuccessStatusCode();

            LoginResult Tolken = await Response.Content.ReadAsAsync<LoginResult>();

            return Tolken;
        }
    }
}
