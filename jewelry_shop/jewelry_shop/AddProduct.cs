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
    public partial class AddProduct : Form
    {

        public int TitleIds;
        public int MaterialIds;
        MyDbContext db = new MyDbContext();
        AdminMenu _owner;
        public AddProduct(AdminMenu owner)
        {
            InitializeComponent();
            UpdateDataGridViewTitle();
            UpdateDataGridViewMaterial();
            _owner = owner;
            this.FormClosing += new FormClosingEventHandler(this.AddRefresh_FormClosing);
            TBWeight.Text = "ВЕС ИЗДЕЛИЯ";
        }

        private void AddRefresh_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.RefreshDataGridView();
        }

        public void UpdateDataGridViewMaterial()
        {
            //отчистка dateGridView данных

            dataGridViewMaterial.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridViewMaterial.SelectAll();
            dataGridViewMaterial.ClearSelection();
            dataGridViewMaterial.Columns.Clear();



            //создание колонки заранее
            dataGridViewMaterial.Columns.Add("Column0", "КОД МАТЕРИАЛА");
            dataGridViewMaterial.Columns.Add("Column1", "НАЗВАНИЕ МАТЕРИАЛА");
            dataGridViewMaterial.Columns.Add("Column2", "ЦЕНА ЗА ГРАММ");

            //подключение к базе данных MicroSoft Sql server
            using (var context = new MyDbContext())
            {
                //запрос для заполнения частично dataGridView без заранее созданных колонок не получится
                var res = from x in context.Materials
                          select new
                          {
                              MaterialId = x.MaterialID,
                              Name = x.Name,
                              GramPrice = x.GramPrice
                          };
                //считывание в datagrid view
                foreach (var item in res.ToList())
                {
                    dataGridViewMaterial.Rows.Add(item.MaterialId, item.Name, item.GramPrice);
                }

                dataGridViewMaterial.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

            }
        }

        public void UpdateDataGridViewTitle()
        {
            //отчистка dateGridView данных

            dataGridViewTitle.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridViewTitle.SelectAll();
            dataGridViewTitle.ClearSelection();
            dataGridViewTitle.Columns.Clear();



            //создание колонки заранее
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

        private void Badd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new MyDbContext())
                {

                    var query = context.Products.Where(x => x.MaterialId == MaterialIds && x.TitleId == TitleIds);

                    var query2 = context.Materials.Where(x => x.MaterialID == MaterialIds).Select(x => x.GramPrice).ToList();

                    int sum = 0;

                    foreach (int x in query2.ToList())
                    {
                        sum = x;
                    }

                    int price = (Convert.ToInt32(TBWeight.Text) * sum) + 2000;


                    var product = new Product()
                    {
                        TitleId = TitleIds,
                        MaterialId = MaterialIds,
                        Weight = Convert.ToInt32(TBWeight.Text),
                        Price = price
                    };


                    if (query.ToList().Count > 0)
                    {
                        MessageBox.Show("ТАКОЕ ИЗДЕЛИЕ УЖЕ СУЩЕСТВУЕТ");
                    }

                    else
                    {
                        context.Products.Add(product);
                        context.SaveChanges();
                        db.SaveChanges();
                        MessageBox.Show("ИЗДЕЛИЕ ДОБАВЛЕННО");
                        this.Close();
                    }

                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException error)
            {
                MessageBox.Show("ВЫБЕРИТЕ ДАННЫЕ ИЗ ТАБЛИЦЫ", "ОШИБКА");
            }
            catch (System.FormatException error) 
            {
                MessageBox.Show("ВВЕДИТЕ ВЕС", "ОШИБКА");
            }
        }

        public void Price() 
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    if (TitleIds > 0 && MaterialIds > 0)
                    {
                        int sum = 0;

                        var query2 = context.Materials.Where(x => x.MaterialID == MaterialIds).Select(x => x.GramPrice).ToList();

                        foreach (int x in query2.ToList())
                        {
                            sum = x;
                        }

                        int price = (Convert.ToInt32(TBWeight.Text) * sum) + 2000;

                        TBPrice.Text = price.ToString();
                    }
                }
                catch (System.FormatException error) 
                {
                    MessageBox.Show("ВВЕДИТЕ ВЕС");
                }
            }
        }

        private void dataGridViewTitle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = dataGridViewTitle.CurrentCell.RowIndex;

            TitleIds = Convert.ToInt32(dataGridViewTitle.Rows[indexRow].Cells[0].Value);

            Price();
        }

        private void dataGridViewMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = dataGridViewMaterial.CurrentCell.RowIndex;

            MaterialIds = Convert.ToInt32(dataGridViewMaterial.Rows[indexRow].Cells[0].Value);

            Price();
        }

        private void TBWeight_Enter(object sender, EventArgs e)
        {
            if (TBWeight.Text == "ВЕС ИЗДЕЛИЯ")
            {
                TBWeight.Text = "0";
            }
        }

        private void TBWeight_Leave(object sender, EventArgs e)
        {
            if (TBWeight.Text == "")
            {
                TBWeight.Text = "ВЕС ИЗДЕЛИЯ";
            }
        }

        private void TBWeight_TextChanged(object sender, EventArgs e)
        {
            Price();
        }
    }
}
