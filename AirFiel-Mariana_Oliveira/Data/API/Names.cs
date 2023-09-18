using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AirFiel_Mariana_Oliveira.Data.API
{
    public class Names
    {
        public string official { get; set; }
        private string _official;
        private Dictionary<string, Names> _names = new Dictionary<string, Names>();

        public string Official
        {
            get
            {
                if (official == null || official.Length == 0)
                    return "N/A";

                return official;
            }
            set
            {
                official = value;
            }
        }
        public Dictionary<string, Names> Name
        {
            get
            {
                if (_names.Count > 1 && _names.First().Key == "default")
                    _names.Remove("default");

                return _names;
            }

            set
            {
                _names = value;
            }
        }
    }
}
