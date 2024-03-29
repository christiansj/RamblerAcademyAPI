﻿using GraphQL.Types;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Util
{
    public class GraphQLQueryUtil
    {
        public static string InputObject(IEnumerable<FieldType> fields, object obj)
        {
            JObject jObject = JObject.FromObject(obj);
            var properties = jObject.Properties();
            string inputString = "";

            for(int i = 0; i < properties.Count(); i++)
            {
                string fieldName = properties.ElementAt(i).Name;
                JToken value = jObject[fieldName];

                fieldName = lowerCaseFirstLetter(fieldName);

                FieldType fieldType = fields.FirstOrDefault(f => f.Name == fieldName);
                if (fieldType != null)
                {
                    Console.WriteLine($"Found {fieldName} with value: {value}");
                    if (inputString == "")
                    {
                        inputString = "{";
                    }
                    else
                    {
                        inputString += ", ";
                    } 

                    inputString += inputField(fieldType, fieldName, value);
                }
            }

            if(inputString != "")
            {
                inputString += "}";
            }
            Console.WriteLine($"inputCourse: {inputString}");
            return inputString;
        }
        private static string lowerCaseFirstLetter(string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1, str.Length - 1);
        }

        private static string inputField(FieldType fieldType, string fieldName, JToken value)
        {
            string fieldTypeString = fieldType.Type.ToString();
            
            string valueString = value.ToString();
            if (fieldTypeString.Contains("StringGraphType") || fieldTypeString.Contains("DateTimeGraphType"))
            {
                valueString = $"\"{valueString}\"";
            }else if (fieldTypeString.Contains("TimeSpanSecondsGraphType"))
            {
                TimeSpan timespan = TimeSpan.ParseExact(valueString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
                valueString = timespan.TotalSeconds.ToString();
            }
            return $"{fieldName}: {valueString}";
        }
    }
}
