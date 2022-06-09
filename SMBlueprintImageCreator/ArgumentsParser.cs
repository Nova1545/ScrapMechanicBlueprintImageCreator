using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlueprintImageCreator
{
    public class ArgumentsParser
    {
        Dictionary<string, string> Arguments;

        public ArgumentsParser(string[] args)
        {
            this.Arguments = new Dictionary<string, string>();

            foreach (string arg in args)
            {
                if (arg.Contains("="))
                {
                    string[] x = arg.Split('=');
                    Arguments.Add(x[0].Replace("-", ""), x[1]);
                }
                else
                {
                    Arguments.Add(arg.Replace("-", ""), "");
                }
            }
        }

        public string GetArg(string name)
        {
            name = name.Replace("-", "");
            if (Arguments.ContainsKey(name))
            {
                return Arguments[name];
            }
            return "";
        }

        public bool HasArg(string name)
        {
            name = name.Replace("-", "");
            if (Arguments.ContainsKey(name)) return true;
            return false;
        }
    }
}
