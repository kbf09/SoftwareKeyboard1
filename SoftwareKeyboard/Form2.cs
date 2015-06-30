using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareKeyboard
{
    public partial class Form2 : Form
    {



       static Color btnsColor = SystemColors.Control;
       static Color cursorColor = Color.Red;
       static Color btnsfontColor = Color.Black;


       static Color BbtnsColor = SystemColors.Control;
       static Color BcursorColor = Color.Red;
       static Color BbtnsfontColor = Color.Black;

       
        public Form2()
        {
            InitializeComponent();     
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.Color.DarkBlue;
        }

        public  Color BtnsColorselect()
        {
            return btnsColor;
        }

        public Color FontColorselect()
        {
            return btnsfontColor;
        }

        public Color CursorColorselect()
        {
            return cursorColor;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsColor = btnsColor;
            btnsColor = Color.Black;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsColor = btnsColor;
            btnsColor = SystemColors.Control;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsColor = btnsColor;
            btnsColor = Color.Red;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsColor = btnsColor;
            btnsColor = Color.Green;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            BcursorColor = cursorColor;
            cursorColor = Color.Black;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            BcursorColor = cursorColor;
            cursorColor = SystemColors.Control;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            BcursorColor = cursorColor;
            cursorColor = Color.Red;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            BcursorColor = cursorColor;
            cursorColor = Color.Green;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsfontColor = btnsfontColor;
            btnsfontColor = Color.Black;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsfontColor = btnsfontColor;
            btnsfontColor = SystemColors.Control;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsfontColor = btnsfontColor;
            btnsfontColor = Color.Red;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            BbtnsfontColor = btnsfontColor;
            btnsfontColor = Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Write(btnsfontColor.ToString());

            Form1 f1 = new Form1(btnsfontColor, cursorColor, btnsColor);
            f1.Show();
            /*
             foreach (Button btn in this.btns)
            {
                 //btn.Size = new Size(size, size);
            }
             * */
            System.Threading.Thread.Sleep(2000);
            this.Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnsColor = BbtnsColor;
            cursorColor = BcursorColor;
            btnsfontColor = BbtnsfontColor;
            System.Threading.Thread.Sleep(2000);
           // this.Visible = false;
        }
    }
}
