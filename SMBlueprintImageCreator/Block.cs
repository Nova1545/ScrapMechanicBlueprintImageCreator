using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator
{
    [Serializable]
    public struct Block
    {
        public string UUID { get; private set; }
        public string Name { get; private set; }

        public Block(string uuid, string name)
        {
            UUID = uuid;
            Name = name;
        }
    }
}
