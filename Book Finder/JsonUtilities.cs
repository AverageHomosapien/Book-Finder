using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Book_Finder
{
    public class JsonUtilities
    {
        /// <summary>
        /// Parses a JObject and returns the value of the key as a Generic Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bookJson"></param>
        /// <param name="toParse"></param>
        /// <returns>Null or the type</returns>
        public static T ParseJObject<T>(JObject bookJson, string toParse)
        {   
            if (bookJson == null || bookJson[toParse] == null)
            {
                return default;
            }

            return (T)Convert.ChangeType(bookJson[toParse], typeof(T));
        }
    }
}
