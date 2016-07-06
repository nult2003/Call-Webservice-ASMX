using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebAppCallWS.country;

namespace WebAppCallWS.Models
{
    public class CountryModel
    {
        countrySoapClient countryClient = new countrySoapClient("countrySoap");
        
        public CountryModel()
        {
            string xmlString = countryClient.GetCountries();

            var rootElement = XElement.Parse(xmlString); // xmlString is //response.Content

            var set = new DataSet();
            var setElement = rootElement.DescendantsAndSelf().Where(e => e.Name.LocalName == "NewDataSet").FirstOrDefault();
            if (setElement != null)
            {
                using (var reader = setElement.CreateReader())
                {
                    set.ReadXml(reader, XmlReadMode.Auto);
                }
            }
        }
    }
}