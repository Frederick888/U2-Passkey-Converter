using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Passkey_Converter.FRED.BEncoder
{
    class BList : BNode
    {
        public List<BNode> items = new List<BNode>();

        public BList()
        {

        }

        public BList(byte[] bName)
            : base(bName)
        {

        }

        public BList(string bName)
            : base(bName)
        {

        }

        public BList decode()
        {
            while (data[pointer] != end)
            {
                char type = Encoding.UTF8.GetString(data, pointer, 1)[0];

                switch (type)
                {
                    case 'd':
                        pointer++;
                        items.Add(new BDictionary().decode());
                        break;
                    case 'l':
                        pointer++;
                        items.Add(new BList().decode());
                        break;
                    case 'i':
                        pointer++;
                        items.Add(new BInteger().decode());
                        break;
                    default:
                        items.Add(new BString().decode());
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

            copy("l");

            foreach (BNode i in items)
            {
                if (i is BDictionary)
                    i.encode();
                if (i is BList)
                    i.encode();
                if (i is BInteger)
                    i.encode();
                if (i is BString)
                    i.encode();
            }

            copy("e");
        }
    }
}
