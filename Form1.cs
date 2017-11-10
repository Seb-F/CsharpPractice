using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training_Session_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Torch torch = new Torch();
       // int _batteryDrain = 1;
       
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeState(true);
            lblBattery.Visible = true;
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeState(false);
            lblBattery.Visible = true;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            ChangeState(!torch.turnedOn);
            lblBattery.Visible = true;
        }

        private void ChangeState(bool letThereBeLight)
        {
            torch.ChangeState(letThereBeLight);
            checkBox1.Checked = torch.turnedOn;
            lblBattery.Text = torch.battery.ToString() + " %";
            lblBattery.BackColor = torch.bgColor;
            if (torch.battery == 0)
            {
                btnCharge.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
                btnToggle.Enabled = false;
            }
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            torch.battery = 100;
            btnCharge.Visible = false;
            button1.Enabled = true;
            btnToggle.Enabled = true;
            lblBattery.Visible = true;
            lblBattery.Text = torch.battery.ToString() + " %";
            lblBattery.Visible = true;
            lblBattery.BackColor = torch.bgColor = Color.Empty;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                //retrieve the Color text from our txtColor textbox and convert it to a color type
                Color myColor = Color.FromName(txtColor.Text);

                //you know what this does.
                lblLastAddedColor.BackColor = myColor;
                
                //add the color to our color list inside the torch object
                torch.ColorList.Add(Convert.ToInt32(txtCharge.Text), myColor);
                                
                //clear out the display color list
                lstColor.Items.Clear();

                //add each of the items in colorlist to the display list
                for (int count = 0; count < torch.ColorList.Count; count = count + 1)
                {
                    lstColor.Items.Add(torch.ColorList.ToList<KeyValuePair<int, Color>>()[count]);
                }
                txtCharge.Text = "";
                txtColor.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Sorry it looks like 'AJ' Fooked something up " + "\n" + Ex.Message);
                txtCharge.Text = "";
                txtColor.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Exit();
        }

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Exit();
        }

        //public void highPower10ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    _batteryDrain = 10;
        //}
    }
}
