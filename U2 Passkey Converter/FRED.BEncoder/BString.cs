using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Passkey_Converter.FRED.BEncoder
{
    class BString : BNode
    {
        public byte[] valueAsBytes;
        public string value;

        public BString()
        {

        }

        public BString(byte[] bName, byte[] bBytes)
            : base(bName)
        {
            valueAsBytes = bBytes;
        }

        public BString(string bName, byte[] bBytes)
            : base(bName)
        {
            valueAsBytes = bBytes;
        }

        public BString(byte[] bName, string bValue)
            : base(bName)
        {
            value = bValue;
        }

        public BString(string bName, string bValue)
            : base(bName)
        {
            value = bValue;
        }

        public BString(byte[] bBytes)
        {
            valueAsBytes = bBytes;
        }

        public BString(string bValue)
        {
            value = bValue;
        }

        public bool valueBytesToString()
        {
            try
            {
                value = Encoding.UTF8.GetString(valueAsBytes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool valueStringToBytes()
        {
            try
            {
                valueAsBytes = Encoding.UTF8.GetBytes(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BString decode()
        {
            int splitPos = pointer + 1;
            while (data[splitPos] != split)
                splitPos++;

            int len = Convert.ToInt32(Encoding.UTF8.GetString(data, pointer, splitPos - pointer));

            pointer = splitPos + 1;

            //value = Encoding.UTF8.GetString(data, pointer, len);
            valueAsBytes = new byte[len];
            Array.Copy(data, pointer, valueAsBytes, 0, len);

            pointer += len;
            return this;
        }

        public override void encode()
        {
            if (name != null)
            {
                copy(Encoding.UTF8.GetBytes(name).Length.ToString());
                copy(split.ToString());
                copy(name);
            }

            copy(valueAsBytes.Length.ToString());
            copy(split.ToString());
            copy(valueAsBytes);
        }
    }
}
