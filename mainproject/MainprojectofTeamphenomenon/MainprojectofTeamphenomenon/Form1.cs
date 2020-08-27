using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MainprojectofTeamphenomenon
{
    public partial class Form1 : Form

    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string text_to_send;
        public string gg;
        public string hh;
        double ic;
        public Form1()
        {
            InitializeComponent();
            home1.BringToFront();


            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());       //get own ip
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox2.Text = address.ToString();
                }
            }

        }
        public void Multiplydouble(Label z, int x, double y)
        {
            double total = x * y;
            z.Text = total.ToString();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.textBox6.Invoke(new MethodInvoker(delegate () { textBox6.AppendText(receive + "\r\n"); }));
                    receive = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(text_to_send);
                this.textBox6.Invoke(new MethodInvoker(delegate () { textBox6.AppendText(text_to_send + "\r\n"); }));
            }
            else
            {
                MessageBox.Show("Send Failed");
            }
            backgroundWorker2.CancelAsync();
        }


        private void button6_Click(object sender, EventArgs e) //connect to sever
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox8.Text), int.Parse(textBox5.Text));

            try
            {
                client.Connect(IP_End);
                if (client.Connected)
                {
                    label30.Text = "Connected to Sever  " + "\n";
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;

                    backgroundWorker1.RunWorkerAsync();                      //start Receving data in BackGround
                    backgroundWorker3.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;    //Ability to cancel this thread
                    backgroundWorker4.WorkerSupportsCancellation = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                text_to_send = textBox7.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            textBox7.Text = "";


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            double rd1;
            if (checkBox1.Checked == true)
            {
                listBox1.Items.Add("Triple - Decker Burger                  " + "$" + burger1p.Text);

                textBox1.Text = burger1p.Text;
                rd1 = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox1.Checked == false)
            {
                listBox1.Items.Remove("Triple - Decker Burger                  " + "$" + burger1p.Text);

                textBox1.Text = burger1p.Text;
                rd1 = double.Parse(textBox1.Text);
                ic = ic - rd1;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }




        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            double rd;
            if (checkBox2.Checked == true)
            {
                listBox1.Items.Add("Mashed Potato Burger                  " + "$" + burger2p.Text);

                textBox1.Text = burger2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox2.Checked == false)
            {
                listBox1.Items.Remove("Mashed Potato Burger                  " + "$" + burger2p.Text);

                textBox1.Text = burger2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            double rd2;
            if (checkBox5.Checked == true)
            {
                listBox1.Items.Add("Cheese-Stuffed Burger                  " + "$" + burger3p.Text);

                textBox1.Text = burger3p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox5.Checked == false)
            {
                listBox1.Items.Remove("Cheese-Stuffed Burger                  " + "$" + burger3p.Text);

                textBox1.Text = burger3p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic - rd2;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            double rd2;
            if (checkBox3.Checked == true)
            {
                listBox1.Items.Add("Korean Spicy Noddle                  " + "$" + noddle1p.Text);
                textBox1.Text = noddle1p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox3.Checked == false)
            {
                listBox1.Items.Remove("Korean Spicy Noddle                  " + "$" + noddle1p.Text);
                textBox1.Text = noddle1p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic - rd2;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }





        

      

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel44.Height = button10.Height;
            panel44.Top = button10.Top;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel44.Height = button14.Height;
            panel44.Top = button14.Top;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel44.Height = button12.Height;
            panel44.Top = button12.Top;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Step 1 : Click the Number that you want on the Number Key" + "\n" + "Step 2 : Click the check box that you wana eat." + "\n" + "Step 3 : Check your order list and Bill" + "\n" + "Step4 : Click the Order :)");
        }

        

        

        

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            Multiplydouble(burger1p, Convert.ToInt32(numericUpDown1.Value), 6);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(burger2p, Convert.ToInt32(numericUpDown2.Value), 5);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(burger3p, Convert.ToInt32(numericUpDown3.Value), 5);
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd2;
            if (checkBox3.Checked == true)
            {
                listBox1.Items.Add("Korean Spicy Noddle                    " + "$" + noddle1p.Text);
                textBox1.Text = noddle1p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            if (checkBox3.Checked == false)
            {
                listBox1.Items.Remove("Korean Spicy Noddle                    " + "$" + noddle1p.Text);
                textBox1.Text = noddle1p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic - rd2;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd2;
            if (checkBox5.Checked == true)
            {
                listBox1.Items.Add("Cheese-Stuffed Burger                  " + "$" + burger3p.Text);
                textBox1.Text = noddle1p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            if (checkBox5.Checked == false)
            {
                listBox1.Items.Remove("Cheese-Stuffed Burger                  " + "$" + burger3p.Text);
                textBox1.Text = noddle1p.Text;
                rd2 = double.Parse(textBox1.Text);
                ic = ic - rd2;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(noddle1p, Convert.ToInt32(numericUpDown4.Value), 4);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(noddle2p, Convert.ToInt32(numericUpDown5.Value), 25);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(noddle3p, Convert.ToInt32(numericUpDown6.Value), 6);
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(noddle4p, Convert.ToInt32(numericUpDown7.Value), 1);
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(noddle5p, Convert.ToInt32(numericUpDown8.Value), 3.4);
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(noddle6p, Convert.ToInt32(numericUpDown9.Value), 6.5);
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(noddle7p, Convert.ToInt32(numericUpDown10.Value), 5);
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(bbq1p, Convert.ToInt32(numericUpDown11.Value), 25);
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(bbq2p, Convert.ToInt32(numericUpDown12.Value), 11);
        }

        private void panel18_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(bbq3p, Convert.ToInt32(numericUpDown13.Value), 15);
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(ju1p, Convert.ToInt32(numericUpDown14.Value), 2);
        }

        private void label26_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(ju2p, Convert.ToInt32(numericUpDown15.Value), 1.5);
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(ju3p, Convert.ToInt32(numericUpDown16.Value), 1.2);
        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(ju4p, Convert.ToInt32(numericUpDown17.Value), 1.8);
        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(desert1p, Convert.ToInt32(numericUpDown18.Value), 10);
        }

        private void numericUpDown19_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(desert2p, Convert.ToInt32(numericUpDown19.Value), 7);
        }

        private void numericUpDown20_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(desert3p, Convert.ToInt32(numericUpDown20.Value), 12);
        }

        private void numericUpDown21_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(desert4p, Convert.ToInt32(numericUpDown21.Value), 8);
        }

        private void numericUpDown22_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(desert5p, Convert.ToInt32(numericUpDown22.Value), 5.2);
        }

        private void numericUpDown23_ValueChanged(object sender, EventArgs e)
        {
            Multiplydouble(desert6p, Convert.ToInt32(numericUpDown23.Value), 16);
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd1;
            if (checkBox1.Checked == true)
            {
                listBox1.Items.Add("Triple - Decker Burger                  " + "$" + burger1p.Text);

                textBox1.Text = burger1p.Text;
                rd1 = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox1.Checked == false)
            {
                listBox1.Items.Remove("Triple - Decker Burger                  " + "$" + burger1p.Text);

                textBox1.Text = burger1p.Text;
                rd1 = double.Parse(textBox1.Text);
                ic = ic - rd1;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false )
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
                
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox2.Checked == true)
            {
                listBox1.Items.Add("Mashed Potato Burger                  " + "$" + burger2p.Text);

                textBox1.Text = burger2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox2.Checked == false)
            {
                listBox1.Items.Remove("Mashed Potato Burger                  " + "$" + burger2p.Text);

                textBox1.Text = burger2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox4.Checked == true)
            {
                listBox1.Items.Add("Beef Noddle                                 " + "$" + noddle2p.Text);
                textBox1.Text = noddle2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            if (checkBox4.Checked == false)
            {
                listBox1.Items.Remove("Beef Noddle                                 " + "$" + noddle2p.Text);
                textBox1.Text = noddle2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox7_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox7.Checked == true)
            {
                listBox1.Items.Add("Egg Noddle                                  " + "$" + noddle4p.Text);
                textBox1.Text = noddle4p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox7.Checked == false)
            {
                listBox1.Items.Remove("Egg Noddle                                  " + "$" + noddle4p.Text);
                textBox1.Text = noddle4p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
             
            }
        }

        private void checkBox9_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox9.Checked == true)
            {
                listBox1.Items.Add("Ramen Pork                                " + "$" + noddle6p.Text);
                textBox1.Text = noddle6p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox9.Checked == false)
            {
                listBox1.Items.Remove("Ramen Pork                                " + "$" + noddle6p.Text);
                textBox1.Text = noddle6p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
               
            }
        }

        private void checkBox10_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox10.Checked == true)
            {
                listBox1.Items.Add("Sea Food Noddle                        " + "$" + noddle7p.Text);
                textBox1.Text = noddle7p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox10.Checked == false)
            {
                listBox1.Items.Remove("Sea Food Noddle                        " + "$" + noddle7p.Text);
                textBox1.Text = noddle7p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
                
            }
        }

        private void checkBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox11.Checked == true)
            {
                listBox1.Items.Add("Beef Ribs                                    " + "$" + bbq1p.Text);
                textBox1.Text = bbq1p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox11.Checked == false)
            {
                listBox1.Items.Remove("Beef Ribs                                    " + "$" + bbq1p.Text);
                textBox1.Text = bbq1p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox12_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox12.Checked == true)
            {
                listBox1.Items.Add("Grilled Peruvian Chicken             " + "$" + bbq2p.Text);
                textBox1.Text = bbq2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox12.Checked == false)
            {
                listBox1.Items.Remove("Grilled Peruvian Chicken             " + "$" + bbq2p.Text);
                textBox1.Text = bbq2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox15_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox15.Checked == true)
            {
                listBox1.Items.Add("Orange Juice                              " + "$" + ju2p.Text);
                textBox1.Text = ju2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox15.Checked == false)
            {
                listBox1.Items.Remove("Orange Juice                              " + "$" + ju2p.Text);
                textBox1.Text = ju2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox13_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox13.Checked == true)
            {
                listBox1.Items.Add("Grilled Balsamic Pork                  " + "$" + bbq3p.Text);
                textBox1.Text = bbq3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox13.Checked == false)
            {
                listBox1.Items.Remove("Grilled Balsamic Pork                  " + "$" + bbq3p.Text);
                textBox1.Text = bbq3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox14_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox14.Checked == true)
            {
                listBox1.Items.Add("Watermelon Juice                       " + "$" + ju1p.Text);
                textBox1.Text = ju1p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox14.Checked == false)
            {
                listBox1.Items.Remove("Watermelon Juice                       " + "$" + ju1p.Text);
                textBox1.Text = ju1p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox16_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox16.Checked == true)
            {
                listBox1.Items.Add("Strawberry Juice                         " + "$" + ju3p.Text);
                textBox1.Text = ju3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox16.Checked == false)
            {
                listBox1.Items.Remove("Strawberry Juice                         " + "$" + ju3p.Text);
                textBox1.Text = ju3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox17_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox17.Checked == true)
            {
                listBox1.Items.Add("Pineapple Juice                          " + "$" + ju4p.Text);
                textBox1.Text = ju4p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox17.Checked == false)
            {
                listBox1.Items.Remove("Pineapple Juice                          " + "$" + ju4p.Text);
                textBox1.Text = ju4p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox18_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox18.Checked == true)
            {
                listBox1.Items.Add("Texas Sheet Cake                     " + "$" + desert1p.Text);
                textBox1.Text = desert1p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox18.Checked == false)
            {
                listBox1.Items.Remove("Texas Sheet Cake                     " + "$" + desert1p.Text);
                textBox1.Text = desert1p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox19_CheckedChanged_1(object sender, EventArgs e)
        {

            double rd;
            if (checkBox19.Checked == true)
            { 
                listBox1.Items.Add("Carrot Cake                                " + "$" + desert2p.Text);
                textBox1.Text = desert2p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox19.Checked == false)
            {
                listBox1.Items.Remove("Carrot Cake                                " + "$" + desert2p.Text);
                textBox1.Text = desert2p.Text; 
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox20_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox20.Checked == true)
            {
                listBox1.Items.Add("Blueberry Cheese Cake              " + "$" + desert3p.Text);
                textBox1.Text = desert3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox20.Checked == false)
            {
                listBox1.Items.Remove("Blueberry Cheese Cake              " + "$" + desert3p.Text);
                textBox1.Text = desert3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox21_CheckedChanged_1(object sender, EventArgs e)
        {

            double rd;
            if (checkBox21.Checked == true)
            {
                listBox1.Items.Add("Penut Butter Pie                         " + "$" + desert4p.Text);
                textBox1.Text = desert4p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox21.Checked == false)
            {
                listBox1.Items.Remove("Penut Butter Pie                         " + "$" + desert4p.Text);
                textBox1.Text = desert4p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox22_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox22.Checked == true)
            {
                listBox1.Items.Add("Cheese Cake                             " + "$" + desert5p.Text);
                textBox1.Text = desert5p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox22.Checked == false)
            {
                listBox1.Items.Remove("Cheese Cake                             " + "$" + desert5p.Text);
                textBox1.Text = desert5p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox23_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox23.Checked == true)
            {
                listBox1.Items.Add("Infinity Sweet                             " + "$" + desert6p.Text);
                textBox1.Text = desert6p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox23.Checked == false)
            {
                listBox1.Items.Remove("Infinity Sweet                             " + "$" + desert6p.Text);
                textBox1.Text = desert6p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox6.Checked == true)
            {
                listBox1.Items.Add("Ramen Chicken                           " + "$" + noddle3p.Text);
                textBox1.Text = noddle3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox6.Checked == false)
            {
                listBox1.Items.Remove("Ramen Chicken                           " + "$" + noddle3p.Text);
                textBox1.Text = noddle3p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            double rd;
            if (checkBox8.Checked == true)
            {
                listBox1.Items.Add("Udon Noddle                               " +  "$" + noddle5p.Text);
                textBox1.Text = noddle5p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic + double.Parse(textBox1.Text);
                textBox1.Text = "$" + ic.ToString();
            }
            else if (checkBox8.Checked == false)
            {
                listBox1.Items.Remove("Udon Noddle                               " +   "$" + noddle5p.Text);

                textBox1.Text = noddle5p.Text;
                rd = double.Parse(textBox1.Text);
                ic = ic - rd;
                textBox1.Text = "$" + ic.ToString();
                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false && checkBox17.Checked == false && checkBox18.Checked == false && checkBox19.Checked == false && checkBox20.Checked == false && checkBox21.Checked == false && checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    ic = 0;
                    textBox1.Text = ic.ToString();
                }
            }
        }

        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Step 1 : Click the Number that you want on the Number Key" + "\n" + "Step 2 : Click the check box that you wana eat." + "\n" + "Step 3 : Check your order list and Bill" + "\n" + "Step4 : Click the Order :)");
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            panel44.Height = button10.Height;
            panel44.Top = button10.Top;
            home1.Show();
            home1.BringToFront();

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            panel44.Height = button14.Height;
            panel44.Top = button14.Top;
            home1.Hide();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            panel44.Height = button12.Height;
            panel44.Top = button12.Top;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox2.Text), int.Parse(textBox5.Text));

            try
            {
                client.Connect(IP_End);
                if (client.Connected)
                {
                    label30.Text = "Connected to Sever  " + "\n";
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;

                    backgroundWorker1.RunWorkerAsync();                      //start Receving data in BackGround
                    backgroundWorker2.WorkerSupportsCancellation = true;    //Ability to cancel this thread
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string gg = "";


            if (checkBox1.Checked == true)
            {
                gg += "Triple-Decker Burger " + numericUpDown1.Value + "\n";
            }

            if (checkBox2.Checked == true)
            {
                gg += "Mashed Potato Burger " + numericUpDown2.Value + "\n";
            }

            if (checkBox5.Checked == true)
            {
                gg += "Cheese-Stuffed Burger " + numericUpDown3.Value + "\n";
            }

            if (checkBox3.Checked == true)
            {
                gg += "Korean Spicy Noodle " + numericUpDown4.Value + "\n";
            }

            if (checkBox6.Checked == true)
            {
                gg += "Ramen Chicken " + numericUpDown6.Value + "\n";

            }

            if (checkBox7.Checked == true)
            {
                gg += "Egg Noodle " + numericUpDown7.Value + "\n";

            }

            if (checkBox8.Checked == true)
            {
                gg += "Udon Noodle " + numericUpDown8.Value + "\n";

            }

            if (checkBox9.Checked == true)
            {
                gg += "Ramen Pork " + numericUpDown9.Value + "\n";

            }

            if (checkBox10.Checked == true)
            {
                gg += "Sea Food Noodle " + numericUpDown10.Value + "\n";

            }

            if (checkBox11.Checked == true)
            {
                gg += "Beef Rips " + numericUpDown11.Value + "\n";

            }

            if (checkBox12.Checked == true)
            {
                gg += "Grilled Peruvian Chicken " + numericUpDown12.Value + "\n";

            }

            if (checkBox13.Checked == true)
            {
                gg += "Grilled Balsamic Pork " + numericUpDown13.Value + "\n";

            }
            if (checkBox14.Checked == true)
            {
                gg += "Watermelon Juice " + numericUpDown14.Value + "\n";

            }
            if (checkBox15.Checked == true)
            {
                gg += "Orange Juice " + numericUpDown15.Value + "\n";

            }
            if (checkBox16.Checked == true)
            {
                gg += "Stawberry Juice " + numericUpDown16.Value + "\n";

            }
            if (checkBox17.Checked == true)
            {
                gg += "Pineapple Juice " + numericUpDown17.Value + "\n";

            }
            if (checkBox18.Checked == true)
            {
                gg += "Texas Sheet Cake " + numericUpDown18.Value + "\n";


            }
            if (checkBox19.Checked == true)
            {
                gg += "Carrot Cake " + numericUpDown19.Value + "\n";

            }
            if (checkBox20.Checked == true)
            {
                gg += "Blueberry Cheese Cake " + numericUpDown20.Value + "\n";

            }
            if (checkBox21.Checked == true)
            {
                gg += "Peanut Butter Pie " + numericUpDown21.Value + "\n";

            }
            if (checkBox22.Checked == true)
            {
                gg += "Cheese Cake " + numericUpDown22.Value + "\n";

            }
            if (checkBox23.Checked == true)
            {
                gg += "Infinity Sweet " + numericUpDown23.Value + "\n";

            }

            text_to_send = gg;
            backgroundWorker2.RunWorkerAsync();
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                hh= textBox7.Text;
                backgroundWorker4.RunWorkerAsync();
            }
            textBox7.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(textBox3.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            backgroundWorker1.RunWorkerAsync();                      //start Receving data in BackGround
            backgroundWorker3.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;    //Ability to cancel this thread
            backgroundWorker4.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" * ground beef \n * salt \n * pepper \n * burger buns \n *  american cheese", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        { 
         MessageBox.Show("*russet potatoes\n*cloves garlic \n*cold water \n*cup butter  \n*cup butter\n*salt\n*pepper\n*fresh parsley\n*provolone cheese\n*panko breadcrumbs \n*eggs\n*oil", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*ground beef\n*salt \n*pepper \n*oz cheddar cheese block\n*hawaiian sweet roll", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Korean noodles\n*beef\n*mushrooms\n*carrots\n*green onions\n spinach", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("* water\n* beef\n* scallion\n* carrots\n* vegetable oil\n* garlic\n* white onion\n* sugar\n", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*water\n*scallion\n*carrots\n*vegetable oil\n*garlic\n*white onion\n*sugar\n*ramen noodles\n*chicken breast\n*sesame oil", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("the flour and salt\n*the beaten egg\n*milk\n butter", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sesame oil\n onion\n*cabbage\n* mushrooms\n* onions", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*onion\n*garlic\n*mushrooms\n*scallops\n*water\n*shrimp flavored ramen noodles\n*sour cream\n*pepper\n*cooked medium shrimp\n*crabmeat", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*onion\n*garlic\n*mushrooms\n*scallops\n*water\n*shrimp flavored ramen noodles\n*sour cream\n*pepper\n*cooked medium shrimp\n*crabmeat", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*tomato sauce\n*barbecue sauce\n*cola\n*honey\n*brown sugar\n*vinegar\n*white pepper\n*hot sauce\n*garlic", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*jalapeño chilies,\n*ají amarillo pepper \n*cilantro leaves \n*garlic\n*mayonnaise\n*sour cream\n*fresh juice from lime \n*white vinegar\n*olive oil\n*Kosher salt and freshly ground black pepper", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*Balsamic vinegar\n*Dijon mustard\n*fresh basil \n*salt\n*black pepper\n*olive oil\n*boneless pork loin chops", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            MessageBox.Show("* sweet watermelon\n*small lime, juiced", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*oranges\n*pink salt\n*ginger", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*Strawberries\n*Lemon juice\n*Sugar\n*Salt\n*Water", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            MessageBox.Show("*pineapple\n*water\n*ice cubesr\n*sugar\n*black salt\n*roasted cumin powder", "Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    gg = STR.ReadLine();
                    this.textBox6.Invoke(new MethodInvoker(delegate () { textBox6.AppendText(gg + "\n"); }));
                    receive = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }

            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {

            if (client.Connected)
            {
                STW.WriteLine(hh);
                this.textBox6.Invoke(new MethodInvoker(delegate () { textBox6.AppendText(hh + "\n"); }));
            }
            else
            {
                MessageBox.Show("Send Failed");
            }
        }
    }
}




    

