using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {

    // List 12-17 のクラス定義部
    
    [DataContract]
    public class AbbreviationDict {
        [DataMember(Name = "abbrs")]
        public Dictionary<string, string> Abbreviations { get; set; }
    }
}
