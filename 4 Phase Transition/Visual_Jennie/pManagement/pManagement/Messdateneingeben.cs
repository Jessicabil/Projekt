﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace pManagement
{
    public partial class Messdateneingeben : Form
    {
        public Messdateneingeben()
        {
            InitializeComponent();
        }

        private Messwert temp;
        private string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\dbwerte.xml";

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void schliessen_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void speichern_button_Click(object sender, EventArgs e)
        {
            try
            {
                temp = new Messwert(  Convert.ToString(textBox1.Text),Convert.ToInt16(textBox2.Text));

                if (File.Exists(@path) == false)
                {
                    XElement first = new XElement("Messwerte");
                    first.Save(@path);
                }

                XElement root = XElement.Load(@path);

                XElement mWert = new XElement("Messwert",
                           new XElement("Ort", Convert.ToString(temp.Ort)),
                           new XElement("Wert", Convert.ToString(temp.Wert)));

  

                root.Add(mWert);
                root.Save(@path);
                
            }

            catch (Exception) { }

            textBox1.Clear(); 
            textBox2.Clear();

        }
    }
}
