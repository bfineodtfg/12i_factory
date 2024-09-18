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
            loginButton.Text = "Bejelentkezés";
            registerButton.Text = "Regisztráció";
            textBox2.PasswordChar = '*';
            databaseHandler db = new databaseHandler();

            loginButton.Click += (s, e) => {
                db.readAll();

                foreach (user item in user.users)
                {
                    if (textBox1.Text == item.username && textBox2.Text == item.password)
                    {
                        Form1 form = new Form1(item);
                        form.Show();
                        form.FormClosed += (ss, ee) => {
                            db.updatePoints(item);
                            Application.Exit();
                        };
                        this.Hide();
                    }
                }
            };
            registerButton.Click += (s, e) => {
                if (textBox1.Text.Length < 3)
                {
                    MessageBox.Show("Túl rövid a felhasználónév");
                }
                else if (textBox2.Text.Length < 3) {
                    MessageBox.Show("Túl rövid a jelszó");
                }
                else
                {
                    db.registerUser(textBox1.Text, textBox2.Text);
                    MessageBox.Show("Sikeres regisztráció!");
                }
            };



        }
    }
}
