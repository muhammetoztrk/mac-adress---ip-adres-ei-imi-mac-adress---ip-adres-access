using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;

namespace isletim_sistemi_kayanaklarına_erisim_macadresi_ipadresi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string macadres = "";
            string mac = "";
            foreach (NetworkInterface arayüz in NetworkInterface.GetAllNetworkInterfaces()) 
            {
                OperationalStatus ot = arayüz.OperationalStatus;
                if (arayüz.OperationalStatus == OperationalStatus.Up) 
                {
                    macadres = arayüz.GetPhysicalAddress().ToString();
                    break;
                }
            }
            for (int i = 0; i <= macadres.Length - 1; i++) 
            {
                mac = mac + ";" + macadres.Substring(1, 2);
                i++;
            }
            mac = mac.Remove(0, 1);
            label1.Text = mac;
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostByName(host);
            label2.Text = ip.AddressList[0].ToString();
        }
    }
}
