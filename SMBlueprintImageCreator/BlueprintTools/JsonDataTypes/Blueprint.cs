using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator.BlueprintTools.JsonDataTypes
{
    class Blueprint
    {
        public List<BlueprintBody> bodies;
        public int version;

        public Blueprint(int version)
        {
            this.version = version;
            bodies = new List<BlueprintBody>();
        }
    }
}
