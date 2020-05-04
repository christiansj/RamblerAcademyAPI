using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RamblerAcademyAPI.Controllers;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.APITests
{
    public class AbstractOneIdApiTest<T> : ApiTest<T>
    {
        protected AbstractOneIdApiTest(ITestOutputHelper output) :base(output)
        {

            
        }

        protected async Task API_GetAllRecordsTest(IEnumerable<T> expected)
        {
            var response = await _controller.Get() as OkObjectResult;
            Assert.NotNull(response);

            var actual = (IEnumerable<T>)response.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        protected async Task API_GetExistentRecordTest(int id, T expected)
        {
            T actual = await GetExistentRecordAsync(id);

            AssertObjectsAreEqual(expected, actual);
        }

        protected async Task API_PostRecordTest(int testDataCnt, T expected)
        {
            var result = await _controller.Post(expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (T)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(testDataCnt + 1));
        }

        protected async Task API_PutRecordTest(int id, T expected)
        {
            var response = await _controller.Put(id, expected) as OkObjectResult;
            Assert.NotNull(response);
            var actual = (T)response.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(id));
        }

        protected async Task API_DeleteRecordTest(int id)
        {
            var deleteResult = await _controller.Delete(id) as OkResult;
            var getResult = await _controller.Get(id) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        protected async Task<T> GetExistentRecordAsync(int id)
        {
            var result = await _controller.Get(id) as OkObjectResult;
            Assert.NotNull(result);

            return (T)result.Value;
        }

        
    }
}
