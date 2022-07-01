using Paluto_Kay_Juan.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Paluto_Kay_Juan.Data
{
    internal class FoodItems
    {
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=PalutoKayJuanDB;Integrated Security=True";
         public List<MenuItemsClass> FetchAll()
        {
            List<MenuItemsClass> returnList = new List<MenuItemsClass>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from MenuItems";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuItemsClass mItems = new MenuItemsClass();
                        mItems.Id = reader.GetInt32(0);
                        mItems.Category = reader.GetString(1);
                        mItems.DishName = reader.GetString(2);
                        mItems.AmtPerOrder = reader.GetInt32(3);
                        mItems.Price = reader.GetDecimal(4);
                        //mItems.Picture = reader.GetString(5);

                        returnList.Add(mItems);
                    }
                }

            }

            return returnList;
        }

        public MenuItemsClass FetchOne(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from MenuItems where Id = @id";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.Add("@Id",System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                MenuItemsClass mItems = new MenuItemsClass();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        mItems.Id = reader.GetInt32(0);
                        mItems.Category = reader.GetString(1);
                        mItems.DishName = reader.GetString(2);
                        mItems.AmtPerOrder = reader.GetInt32(3);
                        mItems.Price = reader.GetDecimal(4);
                        //mItems.Picture = reader.GetString(5);

                        
                    }
                }
                return mItems;
            }
        }
    }
}