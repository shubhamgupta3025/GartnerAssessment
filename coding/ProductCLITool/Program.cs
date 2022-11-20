using Newtonsoft.Json;
using ProductCLITool.feed_products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ProductCLITool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var provider = args.AsQueryable().FirstOrDefault();
            var filepath = args.AsQueryable().ElementAtOrDefault(1);
            if (string.IsNullOrEmpty(provider) || string.IsNullOrEmpty(filepath))
                throw new ArgumentNullException("Wrong command.");

            switch (provider.Trim().ToLower())
            {
                case "capterra": new Capterra(filepath); // For Capterra data provider. Should be a .yaml file
                    break;
                case "softwareadvice": new SoftwareAdvice(filepath); // For Software Advice. Should be a .json file
                    break;
                // Further Providers can be added here.
                default: throw new NotImplementedException("Currently serving Capterra and SoftwareAdvice only.");
            }
        }
        
    }
}
