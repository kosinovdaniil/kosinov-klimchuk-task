using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Wunderlist
{
    public class HttpPostResponseBuilder<TEntity> where TEntity : Entity
    {
        private IIdentity _user;
        private HttpRequestMessage _request;
        private ICrudService<TEntity> _service;
        private TEntity _entity;

        public HttpPostResponseBuilder(IIdentity user, HttpRequestMessage request, ICrudService<TEntity> service)
        {
            _user = user;
            _request = request;
            _service = service;
        }

        private Func<bool> _condition = () => true;

        private static string Serialize(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        private HttpResponseMessage Execute()
        {
            if (_entity == null)
            {
                throw new ArgumentNullException("_entity");
            }
            HttpResponseMessage response;
            if (_user.IsAuthenticated)
            {
                if (_condition())
                {
                    response = _request.CreateResponse(HttpStatusCode.OK, "");
                    _service.Create(_entity);
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

        public HttpPostResponseBuilder<TEntity> WithEntity(TEntity entity)
        {
            _entity = entity;
            return this;
        }

        public HttpPostResponseBuilder<TEntity> WithCondition(Func<bool> condition)
        {
            _condition = condition;
            return this;
        }

        public static implicit operator HttpResponseMessage(HttpPostResponseBuilder<TEntity> self)
        {
            return self.Execute();
        }
    }
}