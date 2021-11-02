using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace DentiNovin.BaseClasses
{
    public static class SerializationTester
    {
        public static T RoundTrip<T>(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
