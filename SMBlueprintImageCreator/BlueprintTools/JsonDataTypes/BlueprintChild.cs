using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator.BlueprintTools.JsonDataTypes
{
    class BlueprintChild
    {
        public Vector3 bounds;
        public string color;
        public Vector3 pos;
        public string shapeId;
        public int xaxis;
        public int yaxis;

        public BlueprintChild(Vector3 bounds, string color, Vector3 pos, string shapeId, int xaxis, int yaxis)
        {
            this.bounds = bounds;
            this.color = color;
            this.pos = pos;
            this.shapeId = shapeId;
            this.xaxis = xaxis;
            this.yaxis = yaxis;
        }
    }
}
