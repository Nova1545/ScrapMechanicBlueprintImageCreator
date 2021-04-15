using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator
{
    public struct ChunkInfo
    {
        public int Length;
        public int XOffset;
        public int ZOffset;
        public Color Color;

        public ChunkInfo(int xOffset, int yOffset, Color color)
        {
            Length = 0;
            XOffset = xOffset;
            ZOffset = yOffset;
            Color = color;
        }
    }
}
