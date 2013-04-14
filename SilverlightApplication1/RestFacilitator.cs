using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SilverlightApplication1
{
    public class RestFacilitator
    {
        private SynchronizationContext _synchronizationContext;
        public RestFacilitator(SynchronizationContext synchronizationContext)
        {
            _synchronizationContext = synchronizationContext;
        }

        public void Post(string resource, Dictionary<string, string> parameters,
                         SendOrPostCallback onComplete)
        {
            string uriPath = resource;
            Uri uri = new Uri(uriPath, UriKind.Absolute);
            HttpWebRequest httpWebRequest =
                (HttpWebRequest)WebRequest.Create(uri);

            httpWebRequest.Method = "POST";

            AsyncCallback readResponse = null;
            AsyncCallback writeRequest = null;

            writeRequest = new AsyncCallback(
                (e) =>
                {
                    httpWebRequest.ContentType =
                        "application/x-www-form-urlencoded";

                    Stream stream = httpWebRequest.EndGetRequestStream(e);
                    string postData = string.Empty;

                    foreach (string key in parameters.Keys)
                    {
                        postData += key + "=" + parameters[key] + "&";
                    }

                    StreamWriter streamWriter = new StreamWriter(stream);
                    streamWriter.Write(postData);
                    streamWriter.Close();
                    stream.Close();
                    httpWebRequest.BeginGetResponse(readResponse, null);
                });

            readResponse = new AsyncCallback(
                (e) =>
                {
                    _synchronizationContext.Post(onComplete, null);
                });

            //go statement
            httpWebRequest.BeginGetRequestStream(writeRequest, null);
        }

        public void Get<T>(string resource, SendOrPostCallback onComplete)
            where T : class, new()
        {
            string uriPath = resource;
            Uri uri = new Uri(uriPath, UriKind.Absolute);
            HttpWebRequest httpWebRequest =
                (HttpWebRequest)WebRequest.Create(uri);

            AsyncCallback done =
                new AsyncCallback(
                    (e) =>
                    {
                        HttpWebRequest request =
                            (HttpWebRequest)e.AsyncState;
                        HttpWebResponse response =
                            (HttpWebResponse)request.EndGetResponse(e);

                        Stream stream = response.GetResponseStream();
                        DataContractJsonSerializer dataContractJsonSerializer =
                            new DataContractJsonSerializer(typeof(T));

                        T result = new T();
                        result =
                            dataContractJsonSerializer.ReadObject(stream) as T;
                        _synchronizationContext.Post(onComplete, result);

                    });

            //go statement
            httpWebRequest.BeginGetResponse(done, httpWebRequest);
        }
    }
}
