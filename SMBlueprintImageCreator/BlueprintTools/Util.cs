using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator.BlueprintTools
{
    public static class Util
    {
        public static string ToHex(this Color color)
        {
            return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        public static Vector3 GetXY(int count)
        {
            for (int i = 24; i < count; i++)
            {
                if (count % i == 0)
                {
                    return new Vector3(count / i, i, 0);
                }
            }
            return new Vector3(0, 0, 0);
        }
    }
}
