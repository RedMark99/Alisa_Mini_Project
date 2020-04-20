using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jewelry_shop
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
            LoginTB.Text = "ЛОГИН";
            PasswordTB.Text = "ПАРОЛЬ";
        }

        public void addAdmin()
        {
            using (var context = new MyDbContext())
            {
                var queryAdmin = context.Users.Where(x => x.Login == "admin" && x.Password == "111111");
                var user = new User()
                {
                    Login = "admin",
                    Password = "111111"
                };
                if (queryAdmin.ToList().Count < 1)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }

            }
        }

        private void BAuto_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {

                var query = context.Users.Where(x => x.Login == LoginTB.Text && x.Password == PasswordTB.Text);

                if (LoginTB.Text == "admin" && PasswordTB.Text == "111111")
                {
                    Session.admin = true;
                    AdminMenu adminmenu = new AdminMenu();
                    adminmenu.Show();
                    this.Visible = false;
                }

                else if (query.ToList().Count > 0)
                {
                    Session.admin = false;
                    AdminMenu adminmenu = new AdminMenu();
                    adminmenu.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("НЕВЕРНО ВВЕДЕНЛОГИН ИЛИ ПАРОЛЬ");
                }
            }
        }

        private void LoginTB_Enter(object sender, EventArgs e)
        {
            if (LoginTB.Text == "ЛОГИН")
            {
                LoginTB.Text = "";
            }
        }

        private void LoginTB_Leave(object sender, EventArgs e)
        {
            if (LoginTB.Text == "")
            {
                LoginTB.Text = "ЛОГИН";
            }
        }

        private void PasswordTB_Enter(object sender, EventArgs e)
        {
            if (PasswordTB.Text == "ПАРОЛЬ")
            {
                PasswordTB.Text = "";
            }
        }

        private void PasswordTB_Leave(object sender, EventArgs e)
        {
            if (PasswordTB.Text == "")
            {
                PasswordTB.Text = "ПАРОЛЬ";
            }
        }

        private void Autorization_Load(object sender, EventArgs e)
        {

        }

        private void PasswordTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
