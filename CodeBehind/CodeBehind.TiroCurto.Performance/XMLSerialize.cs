using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeBehind.TiroCurto.Performance
{
    public static class XMLSerialize
    {
        public static void Serialize(TextWriter writer, IDictionary dictionary)
        {
            List<Entry> entries = new List<Entry>(dictionary.Count);
            foreach (object key in dictionary.Keys)
            {
                entries.Add(new Entry(key, dictionary[key]));
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
            serializer.Serialize(writer, entries);
        }
        public static void Deserialize(TextReader reader, IDictionary dictionary)
        {
            dictionary.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
            List<Entry> list = (List<Entry>)serializer.Deserialize(reader);
            foreach (Entry entry in list)
            {
                dictionary[entry.Key] = entry.Value;
            }
        }
        public class Entry
        {
            public object Key;
            public object Value;
            public Entry()
            {
            }

            public Entry(object key, object value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
