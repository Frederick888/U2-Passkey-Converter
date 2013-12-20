using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U2_Passkey_Converter.FRED.BEncoder
{
    class BRoot
    {
        public BDictionary root = new BDictionary();

        public BRoot(string inputFilename)
        {
            FileInfo fi = new FileInfo(inputFilename);
            if (!fi.Exists)
            {
                throw new IOException("File doesn't exist");
            }
            else
            {
                BNode.data = File.ReadAllBytes(inputFilename);
            }
        }

        public bool initialize()
        {
            if (BNode.data[BNode.pointer] != 'd')
            {
                throw new FileLoadException("Root dictionary not found");
            }
            else
            {
                BNode.pointer++;
            }
            try
            {
                root = root.decode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool save(string outputFilename)
        {
            byte[] newSave = new byte[0];
            BNode.data = newSave;

            root.encode();

            try
            {
                FileStream fs = new FileStream(outputFilename, FileMode.Create, FileAccess.Write);
                for (int i = 0; i < BNode.enc.Count(); i++)
                {
                    fs.WriteByte(BNode.enc[i]);
                }
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
