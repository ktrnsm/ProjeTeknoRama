using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WEBUI.Models.Currency
{
    public class Currency
    {
        public Currency()
        {
            string currentCurrency = "https://www.tcmb.gov.tr/kurlar/today.xml";

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(currentCurrency);

            // used from and old someboy elses project

            EuroSll = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            EuroBy = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            DolarSll = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            DolarBy = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
        }
        public string EuroSll { get; set; }
        public string EuroBy { get; set; }
        public string DolarSll { get; set; }
        public string DolarBy { get; set; }
    }
}