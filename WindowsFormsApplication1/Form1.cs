using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenericMapping;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class deneme1
        {
            public int id { get; set; }
            public string name { get; set; }
            public string name2 { get; set; }
        }

        public class deneme1Dto
        {
            public int id { get; set; }
            public string name { get; set; }
            public string name2 { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deneme1 de1 = new deneme1
            {
                id = 1,
                name = "altay",
                name2 = "maltay"
            };

            deneme1Dto de2 = GM.Map<deneme1Dto, deneme1>(de1);
        }
        //Close();
    }
}
