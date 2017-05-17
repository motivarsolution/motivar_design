using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEST.Model;
using TEST.Controller;

namespace TEST.View
{
    public partial class Form2 : Form
    {

        public List<string> SearchResult = new List<string>();

        public Form2()
        {
            InitializeComponent();
            DatabaseStore.DatabaseStoreSelect();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SearchResult.Clear();

            var query = from _product in DatabaseStore._ProductModel
                        join _productDetail in DatabaseStore._ProductDetailModel
                        on _product.ProductID equals _productDetail.ProductID
                        join _productBand in DatabaseStore._ProductBandModel
                        on _productDetail.ProductBandID equals _productBand.ProductBandID
                        where _product.ProductID == textBox1.Text
                        select new
                        {
                            ProductID = _product.ProductID,
                            ProductName = _productDetail.ProductName,
                            ProductType = _productDetail.ProductType,
                            ProductBandName = _productBand.ProductBandName

                        };

            if(query.Count() <= 0)
            {
                textBox2.Text = "Item Not Found.";
            }

            foreach(var item in query)
            {
                SearchResult.Add(item.ProductID + " " + item.ProductName + " " + item.ProductType + " " + item.ProductBandName);
                textBox2.Text = SearchResult.FirstOrDefault().ToString();
            }
        }


    }


    

}
