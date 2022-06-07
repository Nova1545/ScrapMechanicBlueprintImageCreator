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
        bool LoadedImage = false;
        bool Working = false;
        string ImagePath;
        List<Block> Blocks;

        public Main()
        {
            InitializeComponent();
            OpenImage.Filter = "Image Files(*.PNG;*.JPG)|*.PNG;*.JPG|All files (*.*)|*.*";
            OpenImage.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            OpenImage.FileName = "";
            GameDirDialog.RootFolder = Environment.SpecialFolder.ProgramFiles;
            GameDirDialog.SelectedPath = "";
        }

        /*private void CreateBlueprint_Click(object sender, EventArgs e)
        {
            if (LoadedImage)
            {
                if (Working)
                {
                    OpenInfoDialog("Please wait for the current blueprint to finish...");
                    return;
                }
                if (BlockType.SelectedItem == null)
                {
                    OpenInfoDialog("Please select a block type");
                    return;
                }
                Working = true;
                BlueprintName bn = new();
                bn.Location = this.Location + ((this.Size / 2) - (bn.Size / 2));
                if (bn.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = false;
                    Waiting w = new("Creating blueprint...");
                    w.Location = this.Location + ((this.Size / 2) - (w.Size / 2));
                    w.Show(this);
                    w.TopMost = true;
                    w.Focus();

                    ThreadPool.QueueUserWorkItem((g) =>
                    {
                        string name = bn.NameBlu;
                        string uuid = Guid.NewGuid().ToString();

                        string userPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Axolot Games\Scrap Mechanic\User";
                        string path = $@"{Directory.GetDirectories(userPath)[0]}\Blueprints\{uuid}";

                        // Rescale image
                        Bitmap bm = Rescale(new Bitmap(ImagePath), (int)Width.Value, (int)Height.Value);

                        // Create new blueprint
                        Directory.CreateDirectory(path);
                        JObject description = new();
                        description["description"] = $"Created using SMBIC by Nova1545 (https://github.com/Nova1545/ScrapMechanicBlueprintImageCreator)\nSize: {bm.Width}x{bm.Height}";
                        description["localId"] = uuid;
                        description["name"] = name;
                        description["type"] = "Blueprint";
                        description["version"] = 0;
                        File.WriteAllText($@"{path}\description.json", description.ToString());

                        // Create icon file
                        CreateIcon(new Bitmap(ImagePath)).Save($@"{path}\icon.png");

                        JObject childs = new();
                        childs["childs"] = new JArray();

                        string blockUUID = "a6c6ce30-dd47-4587-b475-085d55c6a3b4";
                        Invoke(new MethodInvoker(delegate () { blockUUID = Blocks.First(x => x.Name == BlockType.SelectedItem.ToString()).UUID; }));


                        int x = 0;
                        foreach (ChunkInfo chunk in FindSquareOfSimilarPixels(bm))
                        {
                            x++;

                            // Single child
                            JObject pos = new();
                            pos["x"] = chunk.XOffset;
                            pos["y"] = 0;
                            pos["z"] = (bm.Height - 1) - chunk.ZOffset;

                            string hex = chunk.Color.R.ToString("X2") + chunk.Color.G.ToString("X2") + chunk.Color.B.ToString("X2");

                            JObject bounds = new();
                            bounds["x"] = chunk.Length;
                            bounds["y"] = 1;
                            bounds["z"] = 1;

                            JObject child = new();
                            child["bounds"] = bounds;
                            child["color"] = hex;
                            child["pos"] = pos;

                            // Concrate
                            child["shapeId"] = blockUUID;
                            // Glass
                            //child["shapeId"] = "5f41af56-df4c-4837-9b3c-10781335757f";

                            child["xaxis"] = 0;
                            child["yaxis"] = 0;

                            // Add to childs array
                            ((JArray)childs["childs"]).Add(child);
                        }

                        // Add to main and add other stuff
                        JObject j = new();
                        j["bodies"] = new JArray();
                        j["version"] = 3;
                        ((JArray)j["bodies"]).Add(childs);


                        Debug.WriteLine(x);

                        File.WriteAllText($@"{path}\blueprint.json", JsonConvert.SerializeObject(j, Formatting.None));
                        Working = false;
                        OpenInfoDialog($"Blueprint {name} created! Size: {bm.Width}x{bm.Height} (Numbers may be different from input due to keeping aspect ratio)");

                        Invoke(new MethodInvoker(delegate () { w.Dispose(); }));
                        Invoke(new MethodInvoker(delegate () { this.Enabled = true; Focus(); }));
                    });
                }
                bn.Dispose();
            }
            else
            {
                OpenInfoDialog("Please select an image");
            }
        }*/

        private void CreateBlueprint_Click(object sender, EventArgs e)
        {

            string uuid = Guid.NewGuid().ToString();

            string userPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Axolot Games\Scrap Mechanic\User";
            string path = $@"{Directory.GetDirectories(userPath)[0]}\Blueprints\{uuid}";

            Directory.CreateDirectory(path);

            BlueprintDescription bd = new("Just a test", uuid, "Test 1");

            Blueprint bp = new(4);

            BlueprintBody body1 = new();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    body1.childs.Add(new BlueprintChild(new Vector3(1, 1, 1), GenerateColor(), new Vector3(x, y, 0), "a6c6ce30-dd47-4587-b475-085d55c6a3b4", 0, 0));
                }
            }


            bp.bodies.Add(body1);

            File.WriteAllText($@"{path}\description.json", JsonConvert.SerializeObject(bd));
            File.WriteAllText($@"{path}\blueprint.json", JsonConvert.SerializeObject(bp));
        }

        private Random rnd = new Random();
        private string GenerateColor()
        {
            return rnd.Next(0, 255).ToString("X2") + rnd.Next(0, 255).ToString("X2") + rnd.Next(0, 255).ToString("X2");
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            if (OpenImage.ShowDialog() == DialogResult.OK)
            {
                LoadedImage = true;
                ImagePath = OpenImage.FileName;
                pictureBox1.Image = Rescale(new Bitmap(ImagePath), 128, 128);
            }
        }

        private static Bitmap Rescale(Bitmap bm, int width, int height)
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

            int destWidth = (int)(sWidth * nPercentW);
            int destHeight = (int)(sHeight * nPercentH);
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

        private static List<ChunkInfo> FindSquareOfSimilarPixels(Bitmap bm)
        {
            List<ChunkInfo> Chunks = new();

            int p = 1;
            Color c = bm.GetPixel(0, 0);
            ChunkInfo cf = new(0, 0, c);

            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 1; x < bm.Width; x++)
                {
                    if (bm.GetPixel(x, y).ToArgb() == c.ToArgb())
                    {
                        p++;
                    }
                    else
                    {
                        cf.Length = p;
                        cf.Color = c;
                        Chunks.Add(cf);
                        c = bm.GetPixel(x, y);
                        cf = new(x, y, c);
                        p = 1;
                    }
                }
                cf.Length = p;
                cf.Color = c;
                Chunks.Add(cf);
                c = bm.GetPixel(0, y);
                cf = new(0, y, c);
                p = 1;
            }
            return Chunks;
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
                        Blocks = js.Deserialize<List<Block>>(s);
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
                            Blocks.Add(new Block(uuid, displayName));
                        }

                        foreach (JObject block in survivalBlockData["blockList"])
                        {
                            string uuid = (string)block["uuid"];
                            string displayName = (string)survivalBlockNames[uuid]["title"];
                            Blocks.Add(new Block(uuid, displayName));
                        }

                        using StreamWriter s = File.CreateText("BlocksCache.json");
                        JsonSerializer js = new();
                        js.Serialize(s, Blocks);
                    }

                    Invoke(new MethodInvoker(delegate () { BlockType.Items.AddRange(Blocks.Select(x => x.Name).ToArray()); }));
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
            if (LoadedImage)
                pictureBox1.Image = Rescale(new Bitmap(ImagePath), (int)Width.Value, (int)Height.Value);
        }
    }
}
