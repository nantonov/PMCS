using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Schedule.Application.Helpers
{
    public static class CommunicationServicesHelper
    {
        public static HttpContent SerializeObjectToHttpContent(object objectToParse)
        {
            string jsonString = JsonConvert.SerializeObject(objectToParse);

            ByteArrayContent content = new StringContent(jsonString);

            content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);

            return content;
        }
    }
}
