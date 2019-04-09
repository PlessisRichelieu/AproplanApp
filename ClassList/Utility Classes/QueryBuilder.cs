using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;



namespace ClassList
{
    public abstract class QueryBuilder
    {
        public static string PostCredentialsQueryBuilder(string Param1, string Param2)
        {
            NameValueCollection QueryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            QueryString["v"] = Param1;
            QueryString["requesterid"] = Param2;

            return QueryString.ToString();
        }

        public static string GetTolkenQueryBuilder(string Param1)
        {
            NameValueCollection QueryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            QueryString["v"] = Param1;

            return QueryString.ToString();
        }

        public static string GetProjectIdQueryBuilder(string Param1, string Param2, string Param3)
        {
            NameValueCollection QueryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            QueryString["t"] = Param1;

            QueryString["v"] = Param2;

            QueryString["requesterid"] = Param3;

            return QueryString.ToString();

        }

        public static string GetDocumentListQueryBuilder (string [] ParamList)
        {
            NameValueCollection QueryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            QueryString["t"] = ParamList[0];

            QueryString["v"] = ParamList[1];

            QueryString["requesterid"] = ParamList[2];

            QueryString["projectId"] = ParamList[3];

            return QueryString.ToString();
        }

        public static string DownloadDocumentsQueryBuilder (string [] ParamList, string DocumentId, string File)
        {
            NameValueCollection QueryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            QueryString["t"] = ParamList[0];

            QueryString["v"] = ParamList[1];

            QueryString["requesterid"] = ParamList[2];

            QueryString["projectId"] = ParamList[3];

            QueryString["documentid"] = DocumentId;

            QueryString["file"] = File;

            return QueryString.ToString();
        }

       
    }
}