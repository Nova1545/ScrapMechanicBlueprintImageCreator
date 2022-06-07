using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator.BlueprintTools
{
    struct Vector3
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int z { get; private set; }

        public Vector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
