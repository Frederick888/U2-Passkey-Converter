using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Passkey_Converter.FRED.BEncoder
{
    class BNode
    {
        public byte[] nameAsBytes;
        public string name;

        // these data should be initialized when the root is created and shared in all instances
        public static byte[] data;
        public static int pointer;
        public static List<byte> enc = new List<byte>();

        protected static char end = 'e';
        protected static char split = ':';

        public BNode()
        {
            
        }

        public BNode(string bName)
        {
            name = bName;
        }

        public BNode(byte[] bName)
        {
            nameAsBytes = bName;
        }

        public bool nameBytesToString()
        {
            try
            {
                name = Encoding.UTF8.GetString(nameAsBytes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool nameStringToBytes()
        {
            try
            {
                nameAsBytes = Encoding.UTF8.GetBytes(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void copy(string toCopy)
        {
            enc.AddRange(Encoding.UTF8.GetBytes(toCopy));
        }

        protected void copy(byte[] toCopy)
        {
            enc.AddRange(toCopy);
        }

        public virtual void encode()
        {
            
        }
    }
}
