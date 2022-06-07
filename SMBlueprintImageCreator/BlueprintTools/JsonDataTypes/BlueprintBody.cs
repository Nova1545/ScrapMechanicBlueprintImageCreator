using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator.BlueprintTools.JsonDataTypes
{
    class BlueprintBody
    {
        public List<BlueprintChild> childs;

        public BlueprintBody()
        {
            childs = new List<BlueprintChild>();
        }
    }
}
