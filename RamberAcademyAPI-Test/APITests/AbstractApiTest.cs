using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.APITests
{
    public class AbstractApiTest<T>
    {
        protected HttpClient _client;
        protected ITestOutputHelper _output;
        protected IHttpClientFactory _factory;

        protected AbstractApiTest(ITestOutputHelper output)
        {
            _output = output;
            _client = TestClientFactory.CreateClient();
            _factory = MockIHttpClientFactory(_client);
        }

        protected IHttpClientFactory MockIHttpClientFactory(HttpClient httpClient)
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var configuration = new HttpConfiguration();

            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            return mockFactory.Object;
        }

        protected void AssertObjectsAreEqual(T obj1, T obj2)
        {
            CompareObjects(JObject.FromObject(obj1), JObject.FromObject(obj2));
        }

        protected void AssertListsAreEqual(IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if(list1.Count() != list2.Count())
            {
                Assert.True(false, "Uneven list sizes");
            }

            JArray jArray1 = JArray.FromObject(list1);
            JArray jArray2 = JArray.FromObject(list2);

            for(var i = 0; i < jArray1.Count(); i++)
            {
                CompareObjects((JObject)jArray1[i], (JObject)jArray2[i]);
            }
           
        }

        private void CompareObjects(JObject jObject1, JObject jObject2)
        {
            foreach (JProperty jProperty in jObject1.Properties())
            {
                string propertyName = jProperty.Name;
                JToken propertyValue = jProperty.Value;
                   
                if(propertyValue.Type == JTokenType.Array || propertyValue.Type == JTokenType.Null)
                {
                    continue;
                }
                _output.WriteLine($"property: {propertyName}, type: {propertyValue.Type}");
                Assert.Equal(jObject1[propertyName], jObject2[propertyName]);
            }
        }
    }
}
