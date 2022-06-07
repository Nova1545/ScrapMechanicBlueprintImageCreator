using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator.BlueprintTools.JsonDataTypes
{
    class BlueprintDescription
    {
        public string description;
        public string localId;
        public string name;
        public string type;
        public int version;

        public BlueprintDescription(string description, string localId, string name)
        {
            this.description = description;
            this.localId = localId;
            this.name = name;
            this.type = "Blueprint";
            this.version = 0;
        }
    }
}
