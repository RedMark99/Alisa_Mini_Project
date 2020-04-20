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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            TBPassword.Text = "ВВЕДИТЕ ПАРОЛЬ";
            TBLogin.Text = "ВВЕДИТЕ ЛОГИН";
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (TBPassword.Text == "ВВЕДИТЕ ПАРОЛЬ")
            {
                TBPassword.Text = "";
            }
        }

        private void TBPassword_Leave(object sender, EventArgs e)
        {
            if (TBPassword.Text == "")
            {
                TBPassword.Text = "ВВЕДИТЕ ПАРОЛЬ";
            }
        }

        private void TBLogin_Enter(object sender, EventArgs e)
        {
            if (TBLogin.Text == "ВВЕДИТЕ ЛОГИН")
            {
                TBLogin.Text = "";
            }
        }

        private void TBLogin_Leave(object sender, EventArgs e)
        {
            if (TBLogin.Text == "")
            {
                TBLogin.Text = "ВВЕДИТЕ ЛОГИН";
            }
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {

                var query = context.Users.Where(x => x.Login == TBLogin.Text);

                var user = new User()
                {
                    Login = TBLogin.Text,
                    Password = TBPassword.Text
                };

                if (query.ToList().Count < 1)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("ПОЛЬЗОВАТЕЛЬ ДОБАВЛЕН");
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("ТАКОЙ ЛОГИН УЖЕ СУЩЕСТВУЕТ");
                }
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
