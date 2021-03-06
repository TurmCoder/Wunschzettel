﻿using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Wunschzettel
{
    public class WunschzettelSerializer
    {
        public T Deserialize<T>(string jsonString)
        {
            var stream = this.GetStream(jsonString);

            var serializer = new DataContractJsonSerializer(typeof(T));

            var obj = (T)serializer.ReadObject(stream);

            return obj;
        }

        private MemoryStream GetStream(string result)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

        public string Serialize<T>(T obj)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            var memoryStream = new MemoryStream();

            serializer.WriteObject(memoryStream, obj);

            var jsonString = Encoding.UTF8.GetString(memoryStream.ToArray());

            return jsonString;
        }
    }
}