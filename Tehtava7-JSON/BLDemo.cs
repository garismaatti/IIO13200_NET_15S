using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tehtava7_JSON
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
}

    public class Politic:Person
    {
        public string Party { get; set; }
        //HUOM jos attribuutin ja propertyn nimet ovat eir niin käytä seuraavaa
        [JsonProperty("position")]
        public string Virka { get; set; }

    }
}
