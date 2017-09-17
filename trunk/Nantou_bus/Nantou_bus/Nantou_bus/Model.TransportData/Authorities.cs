using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Nantou_bus.Model.TransportData
{
    class Authorities
    {
        public string name { get; set; }
        public string tel { get; set; }

        public static List<Authorities> RetrieveFromJson(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string jsonString = client.DownloadString(url);
                    List<Authorities> entities = JsonConvert.DeserializeObject<List<Authorities>>(jsonString);
                    return entities;
                }
            }
            catch (WebException ex) { return new List<Authorities>(); }
            
        }
    }
}
