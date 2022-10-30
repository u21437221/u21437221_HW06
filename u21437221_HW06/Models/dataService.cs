using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace u21437221_HW06.Models
{
    public class dataService
    {
        public List<Order> getOrderByDate(DateTime date)
        {
            List<Order> orders = new List<Order>();
            try
            {
                SqlConnection myConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BikeStores;Integrated Security=True");
                myConnection.Open();
                SqlCommand newCmd = new SqlCommand("SELECT production.products.product_name, sales.order_items.list_price, sales.order_items.quantity, (sales.order_items.list_price * sales.order_items.quantity) AS [Total] FROM production.products FULL OUTER JOIN sales.order_items ON production.products.product_id = sales.order_items.product_id WHERE sales.order_items.order_id = (SELECT sales.orders.order_id FROM sales.orders WHERE sales.orders.order_date = '"+ date + "')",myConnection);
                using (SqlDataReader myReader = newCmd.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        Order order = new Order();
                        order.ProductName = myReader["production.products.product_name"].ToString();
                        order.ListPrice = Convert.ToInt32(myReader["sales.order_items.list_price"]);
                        order.Quantity = Convert.ToInt32(myReader["sales.order_items.quantity"]);
                        order.Total = Convert.ToInt32(myReader["Total"]);
                        orders.Add(order);
                    }
                }
                myConnection.Close();
            }
            catch
            {
            }
            return orders;
        }

        public List<Order> getOrder()
        {
            List<Order> orders = new List<Order>();
            try
            {
                SqlConnection myConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BikeStores;Integrated Security=True");
                myConnection.Open();
                SqlCommand newCmd = new SqlCommand("SELECT production.products.product_name, sales.order_items.list_price, sales.order_items.quantity, (sales.order_items.list_price * sales.order_items.quantity) AS [Total] FROM production.products FULL OUTER JOIN sales.order_items ON production.products.product_id = sales.order_items.product_id WHERE sales.order_items.order_id = (SELECT sales.orders.order_id FROM sales.orders WHERE sales.orders.order_date = '2016-01-02')", myConnection);
                using (SqlDataReader myReader = newCmd.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        Order order = new Order();
                        order.ProductName = myReader["production.products.product_name"].ToString();
                        order.ListPrice = Convert.ToInt32(myReader["sales.order_items.list_price"]);
                        order.Quantity = Convert.ToInt32(myReader["sales.order_items.quantity"]);
                        order.Total = Convert.ToInt32(myReader["Total"]);
                        orders.Add(order);
                    }
                }
                myConnection.Close();
            }
            catch
            {
            }
            return orders;
        }
    }
}