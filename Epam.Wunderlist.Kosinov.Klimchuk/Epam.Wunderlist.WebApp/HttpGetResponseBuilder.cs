using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web.Script.Serialization;

namespace Epam.Wunderlist.WebApp
{
    public class HttpGetResponseBuilder
    {
        private IIdentity _user;
        private HttpRequestMessage _request;

        public HttpGetResponseBuilder(IIdentity user, HttpRequestMessage request)
        {
            _user = user;
            _request = request;
        }

        private Func<bool> _condition = () => true;

        private Func<object> _getObj;


        private static string Serialize(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        private HttpResponseMessage Execute()
        {
            if (_getObj == null)
            {
                throw new ArgumentNullException("getObj");
            }
            HttpResponseMessage response;
            if (_user.IsAuthenticated)
            {
                if (_condition())
                {
                    response = _request.CreateResponse(HttpStatusCode.OK, "");
                    response.Content = new StringContent(Serialize(_getObj()), Encoding.Unicode);
                }
                else
                {
                    response = _request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            else
            {
                response = _request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            return response;
        }

        public HttpGetResponseBuilder WithMethod(Func<object> getObj)
        {
            _getObj = getObj;
            return this;
        }

        public HttpGetResponseBuilder WithCondition(Func<bool> condition)
        {
            _condition = condition;
            return this;
        }

        public static implicit operator HttpResponseMessage(HttpGetResponseBuilder self)
        {
            return self.Execute();
        }
    }
}