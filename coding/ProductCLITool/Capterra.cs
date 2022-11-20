using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ProductCLITool
{
    public class Capterra
    {
        public class Item
        {
            public string tags { get; set; }
            public string twitter { get; set; }
            public string name { get; set; }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(name))
                    sb.Append($"Name: \"{name}\"; ");
                if (!string.IsNullOrEmpty(tags))
                    sb.Append($"Categories: {tags};");
                if (!string.IsNullOrEmpty(twitter))
                    sb.Append($" Twitter: {twitter}");
                return sb.ToString();
            }
        }
        public Capterra(string filePath)
        {
            List<Item> list;
            if (Path.GetExtension(filePath) != ".yaml")
                throw new NotSupportedException("File type must be .yaml");
            using (StreamReader s = new StreamReader(filePath))
            {
                var deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();
                list = deserializer.Deserialize<List<Item>>(s);
                if (list == null)
                    throw new InvalidDataException("File must have array of tags, name, and twitter.");
            }
            foreach (var item in list)
            {
                Console.WriteLine($"importing: {item.ToString()}");
            }
        }
    }
}
