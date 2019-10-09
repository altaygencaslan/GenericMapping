using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GenericMapping.Test
{
    public class deneme1
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class deneme1Dto
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Class1
    {
        public static deneme1 heyoo = new deneme1 { id = 1, name = "altay" };

        [Test]
        public deneme1Dto Test1(deneme1 de1)
        {
            deneme1Dto de2 = GM.Map<deneme1Dto, deneme1>(de1);
            return de2;
        }
    }
}
