using System;
using ClassList;



namespace ConsoleApp1
{ 
    class Program
    {
        static void Main(string[] args)
        {
            TaskExecutor.RunAsync().GetAwaiter().GetResult();

            string Entities = string.Join(" ", TaskExecutor.Entities.ToArray());

            using (var db = new AproPlanDocumentAppContext())
            {
                db.Add(new Entities { Information = Entities });
                db.SaveChanges();
            }

            
        }
    }
}
