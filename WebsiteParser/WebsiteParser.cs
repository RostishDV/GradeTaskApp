using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GradeTaskApp.WebsiteParser
{
	public static class WebsiteParser
	{
		public static List<string> GetURLsFromSite(string urlAddress)
		{
			string data = "";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(urlAddress);
            request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            Regex regex = new Regex("http[s]?://(([^\\s\"']+(/)?)+)");
            return regex.Matches(data).Cast<Match>()
                    .Select(m => m.Value)
                    .ToList();
		}
	}
}
