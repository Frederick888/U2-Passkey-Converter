using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using U2_Passkey_Converter.FRED.BEncoder;

namespace U2_Passkey_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public string getResponse(string url, string postData)
        {
            string contentType = "application/json";
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = contentType;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            string response = null;

            try
            {
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                Stream st = resp.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                response = sr.ReadToEnd();
                sr.Close();
                st.Close();
                resp.Close();
            }
            catch
            {
                System.Threading.Thread.Sleep(2000);
                return getResponse(url, postData);
            }

            return response;
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            BRoot dat = new BRoot(textBoxDat.Text);
            dat.initialize();

            int start = 0;
            while (start <= dat.root.items.Count())
            {
                string req = "[";
                for (int i = start; i <= start + 49; i++)
                {
                    if (i >= dat.root.items.Count())
                        break;
                    if (dat.root.items[i].name.Contains(".torrent"))
                    {
                        byte[] hash = new byte[0];
                        BDictionary k = dat.root.items[i] as BDictionary;
                        for (int z = 0; z < k.items.Count(); z++)
                        {
                            if (k.items[z].name == "info")
                            {
                                BString n = k.items[z] as BString;
                                hash = n.valueAsBytes;
                                break;
                            }
                        }
                        string hex = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                        req += @"{""jsonrpc"":""2.0"",""method"":""query"",""params"":""";
                        req += hex;
                        req += @""",""id"":""";
                        req += i.ToString() + @"""},";
                    }
                }
                req = req.Substring(0, req.Length - 1);
                req += "]";

                string response = getResponse(textBoxAPI.Text, req);
                Regex findPa = new Regex(@"\{""jsonrpc"":""2\.0"",""result"":""([0-9a-f]{72})"",""id"":""(\d+?)""\}", RegexOptions.Singleline);
                MatchCollection pa = findPa.Matches(response);
                for (int i = 0; i < pa.Count; i++)
                {
                    int po = 0;
                    BDictionary k = dat.root.items[Convert.ToInt32(pa[i].Groups[2].ToString())] as BDictionary;
                    for (int z = 0; z < k.items.Count(); z++)
                    {
                        if (k.items[z].name == "trackers")
                        {
                            po = z;
                            break;
                        }
                    }
                    (((dat.root.items[Convert.ToInt32(pa[i].Groups[2].ToString())] as BDictionary).items[po] as BList).items[0] as BString).valueAsBytes = Encoding.UTF8.GetBytes(textBoxTracker.Text + pa[i].Groups[1].ToString());
                }

                System.Threading.Thread.Sleep(2000);
                start += 50;
            }

            dat.save("./resume.dat.new");
            MessageBox.Show("Finished");
        }

        private void buttonDat_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            if (dia.ShowDialog() == DialogResult.OK)
            {
                textBoxDat.Text = dia.FileName;
            }
        }
    }
}
