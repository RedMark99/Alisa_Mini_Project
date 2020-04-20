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
    public partial class AdminMenu : Form
    {

        bool Material = false;
        bool Product = false;
        bool Sale = false;
        bool Title = false;
        MyDbContext db = new MyDbContext();

        public AdminMenu()
        {
            InitializeComponent();
            SessionAdmin();
            
        }

        public void SessionAdmin() 
        {
            if (Session.admin == false)
            {
                BDelete.Enabled = false;
                BAdduser.Enabled = false;
            }
            else 
            {
                BAdduser.Enabled = true;
                BDelete.Enabled = true;
            }
        }

        public void RefreshDataGridView()
        {
            if (Material == true)
            {
                UpdateDataGridViewMaterial();
            }
            else if (Product == true)
            {
                UpdateDataGridViewProduct();
            }
            else if (Sale == true)
            {
                UpdateDataGridViewSale();
            }
            else if (Title == true)
            {
                UpdateDataGridViewTitle();
            }
        }

        public void light()
        {
            if (Material == true)
            {
                BDataMaterial.BackColor = Color.FromArgb(224, 224, 224); // gray
                BDataProduct.BackColor = Color.White;
                BDataTitle.BackColor = Color.White;
                BDataSale.BackColor = Color.White;
            }
            else if (Product == true)
            {
                BDataMaterial.BackColor = Color.White;
                BDataProduct.BackColor = Color.FromArgb(224, 224, 224);
                BDataTitle.BackColor = Color.White;
                BDataSale.BackColor = Color.White;
            }
            else if (Title == true)
            {
                BDataMaterial.BackColor = Color.White;
                BDataProduct.BackColor = Color.White;
                BDataTitle.BackColor = Color.FromArgb(224, 224, 224);
                BDataSale.BackColor = Color.White;
            }
            else if (Sale == true)
            {
                BDataMaterial.BackColor = Color.White;
                BDataProduct.BackColor = Color.White;
                BDataTitle.BackColor = Color.White;
                BDataSale.BackColor = Color.FromArgb(224, 224, 224);
            }
        }


        private void BMaterial_Click(object sender, EventArgs e)
        {
            AddMaterial addmaterial = new AddMaterial(this);
            addmaterial.Show();
        }

        private void BTitle_Click(object sender, EventArgs e)
        {
            AddTitle addtitle = new AddTitle(this);
            addtitle.Show();
        }
        private void BProduct_Click(object sender, EventArgs e)
        {
            AddProduct addproduct = new AddProduct(this);
            addproduct.Show();
        }
        private void BSale_Click(object sender, EventArgs e)
        {
            AddSale addsale = new AddSale(this);
            addsale.Show();
        }

        public void UpdateDataGridViewMaterial()
        {
            //отчистка dateGridView данных

            dataGridView.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridView.SelectAll();
            dataGridView.ClearSelection();
            dataGridView.Columns.Clear();



            //создание колонок заранее
            dataGridView.Columns.Add("Column0", "КОД МАТЕРИАЛА");
            dataGridView.Columns.Add("Column1", "НАЗВАНИЕ МАТЕРИАЛА");
            dataGridView.Columns.Add("Column2", "ЦЕНА ЗА ГРАММ");

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
                    dataGridView.Rows.Add(item.MaterialId, item.Name, item.GramPrice);
                }

                dataGridView.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

            }
        }

        public void UpdateDataGridViewTitle()
        {
            //отчистка dateGridView данных

            dataGridView.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridView.SelectAll();
            dataGridView.ClearSelection();
            dataGridView.Columns.Clear();


            ////////////////////////////////////......................................////////////////////////////////////////////////////
            //создание колонок заранее
            dataGridView.Columns.Add("Column0", "КОД ИЗДЕЛИЯ");
            dataGridView.Columns.Add("Column1", "НАЗВАНИЕ ИЗДЕЛИЯ");
            dataGridView.Columns.Add("Column2", "ТИП ИЗДЕЛИЯ");

            //подключение к базе данных MicroSoft Sql server
            using (var context = new MyDbContext())
            {
                //Запрос для заполнения частично dataGridView без заранее созданных колонок не получится
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
                    dataGridView.Rows.Add(item.TitleId, item.Name, item.Type);
                }

                dataGridView.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

            }
        }

        public void UpdateDataGridViewProduct()
        {
            //отчистка dateGridView данных

            dataGridView.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridView.SelectAll();
            dataGridView.ClearSelection();
            dataGridView.Columns.Clear();



            //создание колонок заранее
            dataGridView.Columns.Add("Column0", "КОД ИЗДЕЛИЯ");
            dataGridView.Columns.Add("Column1", "НАЗВАНИЕ ИЗДЕЛИЯ");
            dataGridView.Columns.Add("Column2", "МАТЕРИАЛ ИЗДЕЛИЯ");
            dataGridView.Columns.Add("Column3", "ВЕС ИЗДЕЛИЯ");
            dataGridView.Columns.Add("Column4", "ЦЕНА ИЗДЕЛИЯ");

            //подключение к базе данных MicroSoft Sql server
            using (var context = new MyDbContext())
            {
                //запрос для заполнения частично dataGridView без заранее созданных колонок не получится
                var res = from x in context.Products
                          from y in context.Titles
                          from z in context.Materials
                          where x.TitleId == y.TitleId && x.MaterialId == z.MaterialID
                          select new
                          {
                              RollNo = x.RollNo,
                              TitleName = y.Name,
                              MaterialName = z.Name,
                              Weight = x.Weight,
                              Price = x.Price

                          };

                //считывание в datagrid view
                foreach (var item in res.ToList())
                {
                    dataGridView.Rows.Add(item.RollNo, item.TitleName, item.MaterialName, item.Weight, item.Price);
                }

                dataGridView.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

            }
        }

        public void UpdateDataGridViewSale()
        {
            //отчистка dateGridView данных

            dataGridView.Rows.Clear();

            //отчистка dateGridView вместе с шапкой

            dataGridView.SelectAll();
            dataGridView.ClearSelection();
            dataGridView.Columns.Clear();



            //создание колонок заранее
            dataGridView.Columns.Add("Column0", "КОД ЧЕКА");
            dataGridView.Columns.Add("Column1", "НАЗВАНИЕ ИЗДЕЛИЯ");
            dataGridView.Columns.Add("Column2", "ДАТА ЗАКАЗА");
            dataGridView.Columns.Add("Column3", "ФАМИЛИЯ");
            dataGridView.Columns.Add("Column4", "ИМЯ");
            dataGridView.Columns.Add("Column5", "ОТЧЕСТВО");

            //подключение к базе данных MicroSoft Sql server
            using (var context = new MyDbContext())
            {
                //запрос для заполнения частично dataGridView без заранее созданных колонок не получится
                var res = from x in context.Sales
                          from y in context.Titles
                          where x.TitleId == y.TitleId
                          select new
                          {
                              Numeric = x.Numeric,
                              TitleName = y.Name,
                              SaleDate = x.SaleDate,
                              Surname = x.SName,
                              Name = x.Name,
                              Father = x.FName

                          };

                //считывание в datagrid view
                foreach (var item in res.ToList())
                {
                    dataGridView.Rows.Add(item.Numeric, item.TitleName, item.SaleDate.ToShortDateString().ToString(), item.Surname, item.Name, item.Father);
                }

                dataGridView.AllowUserToAddRows = false; //убирает снизу строку в dataGridView

            }
        }


        private void BDataMaterial_Click(object sender, EventArgs e)
        {
            Material = true;
            UpdateDataGridViewMaterial();

            Product = false;
            Sale = false;
            Title = false;
            light();

        }

        private void BDataTitle_Click(object sender, EventArgs e)
        {
            Material = false;
            UpdateDataGridViewTitle();

            Product = false;
            Sale = false;
            Title = true;
            light();
        }

        private void BDataProduct_Click(object sender, EventArgs e)
        {
            Material = false;
            UpdateDataGridViewProduct();

            Product = true;
            Sale = false;
            Title = false;
            light();
        }

        private void BDataSale_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewSale();
            Material = false;
            Product = false;
            Sale = true;
            Title = false;
            light();
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            if (Material == true)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int index = dataGridView.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    Material material = db.Materials.Find(id);
                    db.Materials.Remove(material);
                    db.SaveChanges();

                    MessageBox.Show("МАТЕРИАЛ УДАЛЕН");
                    UpdateDataGridViewMaterial();
                }
            }
            else if (Product == true)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int index = dataGridView.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    Product product = db.Products.Find(id);
                    db.Products.Remove(product);
                    db.SaveChanges();

                    MessageBox.Show("ИЗДЕЛИЕ УДАЛЕНО");
                    UpdateDataGridViewProduct();

                }

            }
            else if (Sale == true)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int index = dataGridView.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    Sale sale = db.Sales.Find(id);
                    db.Sales.Remove(sale);
                    db.SaveChanges();

                    MessageBox.Show("ЗАКАЗ УДАЛЕН");
                    UpdateDataGridViewSale();

                }

            }
            else if (Title == true)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int index = dataGridView.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;
                    Title title = db.Titles.Find(id);
                    db.Titles.Remove(title);
                    db.SaveChanges();

                    MessageBox.Show("ТИП УДАЛЕН");
                    UpdateDataGridViewTitle();

                }

            }
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            try
            {

                using (var context = new MyDbContext())
                {

                    int indexRow = dataGridView.CurrentCell.RowIndex;

                    int id = Convert.ToInt32(dataGridView.Rows[indexRow].Cells[0].Value);

                    if (Material == true)
                    {
                        Material material = db.Materials.Find(id);

                        editMaterial editmaterial = new editMaterial();

                        editmaterial.TBPrice.Text = material.GramPrice.ToString();

                        DialogResult result = editmaterial.ShowDialog(this); // в свойствах DialogRisult указать ОК 

                        if (result == DialogResult.Cancel)
                            return;

                            material.GramPrice = Convert.ToInt32(editmaterial.TBPrice.Text);

                            db.SaveChanges();
                            UpdateDataGridViewMaterial(); // обновление GridV
                        MessageBox.Show("МАТЕРИАЛ ИЗМЕНЕН");
                    }

                    else if (Product == true)
                    {
                        Product product = db.Products.Find(id);

                        editProduct editProduct = new editProduct();

                        editProduct.TBPrice.Text = product.Price.ToString(); // чтобы поля были видны в свойствах нужно поменять private на internal
                        editProduct.TBWeight.Text = product.Weight.ToString();
                        editProduct.TitleIds = product.TitleId;
                        editProduct.MaterialIds = product.MaterialId;

                        DialogResult result = editProduct.ShowDialog(this); // в свойствах DialogRisult указать ОК 

                        if (result == DialogResult.Cancel)
                            return;

                        var query = context.Products.Where(x => x.MaterialId == editProduct.MaterialIds && x.TitleId == editProduct.TitleIds);
                        if (query.ToList().Count > 0)
                        {
                            MessageBox.Show("ТАКОЕ ИЗДЕЛИЕ УЖЕ СУЩЕСТВУЕТ");
                        }
                        else 
                        { 
                            product.Price = Convert.ToInt32(editProduct.TBPrice.Text);
                            product.Weight = Convert.ToInt32(editProduct.TBWeight.Text);
                            product.TitleId = editProduct.TitleIds;
                            product.MaterialId = editProduct.MaterialIds;

                            db.SaveChanges();
                            UpdateDataGridViewProduct(); // обновление GridV
                            MessageBox.Show("МАТЕРИАЛ ИЗМЕНЕН");
                        }
                    }
                    else if (Title == true)
                    {
                        Title title = db.Titles.Find(id);

                        editTitle edittitle = new editTitle();

                        edittitle.TBName.Text = title.Name; // чтобы поля были видны в свойствах нужно поменять private на internal
                        edittitle.TBType.Text = title.Type;


                        DialogResult result = edittitle.ShowDialog(this); // в свойствах DialogRisult указать ОК 

                        if (result == DialogResult.Cancel)
                            return;

                        var query = context.Titles.Where(x => x.Name == edittitle.TBName.Text && x.Type == edittitle.TBType.Text);

                        if (query.ToList().Count > 0)
                        {
                            MessageBox.Show("ТАКОЕ ИЗДЕЛИЕ УЖЕ СУЩЕСТВУЕТ");
                        }
                        else 
                        {
                            title.Name = edittitle.TBName.Text;
                            title.Type = edittitle.TBType.Text;

                            db.SaveChanges();
                            UpdateDataGridViewTitle(); // обновление GridV
                            MessageBox.Show("ИЗДЕЛИЕ ИЗМЕНЕНО");
                        }

                        
                    }
                    else if (Sale == true)
                    {

                        Sale sale = db.Sales.Find(id);

                        editSale editsale = new editSale();

                        editsale.TBSName.Text = sale.SName.ToString(); // что бы поля были видны в свойствах нужно было поменять private на internal
                        editsale.TBName.Text = sale.Name.ToString();
                        editsale.TBFName.Text = sale.FName.ToString();
                        editsale.TitleIds = sale.TitleId;

                        DialogResult result = editsale.ShowDialog(this); // в свойствах DialogRisult надо указать ОК 

                        if (result == DialogResult.Cancel)
                            return;

                        sale.SName = editsale.TBSName.Text;
                        sale.Name = editsale.TBName.Text;
                        sale.FName = editsale.TBFName.Text;
                        sale.TitleId = editsale.TitleIds;


                        db.SaveChanges();
                        UpdateDataGridViewSale(); // обновление GridV
                        MessageBox.Show("ЗАКАЗ ИЗМЕНЕН");
                    }

                }
            }
            catch (System.NullReferenceException error)
            {
                MessageBox.Show("ВЫБЕРИТЕ ТАБЛИЦУ", "ОШИБКА");
            }
        }

        private void Bquery_Click(object sender, EventArgs e)
        {
            UserMenu usermenu = new UserMenu();
            usermenu.Show();
        }

        private void BAdduser_Click(object sender, EventArgs e)
        {
            AddUser adduser = new AddUser();
            adduser.Show();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void BExport_Click(object sender, EventArgs e)
        {
            Export export = new Export();
            export.Show();
        }
    }
}
