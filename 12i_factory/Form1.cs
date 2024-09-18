using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12i_factory
{
    public partial class Form1 : Form
    {
        user User;
        int money;
        public Form1(user User)
        {
            this.User = User;
            InitializeComponent();
            Start();
        }
        int grassUpgrade = 100;
        int factoryUpgrade = 300;
        int factoryLevel = 0;
        int basePrice = 1;
        int autoPrice = 400;
        List<grass> items = new List<grass>();
        void Start() {
            updateMoney(User.points);
            updatePriceFactory(factoryUpgrade);
            updatePrice(grassUpgrade);
            updatePriceAuto(autoPrice);
            source.Click += (s, e) => {
                grass one = new grass();
                this.Controls.Add(one);
                items.Add(one);
                one.Top = belt1.Top;
                one.Left = belt1.Left;
                one.Width = belt1.Width;
                one.Height = belt2.Height;
                one.BackColor = Color.Red;
                one.BringToFront();
                one.price = basePrice;
            };
            label3.Click += (s, e) => {
                if (money >= grassUpgrade)
                {
                    updateMoney(-grassUpgrade);
                    basePrice *= 2;
                    grassUpgrade *= 2;
                    updatePrice(grassUpgrade);
                }
            };
            Timer FactoryTimer = new Timer();
            label2.Click += (s, e) => {
                if (money >= factoryUpgrade)
                {
                    updateMoney(-factoryUpgrade);
                    factoryUpgrade *= 3;
                    updatePriceFactory(factoryUpgrade);
                    factoryLevel++;
                    FactoryTimer.Start();
                }
            };
            Timer autoTimer = new Timer();
            label4.Click += (s, e) => {
                if (money >= autoPrice)
                {
                    updateMoney(-autoPrice);
                    autoPrice *= 3;
                    updatePriceAuto(autoPrice);
                    autoTimer.Interval -= 50;
                    autoTimer.Start();
                }
            };
            autoTimer.Interval = 1000;
            autoTimer.Tick += (s, e) => {
                grass one = new grass();
                this.Controls.Add(one);
                items.Add(one);
                one.Top = autoSource.Top;
                one.Left = belt1.Left;
                one.Width = belt1.Width;
                one.Height = belt2.Height;
                one.BackColor = Color.Red;
                one.BringToFront();
                one.price = basePrice;
            };



            FactoryTimer.Interval = 500;
            //0: be kell menni egy elemnek
            //1: bent van egy elem
            //2: ki kell küldeni az elemet
            int factoryState = 0;
            grass item2 = new grass();
            FactoryTimer.Tick += (s, e) => {
                if (factoryState == 0)
                {
                    try
                    {
                        item2 = items.Where(x => x.Top > factory.Top && x.Bottom < factory.Bottom).First();
                        item2.Hide();
                    }
                    catch (Exception)
                    {
                        factoryState--;
                    }
                }
                if (factoryState == 1) {
                    item2.price *= 2 * factoryLevel;
                }
                if (factoryState == 2)
                {
                    item2.Show();
                    item2.Top = factory.Bottom;
                    item2.Left = factory.Left;
                    factoryState = -1;
                }
                factoryState++;
            };


            Timer gameTimer = new Timer();
            gameTimer.Interval = 10;
            gameTimer.Tick += (s, e) => {
                foreach (grass item in items)
                {
                    if (item.Top < belt2.Top)
                    {
                        item.Top+=8;
                    }
                    else if (item.Right <= end.Left)
                    {
                        item.Left+=8;
                    }
                    else 
                    {
                        this.Controls.Remove(item);
                        updateMoney(item.price);
                        items.Remove(item);
                        break;
                    }
                }
            };
            gameTimer.Start();
        }
        void updatePrice(int number) {
            label3.Text = $"Ár: {number}$";
        }
        void updatePriceFactory(int number)
        {
            label2.Text = $"Ár: {number}$";
        }
        void updatePriceAuto(int number) {
            label4.Text = $"Ár: {number}$";
        }
        void updateMoney(int number) {
            money += number;
            User.points = money;
            label1.Text = $"Pénz: {money}$";
        }
    }
}
