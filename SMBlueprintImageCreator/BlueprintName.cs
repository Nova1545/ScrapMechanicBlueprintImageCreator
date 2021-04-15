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
    public partial class BlueprintName : Form
    {
        public BlueprintName()
        {
            InitializeComponent();
            CancelBtn.DialogResult = DialogResult.Cancel;
            OkBtn.DialogResult = DialogResult.OK;
        }

        public string NameBlu => BName.Text; 
    }
}
