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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Start();
        }
        void Start() {
            label1.Text = "Felhasználónév:";
            label2.Text = "Jelszó:";
            label1.AutoSize = true;
            label2.AutoSize = true;
            textBox2.PasswordChar = '*';

            button1.Click += (s, e) => { 
                
            };

        }
    }
}
