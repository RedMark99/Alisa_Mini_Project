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
    public partial class AddTitle : Form
    {

        AdminMenu _owner;

        public AddTitle(AdminMenu owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new FormClosingEventHandler(this.AddRefresh_FormClosing);
            TBName.Text = "НАЗВАНИЕ ИЗДЕЛИЯ";
            TBType.Text = "ТИП ИЗДЕЛИЯ";
        }

        private void AddRefresh_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.RefreshDataGridView();
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {

                var query = context.Titles.Where(x => x.Name == TBName.Text && x.Type == TBType.Text);

                if (TBName.Text == "НАЗВАНИЕ ИЗДЕЛИЯ" || TBType.Text == "ТИП ИЗДЕЛИЯ")
                {
                    MessageBox.Show("ЗАПОЛНИТЕ ПОЛЯ ТАБЛИЦЫ", "ОШИБКА");
                }

                else
                { 
                    var title = new Title()
                    {
                        Name = TBName.Text,
                        Type = TBType.Text
                    };

                    if (query.ToList().Count < 1)
                    {
                        context.Titles.Add(title);
                        context.SaveChanges();
                        MessageBox.Show("ИЗДЕЛИЕ ДОБАВЛЕННО");
                        this.Close();
                    }

                    else if (query.ToList().Count > 0)
                    {
                        MessageBox.Show("ТАКОЕ ИЗДЕЛИЕ УЖЕ СУЩЕСТВУЕТ");
                    }
                }
            }
        }

        private void TBName_Enter(object sender, EventArgs e)
        {
            if (TBName.Text == "НАЗВАНИЕ ИЗДЕЛИЯ")
            {
                TBName.Text = "";
            }
        }

        private void TBName_Leave(object sender, EventArgs e)
        {
            if (TBName.Text == "")
            {
                TBName.Text = "НАЗВАНИЕ ИЗДЕЛИЯ";
            }
        }

        private void TBType_Enter(object sender, EventArgs e)
        {
            if (TBType.Text == "ТИП ИЗДЕЛИЯ")
            {
                TBType.Text = "";
            }
        }

        private void TBType_Leave(object sender, EventArgs e)
        {
            if (TBType.Text == "")
            {
                TBType.Text = "ТИП ИЗДЕЛИЯ";
            }
        }
    }
}
