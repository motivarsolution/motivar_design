using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Model;

namespace TEST.Controller
{
    public static class DatabaseStore
    {
        public static List<ProductModel> _ProductModel = new List<ProductModel>();
        public static List<ProductDetailModel> _ProductDetailModel = new List<ProductDetailModel>();
        public static List<ProductBandModel> _ProductBandModel = new List<ProductBandModel>();

        public static void DatabaseStoreSelect()
        {

            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=e:\my documents\visual studio 2017\Projects\TEST\TEST\myDB.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _ProductModel.Add(new ProductModel() { ProductID = dr[0].ToString() ,
                                                                   ProductBC = dr[1].ToString() ,
                                                                   ShelfID = dr[2].ToString()});
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductDetail", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _ProductDetailModel.Add(new ProductDetailModel()
                            {
                                ProductID = dr[0].ToString(),
                                ProductName = dr[1].ToString(),
                                ProductType = dr[2].ToString(),
                                ProductBandID = dr[3].ToString()
                            });
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductBand", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _ProductBandModel.Add(new ProductBandModel()
                            {
                                ProductBandID = dr[0].ToString(),
                                ProductBandName = dr[1].ToString()
                            });
                        }
                    }
                }
            }


        }

    }
}
