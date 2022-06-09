using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using SMBlueprintImageCreator.BlueprintTools.JsonDataTypes;
using SMBlueprintImageCreator.BlueprintTools;

namespace SMBlueprintImageCreator
{
    public partial class Main : Form
    {
        string ImagePath;
        Dictionary<string, string> Blocks;
        ArgumentsParser Par;

        public Main(ArgumentsParser parser)
        {
            Par = parser;
            InitializeComponent();
            OpenImage.Filter = "Image Files(*.PNG;*.JPG)|*.PNG;*.JPG|All files (*.*)|*.*";
            OpenImage.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            OpenImage.FileName = "";
            GameDirDialog.RootFolder = Environment.SpecialFolder.ProgramFiles;
            GameDirDialog.SelectedPath = "";

            if (parser.HasArg("--debug"))
            {
                if (parser.HasArg("--x")) Debug(0, parser.GetArg("--uuid"), new Vector3(int.Parse(parser.GetArg("--x")), int.Parse(parser.GetArg("--y")), 0), parser.HasArg("--rnd"));
                else Debug(int.Parse(parser.GetArg("--count")), parser.GetArg("--uuid"), rndColor: parser.HasArg("--rnd"));
            }
        }

        private Random rnd = new();
        private void Debug(int count, string uuid = "", Vector3? dim2 = null, bool rndColor = false)
        {
            int limit = Par.HasArg("--limit") ? int.Parse(Par.GetArg("--limit")) : int.MaxValue;

            if (string.IsNullOrEmpty(uuid)) uuid = Guid.NewGuid().ToString();

            string userPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Axolot Games\Scrap Mechanic\User";
            string path = $@"{Directory.GetDirectories(userPath)[0]}\Blueprints\{uuid}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            BlueprintName bpn = new();
            BlueprintDescription bd = new($"Blueprint created using SMBIC", uuid, "Hot Reload");

            Blueprint bp = new(4);

            BlueprintBody body = new();

            Vector3 dim = Util.GetXY(count);
            if (dim2 != null) dim = (Vector3)dim2;

            int totalBlocks = 0;

            if (!Par.HasArg("--bounds"))
            {
 
                for (int x = 0; x < dim.x; x++)
                {
                    if (totalBlocks >= limit) break;
                    for (int y = 0; y < dim.y; y++)
                    {
                        if (totalBlocks >= limit) break;
                        string color = rndColor? Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)).ToHex() : "EEEEEE";
                        body.childs.Add(new BlueprintChild(new Vector3(1, 1, 1), color, new Vector3(x, y, 0), "628b2d61-5ceb-43e9-8334-a4135566df7a", 0, 0));
                        totalBlocks++;
                    }
                }
            }
            else
            {
                totalBlocks = dim.y * dim.x;
                string color = (rndColor) ? Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)).ToHex() : "EEEEEE";
                body.childs.Add(new BlueprintChild(new Vector3(dim.x, dim.y, 1), color, new Vector3(0, 0, 0), "628b2d61-5ceb-43e9-8334-a4135566df7a", 0, 0));
            }

            bp.bodies.Add(body);

            File.WriteAllText($@"{path}\description.json", JsonConvert.SerializeObject(bd));
            File.WriteAllText($@"{path}\blueprint.json", JsonConvert.SerializeObject(bp));
            Console.WriteLine($"Blueprint created with uuid: {uuid}\nSize: {dim.x}x{dim.y}\nBlock Count: {dim.x * dim.y} (Limited: {totalBlocks})");
            Environment.Exit(0);
        }

        private void CreateBlueprint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ImagePath))
            {
                MessageBox.Show("No image loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (BlockType.Items.Count == 0 || string.IsNullOrEmpty(BlockType.Text))
            {
                MessageBox.Show("No block types loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string uuid = Guid.NewGuid().ToString();

            string block_uuid = Blocks.Where(x => x.Value == BlockType.Text).First().Key;

            string userPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Axolot Games\Scrap Mechanic\User";
            string path = $@"{Directory.GetDirectories(userPath)[0]}\Blueprints\{uuid}";

            Directory.CreateDirectory(path);

            Bitmap reference = Rescale(new Bitmap(ImagePath), (int)Width.Value, (int)Height.Value);

            BlueprintName bpn = new();
            if (bpn.ShowDialog() != DialogResult.OK) return;
            BlueprintDescription bd = new($"Blueprint created using SMBIC. The blueprint is {reference.Width}x{reference.Height}px.", uuid, bpn.NameBlu);

            Blueprint bp = new(4);

            BlueprintBody body = new();

            for (int x = 0; x < reference.Width; x++)
            {
                for (int y = 0; y < reference.Height; y++)
                {
                    body.childs.Add(new BlueprintChild(new Vector3(1, 1, 1), reference.GetPixel(x, y).ToHex(), new Vector3(x, y, 0), block_uuid, 0, 0));
                }
            }

            bp.bodies.Add(body);

            File.WriteAllText($@"{path}\description.json", JsonConvert.SerializeObject(bd));
            File.WriteAllText($@"{path}\blueprint.json", JsonConvert.SerializeObject(bp));
            reference.Save($@"{path}\icon.png");
            reference.Dispose();

            MessageBox.Show("Blueprint created!");
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            if (OpenImage.ShowDialog() == DialogResult.OK)
            {
                CreateBlueprint.Enabled = true;
                ImagePath = OpenImage.FileName;
                Bitmap bm = Rescale(new Bitmap(ImagePath), (int)Width.Value, (int)Height.Value);
                pictureBox1.Image = bm;
                BlueprintSize.Text = $"Size: {bm.Width}x{bm.Height}px";
            }
        }

        private Bitmap Rescale(Bitmap bm, int width, int height)
        {
            int sHeight = bm.Height;
            int sWidth = bm.Width;

            float nPercent;
            float nPercentH = ((float)height / (float)sHeight);
            float nPercentW = ((float)width / (float)sWidth);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sWidth * nPercent);
            int destHeight = (int)(sHeight * nPercent);

            if (!Aspect.Checked)
            {
                destWidth = (int)(sWidth * nPercentW);
                destHeight = (int)(sHeight * nPercentH);
            }

            Bitmap b = new(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(bm, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }

        private static Bitmap CreateIcon(Bitmap bm)
        {
            int sHeight = bm.Height;
            int sWidth = bm.Width;

            float nPercentH = ((float)128 / (float)sHeight);
            float nPercentW = ((float)128 / (float)sWidth);

            int destWidth = (int)(sWidth * nPercentW);
            int destHeight = (int)(sHeight * nPercentH);
            Bitmap b = new(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(bm, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }

        private void SetGameDirBtn_Click(object sender, EventArgs e)
        {
            if (GameDirDialog.ShowDialog() == DialogResult.OK)
            {
                UserSettings.Default.GameDir = GameDirDialog.SelectedPath;
                UserSettings.Default.Save();
                Application.Restart();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            Waiting w = new(UserSettings.Default.FirstLaunch? "Reading game data and creating cache..." : "Reading cache...");
            w.Location = this.Location + ((this.Size / 2) - (w.Size / 2));
            w.Show(this);
            w.TopMost = true;
            w.Focus();

            ThreadPool.QueueUserWorkItem((g) =>
            {
                if (Directory.Exists(UserSettings.Default.GameDir))
                {
                    if (File.Exists("BlocksCache.json"))
                    {
                        using StringReader sr = new(File.ReadAllText("BlocksCache.json"));
                        using JsonReader s = new JsonTextReader(sr);
                        JsonSerializer js = new();
                        Blocks = js.Deserialize<Dictionary<string, string>>(s);
                    }
                    else if (UserSettings.Default.FirstLaunch || !File.Exists("BlocksCache.json"))
                    {
                        string gd = UserSettings.Default.GameDir;
                        JObject creativeBlockData = JObject.Parse(File.ReadAllText($@"{gd}\Data\Objects\Database\ShapeSets\blocks.json"));
                        JObject survivalBlockData = JObject.Parse(File.ReadAllText($@"{gd}\Survival\Objects\Database\ShapeSets\blocks.json"));
                        JObject creativeBlockNames = JObject.Parse(File.ReadAllText($@"{gd}\Data\Gui\Language\English\InventoryItemDescriptions.json"));
                        JObject survivalBlockNames = JObject.Parse(File.ReadAllText($@"{gd}\Survival\Gui\Language\English\inventoryDescriptions.json"));
                        Blocks = new();

                        foreach (JObject block in creativeBlockData["blockList"])
                        {
                            string uuid = (string)block["uuid"];
                            string displayName = (string)creativeBlockNames[uuid]["title"];
                            Blocks.Add(uuid, displayName);
                        }

                        foreach (JObject block in survivalBlockData["blockList"])
                        {
                            string uuid = (string)block["uuid"];
                            string displayName = (string)survivalBlockNames[uuid]["title"];
                            Blocks.Add(uuid, displayName);
                        }

                        using StreamWriter s = File.CreateText("BlocksCache.json");
                        JsonSerializer js = new();
                        js.Serialize(s, Blocks);
                    }

                    Invoke(new MethodInvoker(delegate () {
                        BlockType.Items.AddRange(Blocks.Select(x => x.Value).ToArray());
                        if (BlockType.Items.Count > 0)
                        {
                            BlockType.SelectedIndex = 0;
                        }
                    }));
                    Invoke(new MethodInvoker(delegate () { w.Dispose(); }));
                    Invoke(new MethodInvoker(delegate () { Enabled = true; Focus(); }));

                    UserSettings.Default.FirstLaunch = false;
                    UserSettings.Default.Save();
                }
                else
                {
                    OpenInfoDialog("Unable to read game data... Please set game directory");
                    Invoke(new MethodInvoker(delegate () { w.Dispose(); }));
                    Invoke(new MethodInvoker(delegate () { Enabled = true; Focus(); }));
                }
            });
        }

        private void OpenInfoDialog(string text)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                this.Enabled = false;
                InformationDialog w = new(text);
                w.Location = this.Location + ((this.Size / 2) - (w.Size / 2));
                w.TopMost = true;
                w.Focus();
                w.ShowDialog(this);
                this.Enabled = true;
            }));
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (File.Exists("BlocksCache.json")) File.Delete("BlocksCache.json");
            UserSettings.Default.Reset();
            UserSettings.Default.Save();
        }

        private void SizeValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ImagePath))
            {
                Bitmap bm = Rescale(new Bitmap(ImagePath), (int)Width.Value, (int)Height.Value);
                pictureBox1.Image = bm;
                BlueprintSize.Text = $"Size: {bm.Width}x{bm.Height}px";
            }
        }

        private void Aspect_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ImagePath))
            {
                Bitmap bm = Rescale(new Bitmap(ImagePath), (int)Width.Value, (int)Height.Value);
                pictureBox1.Image = bm;
                BlueprintSize.Text = $"Size: {bm.Width}x{bm.Height}px";
            }
        }
    }
}
