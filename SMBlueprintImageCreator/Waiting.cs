using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMBlueprintImageCreator
{
    public partial class Waiting : Form
    {
        public Waiting(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }
    }
}
