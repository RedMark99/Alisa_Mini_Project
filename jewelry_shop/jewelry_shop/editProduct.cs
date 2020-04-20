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
    public partial class editProduct : Form
    {

        internal int TitleIds;
        internal int MaterialIds;
        public editProduct()
        {
            InitializeComponent();
            UpdateDataGridViewMaterial();
            UpdateDataGridViewTitle();
        }

        public void UpdateDataGridViewMaterial()
        {
            //отчистка dateGridView данных

            dataGridViewMaterial.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridViewMaterial.SelectAll();
            dataGridViewMaterial.ClearSelection();
            dataGridViewMaterial.Columns.Clear();



            //создание колонок заранее
            dataGridViewMaterial.Columns.Add("Column0", "Код материала");
            dataGridViewMaterial.Columns.Add("Column1", "Название материала");
            dataGridViewMaterial.Columns.Add("Column2", "Цена за грамм");

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



            //создание колонок заранее
            dataGridViewTitle.Columns.Add("Column0", "Код изделия");
            dataGridViewTitle.Columns.Add("Column1", "Изделия");
            dataGridViewTitle.Columns.Add("Column2", "Тип");

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

        private void dataGridViewMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = dataGridViewMaterial.CurrentCell.RowIndex;

            MaterialIds = Convert.ToInt32(dataGridViewMaterial.Rows[indexRow].Cells[0].Value);
        }

        private void Badd_Click(object sender, EventArgs e)
        {

        }
    }
}
