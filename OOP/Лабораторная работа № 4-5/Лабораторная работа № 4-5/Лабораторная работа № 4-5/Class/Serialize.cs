using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Лабораторная_работа___4_5.Class
{
    public class Serialize
    {
        public static void DataSerialize(Product product)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product));

            using (FileStream fs = new FileStream("C:\\Users\\walde\\Downloads\\Лабораторная работа № 4-5\\Product.xml", FileMode.Create))
            {
                serializer.Serialize(fs, product);
            }
        }
        public static Product DataDeserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product));

            Product product = null;
            using (FileStream fs = new FileStream("C:\\Users\\walde\\Downloads\\Лабораторная работа № 4-5\\Product.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    product = serializer.Deserialize(fs) as Product;
                }
            }
            return product;
        }
    }
}
