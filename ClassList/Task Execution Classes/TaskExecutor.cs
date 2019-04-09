using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    public abstract class TaskExecutor
    {  
        public static List<string> Entities = new List<string>();

        public static async Task RunAsync ()
        {
            try
            {
                 Logger Log = new Logger();
                 ProjectsProcessor PrProcessor = new ProjectsProcessor();
                 DocumentProcessor DcProcessor = new DocumentProcessor();
              
                 LoginResult Authentication = new LoginResult();
                 string[] ProjectId = { };
                 string [] DocumentIds = { };
                 string  ServerResponse = "";

                 Authentication = await Log.PostCredentials(Logger.MyCredentials);
                 ProjectId = await PrProcessor.GetProjectId(Authentication);
                 Entities = await DcProcessor.GetEntities(Authentication, ProjectId);
                 DocumentIds = await DcProcessor.GetDocumentIds(Authentication, ProjectId);
                                   
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           

        }
    }
}
