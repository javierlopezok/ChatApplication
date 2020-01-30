using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using CsvHelper;
using CsvHelper.Configuration;
using ChatApplication.Models;
using System.Linq;

namespace ChatApplication.Services
{
    public class BotService : IBotService
    {
        public string getStock(String message)
        {
            message = message.Replace("/stock=", "");
            string _serviceUrl = "https://stooq.com/q/l/?s=" + message + "&f=sd2t2ohlcv&h&e=csv";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_serviceUrl);
            req.KeepAlive = false;
            req.ProtocolVersion = HttpVersion.Version10;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            using (StreamReader streamReader = new StreamReader(resp.GetResponseStream()))
            {
                CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture);      
                using (CsvReader csvread = new CsvReader(streamReader, configuration))
                {
                    var records = csvread.GetRecords<CSV>().ToList();
                    return " " + message.ToUpper() + " quote is " + records.Find(x => x.Close != "").Close + " per share.";
                }
            }
        }
    }

}