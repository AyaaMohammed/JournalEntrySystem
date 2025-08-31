using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalEntry.Core.Bases;
using JournalEntry.Core.Rescources;

namespace Project.Core.Bases
{
    public class ResponseHandler
    {
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message =SharedRescourcesKeys.Deleted,
            };
        }

        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = SharedRescourcesKeys.Success,
                Meta = Meta
            };
        }

        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = SharedRescourcesKeys.UnAuthorized
            };
        }

        public Response<T> BadRequest<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message ?? SharedRescourcesKeys.BadRequest
            };
        }

        public Response<T> UnprocessableEntity<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message ?? SharedRescourcesKeys.UnprocessableEntity
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message ?? SharedRescourcesKeys.NotFound
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = SharedRescourcesKeys.Created,
                Meta = Meta
            };
        }
    }
}
