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
    public partial class editSale : Form
    {
        
        internal int TitleIds;

        public editSale()
        {
            InitializeComponent();
            UpdateDataGridViewTitle();
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
            dataGridViewTitle.Columns.Add("Column0", "Код материала");
            dataGridViewTitle.Columns.Add("Column1", "Название материала");
            dataGridViewTitle.Columns.Add("Column2", "Цена за грамм");

            //подключение к базе данных MicroSoft Sql server
            using (var context = new MyDbContext())
            {
                //запрос для заполнения частично dataGridView без заранее созданынх колонок не получится
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

        private void editSale_Load(object sender, EventArgs e)
        {

        }

        private void TBSName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Badd_Click(object sender, EventArgs e)
        {

        }
    }
}
