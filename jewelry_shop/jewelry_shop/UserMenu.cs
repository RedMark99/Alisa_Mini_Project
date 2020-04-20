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
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();

            CBCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            CBName.DropDownStyle = ComboBoxStyle.DropDownList;
            CBTitleName.DropDownStyle = ComboBoxStyle.DropDownList;
            CBType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BActual_Click(object sender, EventArgs e)
        {
            try
            {
                //отчистка dateGridView данных

                dataGridView.Rows.Clear();

                //отчистка dateGridView вместе с шапкой

                dataGridView.SelectAll();
                dataGridView.ClearSelection();
                dataGridView.Columns.Clear();



                //создание колонок заранее
                dataGridView.Columns.Add("Column0", "НАЗВАНИЕ");
                dataGridView.Columns.Add("Column1", "КОЛИЧЕСТВО");

                //подключение к базе данных MicroSoft Sql server
                using (var context = new MyDbContext())
                {
                    //запрос для заполнения частично dataGridView без заранее созданных колонок не получится

                    var query = from x in context.Titles
                                where x.Name == CBName.SelectedItem.ToString()
                                select new
                                {
                                    id = x.TitleId,
                                    name = x.Name,
                                    type = x.Type
                                };

                    var res = from x in context.Sales
                              join y in query
                              on x.TitleId equals y.id
                              where x.TitleId == y.id
                              group y by y.name into g
                              select new
                              {
                                  name = g.Key,
                                  count = g.Select(x => x.name).Count()
                              };

                    //считывание в datagrid view
                    foreach (var item in res.ToList())
                    {
                        dataGridView.Rows.Add(item.name, item.count.ToString());
                    }

                    dataGridView.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

                }
            }
            catch (System.NotSupportedException error) 
            {
                MessageBox.Show("ВЫБЕРИТЕ ДАННЫЕ ИЗ СПИСКА", "ОШИБКА");
            }

        }

        public void addcombobox() 
        {
            using (var context = new MyDbContext()) 
            {

                var query = from x in context.Titles
                            select new
                            {
                                name = x.Name,
                            };

                var query2 = query.Distinct();

                foreach (var x in query2.ToList()) 
                {
                    CBName.Items.Add(x.name);
                    CBTitleName.Items.Add(x.name);
                }
                ///

                var query3 = from x in context.Titles
                            select new
                            {
                                name = x.Type,
                            };

                var query4 = query3.Distinct();

                foreach (var x in query4.ToList())
                {
                    CBType.Items.Add(x.name);
                }

                CBTitleName.Items.Add("ВСЕ");
                ////

                var query5 = from x in context.Materials
                             select new
                             {
                                 name = x.Name
                             };

                foreach (var x in query5.ToList())
                {
                    CBCategory.Items.Add(x.name);
                }

            }

        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            addcombobox();
            CBCategory.SelectedIndex = 0;
            CBName.SelectedIndex = 0;
            CBTitleName.SelectedIndex = 0;
            CBType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //отчистка dateGridView данных

                dataGridView.Rows.Clear();

                //отчистка dateGridView вместе с шапкой

                dataGridView.SelectAll();
                dataGridView.ClearSelection();
                dataGridView.Columns.Clear();



                //создание колонок заранее
                dataGridView.Columns.Add("Column0", "НАЗВАНИЕ ИЗДЕЛИЯ");
                dataGridView.Columns.Add("Column1", "ТИП ИЗДЕЛИЯ ");
                dataGridView.Columns.Add("Column2", "НАЗВАНИЕ МАТЕРИАЛА");

                //подключение к базе данных MicroSoft Sql server
                using (var context = new MyDbContext())
                {
                    //Запрос для заполнения частично dataGridView без заранее созданых колонок не получится

                    var query = from x in context.Titles
                                where x.Type == CBType.SelectedItem.ToString()
                                select new
                                {
                                    TitleId = x.TitleId,
                                    name = x.Name,
                                    type = x.Type
                                };

                    var res = from x in context.Products
                              from y in query
                              from z in context.Materials
                              where x.MaterialId == z.MaterialID && y.TitleId == x.TitleId
                              select new
                              {
                                  name = y.type,
                                  type = y.name,
                                  material = z.Name
                              };

                    //считывание в datagrid view
                    foreach (var item in res.ToList())
                    {
                        dataGridView.Rows.Add(item.name, item.type, item.material);
                    }

                    dataGridView.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

                }
            }
            catch (System.NotSupportedException error)
            {
                MessageBox.Show("ВЫБЕРИТЕ ДАННЫЕ ИЗ СПИСКА", "ОШИБКА");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //отчистка dateGridView данных

                dataGridView.Rows.Clear();

                //отчистка dateGridView вместе с шапкой

                dataGridView.SelectAll();
                dataGridView.ClearSelection();
                dataGridView.Columns.Clear();



                //создание колонок заранее
                dataGridView.Columns.Add("Column0", "НАЗВАНИЕ ИЗДЕЛИЯ");
                dataGridView.Columns.Add("Column1", "ТИП ИЗДЕЛИЯ");
                dataGridView.Columns.Add("Column2", "МАТЕРИАЛ ИЗДЕЛИЯ");

                //подключение к базе данных MicroSoft Sql server
                using (var context = new MyDbContext())
                {
                    //запрос для заполнения частично dataGridView без заранее созданных колонок не получится

                    var query = from x in context.Materials
                                where x.Name == CBCategory.SelectedItem.ToString()
                                select new
                                {
                                    MaterialID = x.MaterialID,
                                    name = x.Name,
                                    type = x.GramPrice
                                };

                    var res = from x in context.Products
                              from z in query
                              from y in context.Titles
                              where x.MaterialId == z.MaterialID && y.TitleId == x.TitleId
                              select new
                              {
                                  name = y.Type,
                                  type = y.Name,
                                  material = z.name
                              };

                    //считывание в datagrid view
                    foreach (var item in res.ToList())
                    {
                        dataGridView.Rows.Add(item.name, item.type, item.material);
                    }

                    dataGridView.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

                }
            }
            catch (System.NotSupportedException error)
            {
                MessageBox.Show("ВЫБЕРИТЕ ДАННЫЕ ИЗ СПИСКА", "ОШИБКА");
            }
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {

                //отчистка dateGridView данных

                dataGridView.Rows.Clear();

                //отчистка dateGridView вместе с шапкой

                dataGridView.SelectAll();
                dataGridView.ClearSelection();
                dataGridView.Columns.Clear();



                //создание колонок заранее
                dataGridView.Columns.Add("Column0", "ФАМИЛИЯ");
                dataGridView.Columns.Add("Column1", "ИМЯ");
                dataGridView.Columns.Add("Column2", "ОТЧЕСТВО");
                dataGridView.Columns.Add("Column3", "ДАТА ЗАКАЗА");
                dataGridView.Columns.Add("Column4", "НАЗВАНИЕ ИЗДЕЛИЯ");

                DateTime DTPbegins = DateTime.Parse(DTPBegin.Value.ToShortDateString().ToString());
                DateTime DTPEnds = DateTime.Parse(DTPEnd.Value.ToShortDateString().ToString());

                var sale = context.Sales.Where(x => DTPbegins <= x.SaleDate && x.SaleDate <= DTPEnds);

                if (CBTitleName.SelectedItem.ToString() == "ВСЕ")
                {

                    var res = from x in sale
                              from i in context.Titles
                              where i.TitleId == x.TitleId
                              select new
                              {
                                  Name = x.Name,
                                  Sname = x.SName,
                                  Fname = x.FName,
                                  Date = x.SaleDate,
                                  NameTitle = i.Name
                              };

                    foreach (var item in res.ToList())
                    {
                        dataGridView.Rows.Add(item.Sname, item.Name, item.Fname, item.Date, item.NameTitle);
                    }

                    dataGridView.AllowUserToAddRows = false;
                }

                else 
                {
                    var res = from x in sale
                              from i in context.Titles
                              where i.TitleId == x.TitleId && i.Name == CBTitleName.SelectedItem.ToString()
                              select new
                              {
                                  Name = x.Name,
                                  Sname = x.SName,
                                  Fname = x.FName,
                                  Date = x.SaleDate,
                                  NameTitle = i.Name
                              };

                    foreach (var item in res.ToList())
                    {
                        dataGridView.Rows.Add(item.Sname, item.Name, item.Fname, item.Date, item.NameTitle);
                    }

                    dataGridView.AllowUserToAddRows = false;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {

                //отчистка dateGridView данных

                dataGridView.Rows.Clear();

                //отчистка dateGridView вместе с шапкой

                dataGridView.SelectAll();
                dataGridView.ClearSelection();
                dataGridView.Columns.Clear();



                //создание колонок заранее
                dataGridView.Columns.Add("Column0", "НАЗВАНИЕ ИЗДЕЛИЯ");
                dataGridView.Columns.Add("Column1", "МАТЕРИАЛ ИЗДЕЛИЯ");
                dataGridView.Columns.Add("Column2", "ТИП ИЗДЕЛИЯ");
                dataGridView.Columns.Add("Column3", "СУММА ЗАКАЗА");

                if (TBCostEnd.Text != " " || TBCostBegin.Text != " ")
                {

                    int Start = int.Parse(TBCostBegin.Text);
                    int End = int.Parse(TBCostEnd.Text);

                    var product = context.Products.Where(x => Start <= x.Price && x.Price <= End);

                    var res = from x in product
                              from i in context.Titles
                              from y in context.Materials
                              where i.TitleId == x.TitleId && y.MaterialID == x.MaterialId
                              select new
                              {
                                  NameTitle = i.Name,
                                  NameMaterial = y.Name,
                                  NameType = i.Type,
                                  Price = x.Price.ToString()
                              };


                    foreach (var item in res.ToList())
                    {
                        dataGridView.Rows.Add(item.NameTitle, item.NameMaterial, item.NameType, item.Price);
                    }

                    dataGridView.AllowUserToAddRows = false;
                }
                else 
                {
                    MessageBox.Show("УКАЖИТЕ ЦЕНОВОЙ ДИАПАЗОН");
                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CBName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
