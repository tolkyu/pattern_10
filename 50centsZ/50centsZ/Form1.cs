using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _50centsZ
{
    public partial class Form1 : Form
    {
        Coin coin = new Coin();
        Client client = new Client();
        Handler fiveCop = new FiveCopHandler();
        Handler tenCop = new TenCopHandler();
        Handler twentyFiveCop = new TwentyFiveCopHandler();
        Handler fiftyCop = new FiftyCopHandler();
        Handler oneHundertCop = new OneHundertCopHandler();
        public Form1()
        {
            InitializeComponent();
            fiveCop.Successor = tenCop;
            tenCop.Successor = twentyFiveCop;
            twentyFiveCop.Successor = fiftyCop;
            fiftyCop.Successor = oneHundertCop;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDropTheMonet_Click(object sender, EventArgs e)
        {
            coin.Weight = Convert.ToInt32(textBoxDiametr.text);
            coin.Diameter = Convert.ToInt32(textBoxWeight.text);
            fiveCop.HandleRequest(coin, client);
            if (client.Summ>=100)
            {
                label.Text = (client.Summ / 100).ToString() + " UAH " + (client.Summ % 100).ToString() + " cops";
            }
            else
            {
                label.Text = client.Summ.ToString() + " cops";
            }
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Weigth: 5 / Diameter: 5","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnTen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Weigth: 10 / Diameter: 10", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Weigth: 25 / Diameter: 25", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Weigth: 50 / Diameter: 50", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Weigth: 100 / Diameter: 100", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(Coin coin, Client client);
    }

    class FiveCopHandler : Handler
    {
        public override void HandleRequest(Coin coin, Client client)
        {
            if (coin.Weight == 5 && coin.Diameter == 5)
            {
                client.Summ += 5;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(coin, client);
            }
        }
    }
    class TenCopHandler : Handler
    {
        public override void HandleRequest(Coin coin, Client client)
        {
            if (coin.Weight == 10 && coin.Diameter == 10)
            {
                client.Summ += 10;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(coin, client);
            }
        }
    }
    class TwentyFiveCopHandler : Handler
    {
        public override void HandleRequest(Coin coin, Client client)
        {
            if (coin.Weight == 25 && coin.Diameter == 25)
            {
                client.Summ += 25;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(coin, client);
            }
        }
    }
    class FiftyCopHandler : Handler
    {
        public override void HandleRequest(Coin coin, Client client)
        {
            if (coin.Weight == 50 && coin.Diameter == 50)
            {
                client.Summ += 50;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(coin, client);
            }
        }
    }
    class OneHundertCopHandler : Handler
    {
        public override void HandleRequest(Coin coin, Client client)
        {
            if (coin.Weight == 100 && coin.Diameter == 100)
            {
                client.Summ += 100;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(coin, client);
            }
            else
            {
                MessageBox.Show("DONT EVEN TRY TO CHEAT!","CHEATER",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
        }
    }
    class Coin
    {
        public int Weight { get; set; }
        public int Diameter { get; set; }
    }
    class Client
    {
        public int Summ { get; set; }
    }
    




}
