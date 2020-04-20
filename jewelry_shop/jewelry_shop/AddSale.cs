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
    public partial class AddSale : Form
    {

        int TitleIds;
        AdminMenu _owner;
        MyDbContext db = new MyDbContext();
        public AddSale(AdminMenu owner)
        {
            InitializeComponent();
            UpdateDataGridViewTitle();
            _owner = owner;
            this.FormClosing += new FormClosingEventHandler(this.AddRefresh_FormClosing);
            TBSName.Text = "ФАМИЛИЯ";
            TBName.Text = "ИМЯ";
            TBFName.Text = "ОТЧЕСТВО";
        }

        private void AddRefresh_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.RefreshDataGridView();
        }


        public void UpdateDataGridViewTitle()
        {
            //отчистка dateGridView данных

            dataGridViewTitle.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridViewTitle.SelectAll();
            dataGridViewTitle.ClearSelection();
            dataGridViewTitle.Columns.Clear();



            //создание колонок заранее
            dataGridViewTitle.Columns.Add("Column0", "КОД ИЗДЕЛИЯ");
            dataGridViewTitle.Columns.Add("Column1", "НАЗВАНИЕ ИЗДЕЛИЯ");
            dataGridViewTitle.Columns.Add("Column2", "ТИП ИЗДЕЛИЯ");

            //подключение к базе данных MicroSoft Sql server
            using (var context = new MyDbContext())
            {
                //запрос для заполнения частично dataGridView без заранее созданных колонок не получится
                var res = from x in context.Titles
                          select new
                          {
                              TitleId = x.TitleId,
                              Name = x.Name,
                              Type = x.Type
                          };
                //считывание в datagrid view
                foreach (var item in res.ToList())
                {
                    dataGridViewTitle.Rows.Add(item.TitleId, item.Name, item.Type);
                }

                dataGridViewTitle.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

            }
        }

        private void dataGridViewTitle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = dataGridViewTitle.CurrentCell.RowIndex;

            TitleIds = Convert.ToInt32(dataGridViewTitle.Rows[indexRow].Cells[0].Value);
            
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new MyDbContext())
                {

                    var query = context.Sales.Where(x => x.SName == TBSName.Text && x.Name == TBName.Text && x.FName == TBFName.Text && x.TitleId == TitleIds && x.SaleDate == DateTime.Today);

                    if (TBSName.Text == "ФАМИЛИЯ" || TBName.Text == "ИМЯ" || TBFName.Text == "ОТЧЕСТВО")
                    {
                        MessageBox.Show("ЗАПОЛНИТЕ ПОЛЯ ФИО", "ОШИБКА");
                    }

                    else 
                    { 
                        var sale = new Sale()
                        {
                            TitleId = TitleIds,
                            SaleDate = DateTime.Parse(DateTime.Today.ToShortDateString().ToString()),
                            Name = TBName.Text,
                            SName = TBSName.Text,
                            FName = TBFName.Text

                        };


                        if (query.ToList().Count > 0)
                        {
                            MessageBox.Show("ТАКОЕ ИЗДЕЛИЕ УЖЕ ЗАКАЗАНО");
                        }

                        else
                        {
                            context.Sales.Add(sale);
                            context.SaveChanges();
                            db.SaveChanges();
                            MessageBox.Show("ЗАКАЗ ДОБАВЛЕН");
                            this.Close();
                        }
                    }

                }
            }
            catch (System.NullReferenceException error)
            {
                MessageBox.Show("ВЫБЕРИТЕ ИЗДЕЛИЕ", "ОШИБКА");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException error) 
            {
                MessageBox.Show("ВЫБЕРИТЕ ИЗДЕЛИЕ", "ОШИБКА");
            }

        }

        private void TBSName_Enter(object sender, EventArgs e)
        {
            if (TBSName.Text == "ФАМИЛИЯ")
            {
                TBSName.Text = "";
            }
        }

        private void TBSName_Leave(object sender, EventArgs e)
        {
            if (TBSName.Text == "")
            {
                TBSName.Text = "ФАМИЛИЯ";
            }
        }

        private void TBName_Enter(object sender, EventArgs e)
        {
            if (TBName.Text == "ИМЯ")
            {
                TBName.Text = "";
            }
        }

        private void TBName_Leave(object sender, EventArgs e)
        {
            if (TBName.Text == "")
            {
                TBName.Text = "ИМЯ";
            }
        }

        private void TBFName_Enter(object sender, EventArgs e)
        {
            if (TBFName.Text == "ОТЧЕСТВО")
            {
                TBFName.Text = "";
            }
        }

        private void TBFName_Leave(object sender, EventArgs e)
        {
            if (TBFName.Text == "")
            {
                TBFName.Text = "ОТЧЕСТВО";
            }
        }

        private void dataGridViewTitle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TBFName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
