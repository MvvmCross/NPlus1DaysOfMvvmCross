using System;
using System.IO;
using System.Net;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;

namespace Books.Core.Services
{
    public class SimpleRestService
        : ISimpleRestService
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public SimpleRestService(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = verb;
            request.Accept = "application/json";

            MakeRequest(
               request,
               (response) =>
               {
                   if (successAction != null)
                   {
                       T toReturn;
                       try
                       {
                           toReturn = Deserialize<T>(response);
                       }
                       catch (Exception ex)
                       {
                           errorAction(ex);
                           return;
                       }
                       successAction(toReturn);
                   }
               },
               (error) =>
               {
                   if (errorAction != null)
                   {
                       errorAction(error);
                   }
               }
            );
        }

        private void MakeRequest(HttpWebRequest request, Action<string> successAction, Action<Exception> errorAction)
        {
            request.BeginGetResponse(token =>
            {
                try
                {
                    using (var response = request.EndGetResponse(token))
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(stream);
                            successAction(reader.ReadToEnd());
                        }
                    }
                }
                catch (WebException ex)
                {
                    Mvx.Error("ERROR: '{0}' when making {1} request to {2}", ex.Message, request.Method, request.RequestUri.AbsoluteUri);
                    errorAction(ex);
                }
            }, null);
        }

        private T Deserialize<T>(string responseBody)
        {
            var toReturn = _jsonConverter.DeserializeObject<T>(responseBody);
            return toReturn;
        }
    }
}
