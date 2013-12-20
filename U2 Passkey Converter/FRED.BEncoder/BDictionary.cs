using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Passkey_Converter.FRED.BEncoder
{
    class BDictionary : BNode
    {
        public List<BNode> items = new List<BNode>();

        public BDictionary()
        {

        }

        public BDictionary(byte[] bName)
            : base(bName)
        {

        }

        public BDictionary(string bName)
            : base(bName)
        {

        }

        public BDictionary decode()
        {
            while (data[pointer] != end)
            {
                int splitPos = pointer + 1;
                while (data[splitPos] != split)
                    splitPos++;

                int len = Convert.ToInt32(Encoding.UTF8.GetString(data, pointer, splitPos - pointer));
                string bName = "";
                
                pointer = splitPos + 1;

                if (len > 0)
                {
                    bName = Encoding.UTF8.GetString(data, pointer, len);
                }
                
                pointer += len;

                char type = Encoding.UTF8.GetString(data, pointer, 1)[0];

                switch (type)
                {
                    case 'd':
                        pointer++;
                        items.Add(new BDictionary(bName).decode());
                        break;
                    case 'l':
                        pointer++;
                        items.Add(new BList(bName).decode());
                        break;
                    case 'i':
                        pointer++;
                        items.Add(new BInteger(bName, "").decode());
                        break;
                    default:
                        items.Add(new BString(bName, "").decode());
                        break;
                }
            }
            pointer++;
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

            copy("d");

            foreach (BNode i in items)
                i.encode();

            copy("e");
        }
    }
}
