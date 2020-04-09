using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util
{
    public class DataParser
    {
        public static string ParseDataFromString(string contentString, string attribute) 
        {
            return JObject.Parse(contentString)["data"][attribute].ToString();
        }
    }
}
