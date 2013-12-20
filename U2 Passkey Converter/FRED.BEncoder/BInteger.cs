using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_Passkey_Converter.FRED.BEncoder
{
    class BInteger : BNode
    {
        public string value;

        public BInteger()
        {

        }

        public BInteger(string bName, string bValue)
            : base(bName)
        {
            value = bValue;
        }

        public BInteger(string bValue)
        {
            value = bValue;
        }

        public BInteger decode()
        {
            int endPos = pointer + 1;
            while (data[endPos] != end)
                endPos++;

            int len = endPos - pointer;

            value = Encoding.UTF8.GetString(data, pointer, len);

            pointer += len + 1;
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

            copy("i");

            copy(value);

            copy("e");
        }
    }
}
