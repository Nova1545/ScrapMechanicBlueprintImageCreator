using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator.BlueprintTools
{
    struct BlueprintBlock
    {
        public string UUID { get; private set; }
        public Vector3 Location { get; private set; }

        private Color BlockColor;

        public BlueprintBlock(string uuid, Vector3 location, Color blockColor)
        {
            UUID = uuid;
            Location = location;
            BlockColor = blockColor;
        }

        public string GetColor()
        {
            return BlockColor.R.ToString("X2") + BlockColor.G.ToString("X2") + BlockColor.B.ToString("X2");
        }
    }
}
