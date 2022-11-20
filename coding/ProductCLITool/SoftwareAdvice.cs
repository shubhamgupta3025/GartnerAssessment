using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductCLITool.feed_products
{
    public class SoftwareAdvice
    {
        public class Products
        {
            public List<Item> products { get; set; }
        }
        public class Item
        {
            public List<string> categories { get; set; }
            public string twitter { get; set; }
            public string title { get; set; }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach(var cat in categories)
                {
                    sb.Append($" {cat},");
                }
                var _categories = sb.Remove(sb.Length - 1, 1).ToString().Trim();

                sb.Clear();
                if (!string.IsNullOrEmpty(title))
                    sb.Append($"Name: \"{title}\"; ");
                if (!string.IsNullOrEmpty(_categories))
                    sb.Append($"Categories: {_categories};");
                if (!string.IsNullOrEmpty(twitter))
                    sb.Append($" Twitter: {twitter}");
                return sb.ToString();
            }
        }
        public SoftwareAdvice(string filePath)
        {
            List<Item> list;
            if (Path.GetExtension(filePath) != ".json")
                throw new NotSupportedException("File type must be .json");
            using (StreamReader s = new StreamReader(filePath))
            {
                var obj = JsonConvert.DeserializeObject<Products>(s.ReadToEnd());
                if (obj == null)
                    throw new InvalidDataException("File must have products field which contain array of objects.");
                list = obj.products;
            }
            foreach (var item in list)
            {
                Console.WriteLine($"importing: {item.ToString()}");
            }
        }
    }
}
