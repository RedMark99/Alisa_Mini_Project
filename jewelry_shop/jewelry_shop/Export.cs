using jewelry_shop.ClassXML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace jewelry_shop
{
    public partial class Export : Form
    {
        public Export()
        {
            InitializeComponent();
            addCBox();

            CBMName.Text = "ВСЕ";
            CBTName.Text = "ВСЕ";
            CBTType.Text = "ВСЕ";

        }

        public void addCBox()
        {
            using (var context = new MyDbContext())
            {
                var TitleName = from query in context.Titles
                                select new
                                {
                                    name = query.Name,
                                };

                var TitleNames = TitleName.Distinct();

                foreach (var el in TitleNames.ToList())
                {
                    CBTName.Items.Add(el.name);
                }

                var TitleType = from query in context.Titles
                                select new
                                {
                                    type = query.Type
                                };

                TitleType = TitleType.Distinct();

                foreach (var el in TitleType.ToList())
                {
                    CBTType.Items.Add(el.type);
                }

                CBTName.Items.Add("ВСЕ");
                CBTType.Items.Add("ВСЕ");

                var MaterialName = from query in context.Materials
                                   select new
                                   {
                                       name = query.Name
                                   };

                var MaterialsName = MaterialName.Distinct();

                foreach (var el in MaterialsName)
                {
                    CBMName.Items.Add(el.name);
                }

                CBMName.Items.Add("ВСЕ");

                CBTName.DropDownStyle = ComboBoxStyle.DropDownList;
                CBTType.DropDownStyle = ComboBoxStyle.DropDownList;
                CBMName.DropDownStyle = ComboBoxStyle.DropDownList;

            }
        }

        private void BNight_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var materials = context.Materials.ToList();

                string materialname = "0";
                string titlename = "0";
                string titletype = "0";
                string saledate = "0";

                var wastitle = new List<TitleTest>();
                var wasSale = new List<SaleTest>();
                var wasProduct = new List<ProductTest>();

                if (CBMName.SelectedItem.ToString() != "ВСЕ") 
                {
                    materials = context.Materials.Where(x => x.Name == CBMName.Text).ToList();
                }

                int key = 0;
                XDocument doc = new XDocument(new XElement("MATERIALS"));

                for(int i = 0; i < materials.Count(); i++) 
                {

                    wastitle.Clear();

                    doc.Element("MATERIALS").Add(new XElement("MATERIAL",
                        new XElement("name", materials[i].Name.Trim()),
                        new XElement("gramprice", materials[i].GramPrice.ToString().Trim())
                        ));

                    var products = context.Products.ToList();

                    foreach(var product in products) 
                    {
                        if(product.MaterialId == materials[i].MaterialID) 
                        {
                            var titles = context.Titles.ToList();

                            if (CBTName.SelectedItem.ToString() != "ВСЕ")
                            {
                                titles = context.Titles.Where(x => x.Name == CBTName.SelectedItem.ToString()).ToList();
                            }

                            if (CBTType.SelectedItem.ToString() != "ВСЕ")
                            {
                                titles = context.Titles.Where(x => x.Type == CBTType.SelectedItem.ToString()).ToList();
                            }

                            if (CBTName.SelectedItem.ToString() != "ВСЕ" && CBTType.SelectedItem.ToString() != "ВСЕ")
                            {
                                titles = context.Titles.Where(x => x.Type == CBTType.SelectedItem.ToString() && x.Name == CBTName.SelectedItem.ToString()).ToList();
                            }

                            foreach(var title in titles) 
                            {
                                bool check = false;
                                
                                foreach(var s in wastitle) 
                                {
                                    if(title.Name == s.TitleName && title.Type == s.TitleType) 
                                    {
                                        check = true;
                                    }
                                   
                                    var checkTitle = context.Titles.Where(x => x.Name == title.Name && x.Type == title.Type).ToList();
                                    
                                    if(checkTitle.ToList().Count() < 1) 
                                    {
                                        check = true;
                                    }
                                }

                                titlename = context.Titles.Where(x => x.Name == title.Name && x.Type == title.Type && x.TitleId == title.TitleId).Select(x => x.TitleId.ToString()).First();
                                string getmaterialname = materials[i].Name;
                                materialname = context.Materials.Where(x => x.Name == getmaterialname).Select(x => x.Name).First();

                                if (check == false) 
                                {

                                    wastitle.Add(new TitleTest(title.TitleId.ToString(), title.Name, title.Type));

                                    var TitleXML = new XElement("TITLE",
                                            new XElement("titleid", title.TitleId.ToString().Trim()),
                                            new XElement("name", title.Name.Trim()),
                                            new XElement("type", title.Type.Trim())
                                            );

                                    var ourMaterial = doc.Descendants("MATERIAL")
                                        .Where(x => x.Element("name")
                                        .Value.Equals(materials[i].Name.Trim())).FirstOrDefault();

                                    if (ourMaterial != null)
                                    {
                                        if (!ourMaterial.Elements("MATERIALS").Any())
                                            ourMaterial.Add(new XElement("MATERIALS"));

                                        bool duplicatePatient = false;
                                        foreach (var elem in ourMaterial.Element("MATERIALS").Elements("TITLE"))
                                        {
                                            duplicatePatient = XNode.DeepEquals(elem, TitleXML);
                                            if (duplicatePatient)
                                                break;
                                        }

                                        if (!duplicatePatient)
                                        {
                                            ourMaterial.Add(TitleXML);
                                        }
                                    }

                                    if (product.MaterialId == materials[i].MaterialID)
                                    {
                                        bool checkss = false;

                                        foreach (var s in wasProduct)
                                        {

                                            string tname = title.Name;

                                            string ttype = title.Type;

                                            var titlegetid = context.Titles.Where(x => x.Name == tname && x.Type == ttype).ToList();

                                            int idtitle = 0;

                                            foreach (var a in titlegetid.ToList())
                                            {
                                                idtitle = Convert.ToInt32(a.TitleId);
                                            }
                                                                                        
                                            int idmaterial = materials[i].MaterialID;

                                            var querys = context.Products.Where(x => x.TitleId == idtitle && x.MaterialId == idmaterial && x.Price == product.Price && x.Weight == product.Weight);

                                            if (querys.ToList().Count() < 1)
                                            {
                                                checkss = true;
                                            }

                                            if (s.titlename == title.Name && s.materialname == materials[i].Name && s.Weight == product.Weight.ToString() && s.Price == product.Price.ToString())
                                            {
                                                checkss = true;
                                            }
                                        }

                                        if (checkss == false)
                                            {

                                                wasProduct.Add(new ProductTest(materials[i].Name, title.Name, title.Type, product.Weight.ToString(), product.Price.ToString()));

                                                var productXml = new XElement("PRODUCT",
                                                    new XElement("materialname", materials[i].Name.Trim()),
                                                    new XElement("titlename", title.Name.Trim()),
                                                    new XElement("titletype", title.Type.Trim()),
                                                    new XElement("weight", product.Weight.ToString().Trim()),
                                                    new XElement("price", product.Price.ToString().Trim()) //убрать
                                                    );

                                                var ourProduct = doc.Descendants("MATERIAL")
                                               .Where(x => x.Element("name")
                                               .Value.Equals(materials[i].Name.Trim())).FirstOrDefault().Descendants("TITLE")
                                               .Where(x => x.Element("titleid")
                                               .Value.Equals(titlename)).FirstOrDefault();

                                                if (ourProduct != null)
                                                {
                                                    ourProduct.Add(productXml);
                                                }
                                            }

                                        }

                                    // sale
                                    var sales = context.Sales.ToList();



                                    foreach (var sale in sales)
                                    {
                                        bool checks = false;

                                        

                                        foreach (var s in wasSale)
                                        {
                                            //DateTime SaleDate = DateTime.Parse(s.SaleDate);

                                            //var titlegetid = context.Titles.Where(x => x.Name == s.TitleName && x.Type == s.TitleType).Select(x => x.TitleId).First();

                                            //int idtitle = titlegetid;

                                            var querys = context.Sales.Where(x => x.TitleId == title.TitleId && x.Name == sale.Name && x.SName == sale.SName && x.FName == sale.FName && x.SaleDate == sale.SaleDate);

                                            if (querys.ToList().Count() < 1)
                                            {
                                                checks = true;
                                            }

                                            if (s.Name == sale.Name && s.SName == sale.SName && s.FName == sale.FName && s.SaleDate == sale.SaleDate.ToString() && s.TitleName == title.Name && s.TitleType == title.Type)
                                            {
                                                checks = true;

                                            }
                                        }

                                        if (checks == false)
                                        {

                                            wasSale.Add(new SaleTest(title.Name, title.Type, sale.SName, sale.Name, sale.FName, sale.SaleDate.ToString()));

                                            var SaleXml = new XElement("SALE",
                                                new XElement("sname", sale.SName.ToString().Trim()),
                                                new XElement("fname", sale.FName.ToString().Trim()),
                                                new XElement("name", sale.Name.ToString().Trim()),
                                                new XElement("saledate", sale.SaleDate.ToString().Trim()),
                                                new XElement("TitleName", titles[i].Name.Trim()),
                                                new XElement("TitleType", titles[i].Type.Trim())
                                                );


                                            //var ourSale = doc.Descendants("MATERIAL")
                                            //               .Where(x => x.Element("name")
                                            //               .Value.Equals(titlename.Trim())).FirstOrDefault();

                                            var ourSale = doc.Descendants("MATERIAL")
                                               .Where(x => x.Element("name")
                                               .Value.Equals(materials[i].Name.Trim())).FirstOrDefault().Descendants("TITLE")
                                               .Where(x => x.Element("titleid")
                                               .Value.Equals(titlename)).FirstOrDefault();



                                            if (ourSale != null)
                                            {
                                                ourSale.Add(SaleXml);
                                            }
                                        }



                                    } // sale




                                }



                            }

                        }  
                    }
                    key++;
                    
                }
                string filePath = @"xml\export.xml";
                doc.Save(filePath);

                MessageBox.Show("Экспорт завершен !");
            }
        }

        private void BImport_Click(object sender, EventArgs e)
        {
            XmlSerialization<MATERIALS> xmlSerialization = new XmlSerialization<MATERIALS>();

            MATERIALS cl = new MATERIALS(); // путь к файлу

            string filePath = @"xml\import.xml";

            cl = (MATERIALS)xmlSerialization.ReadData(filePath, cl); //дерсериализация 

            for (int i = 0; i < cl.MATERIAL.Count; i++)
            {

                string materialname = cl.MATERIAL[i].Name;
                string materialgram = cl.MATERIAL[i].GramPrice;
                int matergram = Convert.ToInt32(materialgram);

                using (var context = new MyDbContext())
                {
                    var query = context.Materials.Where(x => x.Name == materialname && matergram == x.GramPrice);

                    var materials = new Material()
                    {
                        Name = materialname,
                        GramPrice = Convert.ToInt32(materialgram)
                    };

                    if (query.ToList().Count < 1)
                    {
                        context.Materials.Add(materials);
                        context.SaveChanges();
                    }
                }

                for (int j = 0; j < cl.MATERIAL[i].TITLE.Count; j++) 
                {
                    string titlename = cl.MATERIAL[i].TITLE[j].Name;
                    string titletype = cl.MATERIAL[i].TITLE[j].Type;

                    using (var context = new MyDbContext())
                    {
                        var query = context.Titles.Where(x => x.Name == titlename && x.Type == titletype);

                        var titles = new Title()
                        {
                            Name = titlename,
                            Type = titletype
                            
                        };

                        if (query.ToList().Count < 1)
                        {
                            context.Titles.Add(titles);
                            context.SaveChanges();
                        }
                    }

                    for (int y = 0; y < cl.MATERIAL[i].TITLE[j].PRODUCT.Count; y++) 
                    {
                        string productmname = cl.MATERIAL[i].TITLE[j].PRODUCT[y].materialname;
                        string producttname = cl.MATERIAL[i].TITLE[j].PRODUCT[y].titlename;
                        string producttype = cl.MATERIAL[i].TITLE[j].PRODUCT[y].titletype;
                        string productweight = cl.MATERIAL[i].TITLE[j].PRODUCT[y].Weight;
                        string productprice = cl.MATERIAL[i].TITLE[j].PRODUCT[y].Price;

                        int weightint = Convert.ToInt32(productweight);
                        int priceint = Convert.ToInt32(productprice);



                        using (var context = new MyDbContext())
                        {

                            var getTitleid = context.Titles.Where(x => x.Name == producttname && x.Type == producttype).Select(x => x.TitleId).First();
                            var getMaterialid = context.Materials.Where(x => x.Name == productmname).Select(x => x.MaterialID).First();

                            var query = context.Products.Where(x => x.MaterialId == getMaterialid && x.TitleId == getTitleid && x.Weight == weightint && x.Price == priceint);

                            var product = new Product()
                            {
                                MaterialId = getMaterialid,
                                TitleId = getTitleid,
                                Weight = Convert.ToInt32(productweight),
                                Price = Convert.ToInt32(productprice)

                            };

                            if (query.ToList().Count < 1)
                            {
                                context.Products.Add(product);
                                context.SaveChanges();
                            }
                        }
                    }

                    for (int y = 0; y < cl.MATERIAL[i].TITLE[j].SALE.Count; y++)
                    {
                        string salename = cl.MATERIAL[i].TITLE[j].SALE[y].Name;
                        string salesurname = cl.MATERIAL[i].TITLE[j].SALE[y].SName;
                        string salefname = cl.MATERIAL[i].TITLE[j].SALE[y].FName;
                        string saletitlename = cl.MATERIAL[i].TITLE[j].SALE[y].TitleName;
                        string saletitletype = cl.MATERIAL[i].TITLE[j].SALE[y].TitleType;
                        string saledate = cl.MATERIAL[i].TITLE[j].SALE[y].SaleDate;

                        DateTime saledates = DateTime.Parse(saledate);

                        using (var context = new MyDbContext())
                        {

                            var getTitleid = context.Titles.Where(x => x.Name == saletitlename && x.Type == saletitletype).Select(x => x.TitleId).First();

                            var query = context.Sales.Where(x => x.TitleId == getTitleid && x.Name == salename && x.SName == salesurname && x.FName == salefname && x.SaleDate == saledates);

                            var sale = new Sale()
                            {
                                Name = salename,
                                SName = salesurname,
                                FName = salefname,
                                TitleId = getTitleid,
                                SaleDate = saledates

                            };

                            if (query.ToList().Count < 1)
                            {
                                context.Sales.Add(sale);
                                context.SaveChanges();
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Импорт завершён");
        }

        private void Export_Load(object sender, EventArgs e)
        {

        }
    }
}
