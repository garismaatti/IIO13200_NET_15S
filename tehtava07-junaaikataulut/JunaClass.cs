using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace tehtava07_junaaikataulut
{
    class JunaClass
    {
        // {"stationShortCode":"ML","stationUICCode":17,"countryCode":"FI","type":"DEPARTURE","trainStopping":false,"cancelled":false,"scheduledTime":"2015-10-22T04:17:00.000Z","actualTime":"2015-10-22T04:23:57.000Z","differenceInMinutes":7},
        //HUOM jos attribuutin ja propertyn nimet ovat eriävät niin käytä seuraavaa
        [JsonProperty("trainNumber")]
        public int trainNum { get; set; }
        [JsonProperty("operatorUICCode")]
        public string opUICCode { get; set; }
        [JsonProperty("operatorShortCode")]
        public string opShortCode { get; set; }
        [JsonProperty("trainType")]
        public string Type { get; set; }
        [JsonProperty("trainCategory")]
        public string Category { get; set; }
        [JsonProperty("runningCurrently")]
        public bool running { get; set; }
        public string departureDate { get; set; }






/*

        public string stationShortCode { get; set; }
        public int stationUICCode { get; set; }
        public string countryCode { get; set; }
        public string type { get; set; }
        public bool trainStopping { get; set; }
        public bool cancelled { get; set; }
        public string scheduledTime { get; set; }
        public string actualTime { get; set; }
        public int differenceInMinutes { get; set; }
        */
    }


    class StationsClass
    {
        // {"passengerTraffic":false,"type":"STATION","stationName":"Alapitkä","stationShortCode":"APT","stationUICCode":415,"countryCode":"FI","longitude":27.53542621509808,"latitude":63.20082319557591},

        //HUOM jos attribuutin ja propertyn nimet ovat eriävät niin käytä seuraavaa
        [JsonProperty("stationName")]
        public string name { get; set; }
        [JsonProperty("stationShortCode")]
        public string shortCode { get; set; }

        /* Items in JSON

                    "passengerTraffic":false,
                    "type":"STATION",
                    "stationName":"Alapitkä",
                    "stationShortCode":"APT",
                    "stationUICCode":415,
                    "countryCode":"FI",
                    "longitude":27.53542621509808,
                    "latitude":63.20082319557591
                */
    }

}
