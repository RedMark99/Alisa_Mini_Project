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
    public partial class AddMaterial : Form
    {

        AdminMenu _owner;

        public AddMaterial(AdminMenu owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new FormClosingEventHandler(this.AddRefresh_FormClosing);
            TBName.Text = "НАЗВАНИЕ МАТЕРИАЛА";
            TBPrice.Text = "ЦЕНА";
        }

        private void AddRefresh_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.RefreshDataGridView();
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    var query = context.Materials.Where(x => x.Name == TBName.Text);

                    if (TBName.Text == "НАЗВАНИЕ ИАТЕРИАЛА" || TBPrice.Text == "ЦЕНА")
                    {
                        MessageBox.Show("ЗАПОЛНИТЕ ПОЛЯ");
                    }
                    else 
                    { 
                        var material = new Material()
                        {
                            Name = TBName.Text,
                            GramPrice = Convert.ToInt32(TBPrice.Text)
                        };

                        if (query.ToList().Count < 1)
                        {
                            context.Materials.Add(material);
                            context.SaveChanges();
                            MessageBox.Show("МАТЕРИАЛ ДОБАВЛЕН");
                            this.Close();
                        }

                        else if (query.ToList().Count > 0)
                        {
                            MessageBox.Show("ТАКОЙ МАТЕРИАЛ УЖЕ СУЩЕСТВУЕТ");
                        }
                    }
                }
                catch (System.FormatException error) 
                {
                    MessageBox.Show("ВВЕДИТЕ ЦЕНУ ЗА ГРАММ");
                }

            }
        }

        private void TBName_Enter(object sender, EventArgs e)
        {
            if (TBName.Text == "НАЗВАНИЕ МАТЕРИАЛА") 
            {
                TBName.Text = "";
            }
        }

        private void TBName_Leave(object sender, EventArgs e)
        {
            if (TBName.Text == "")
            {
                TBName.Text = "НАЗВАНИЕ МАТЕРИАЛА";
            }
        }

        private void TBPrice_Enter(object sender, EventArgs e)
        {
            if (TBPrice.Text == "ЦЕНА")
            {
                TBPrice.Text = "";
            }
        }

        private void TBPrice_Leave(object sender, EventArgs e)
        {
            if (TBPrice.Text == "")
            {
                TBPrice.Text = "ЦЕНА";
            }
        }

        private void TBPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
