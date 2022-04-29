using System.Data;
using BlazorStore.Entities;
using System.Data.SqlClient;

namespace BlazorStore.Data
{
    public class D_Orden
    {
        public SqlConnection conn = new SqlConnection("Server=StoreBlazorBro.mssql.somee.com;Database=StoreBlazorBro; TrustServerCertificate=True; user id=Danielpba_SQLLogin_1;pwd=fs9omqkqgh;");

        public List<E_Orden> MostrosOrden()
        {
            List<E_Orden> Listar = new List<E_Orden>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_MOSTRARORDEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            reader = cmd.ExecuteReader();


            conn.Close();
            reader.Close();
            while (reader.Read())
            {
                Listar.Add(new E_Orden
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Cost_order = Convert.ToInt32(reader["COST_ORDER"])!,
                    Order_date = Convert.ToDateTime(reader["ORDER_DATE"])!,
                    Shipped_date = Convert.ToDateTime(reader["SHIPPED_DATE"])!,
                    Shipping_addres = Convert.ToString(reader["SHIPPING_ADDRESS"])!,
                    Shipping_city = Convert.ToString(reader["SHIPPING_CITY"])!,
                    Shipping_province = Convert.ToString(reader["SHIPPING_PROVINCE"])!,
                    Latitude = Convert.ToInt32(reader["LATITUDE"])!,
                    Longitude = Convert.ToInt32(reader["LONGITUDE"])!,
                    Shipping_fee = Convert.ToInt32(reader["SHIPPING_FEE"])!,
                    Taxes = Convert.ToInt32(reader["TAXES"])!,
                    Payment_type = Convert.ToString(reader["PAYMENT_TYPE"])!,
                    Note =  Convert.ToString(reader["NOTE"])!,
                    User_id = Convert.ToInt32(reader["USER_ID"])!,
                    Orderstatus_id  = Convert.ToInt32(reader["ORDERSTATUS_ID"])!,

                });
            }

            return Listar;
        }
        public List<E_Orden> MostrosOrdenÏD(int id)
        {
            List<E_Orden> Listar = new List<E_Orden>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_MOSTRARORDENID", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@ID", id);
            reader = cmd.ExecuteReader();


            conn.Close();
            reader.Close();
            while (reader.Read())
            {
                Listar.Add(new E_Orden
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Cost_order = Convert.ToInt32(reader["COST_ORDER"])!,
                    Order_date = Convert.ToDateTime(reader["ORDER_DATE"])!,
                    Shipped_date = Convert.ToDateTime(reader["SHIPPED_DATE"])!,
                    Shipping_addres = Convert.ToString(reader["SHIPPING_ADDRESS"])!,
                    Shipping_city = Convert.ToString(reader["SHIPPING_CITY"])!,
                    Shipping_province = Convert.ToString(reader["SHIPPING_PROVINCE"])!,
                    Latitude = Convert.ToInt32(reader["LATITUDE"])!,
                    Longitude = Convert.ToInt32(reader["LONGITUDE"])!,
                    Shipping_fee = Convert.ToInt32(reader["SHIPPING_FEE"])!,
                    Taxes = Convert.ToInt32(reader["TAXES"])!,
                    Payment_type = Convert.ToString(reader["PAYMENT_TYPE"])!,
                    Note = Convert.ToString(reader["NOTE"])!,
                    User_id = Convert.ToInt32(reader["USER_ID"])!,
                    Orderstatus_id = Convert.ToInt32(reader["ORDERSTATUS_ID"])!,

                });
            }

            return Listar;
        }

        public void InsertarOrden(E_Orden orden)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERTPRODUCT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@COST_ORDER", orden.Cost_order);
                cmd.Parameters.AddWithValue("@ORDER_DATE", orden.Order_date);
                cmd.Parameters.AddWithValue("@SHIPPED_DATE", orden.Shipped_date);
                cmd.Parameters.AddWithValue("@SHIPPING_ADDRESS", orden.Shipping_addres);
                cmd.Parameters.AddWithValue("@SHIPPING_CITY", orden.Shipping_city);
                cmd.Parameters.AddWithValue("@SHIPPING_PROVINCE", orden.Shipping_province);
                cmd.Parameters.AddWithValue("@LATITUDE", orden.Latitude);
                cmd.Parameters.AddWithValue("@LONGITUDE", orden.Longitude);
                cmd.Parameters.AddWithValue("@SHIPPING_FEE", orden.Shipping_fee);
                cmd.Parameters.AddWithValue("@TAXES", orden.Taxes);
                cmd.Parameters.AddWithValue("@PAYMENT_TYPE", orden.Payment_type);
                cmd.Parameters.AddWithValue("@NOTE", orden.Note);
                cmd.Parameters.AddWithValue("@USER_ID", orden.User_id);
                cmd.Parameters.AddWithValue("@ORDERSTATUS_ID", orden.Orderstatus_id);

                cmd.ExecuteNonQuery();
                conn.Close();
                E_Orden.E_ordens.Add(orden);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public void EditarOrden(E_Orden orden)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITORDEN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@COST_ORDER", orden.Id);
            cmd.Parameters.AddWithValue("@COST_ORDER", orden.Cost_order);
            cmd.Parameters.AddWithValue("@ORDER_DATE", orden.Order_date);
            cmd.Parameters.AddWithValue("@SHIPPED_DATE", orden.Shipped_date);
            cmd.Parameters.AddWithValue("@SHIPPING_ADDRESS", orden.Shipping_addres);
            cmd.Parameters.AddWithValue("@SHIPPING_CITY", orden.Shipping_city);
            cmd.Parameters.AddWithValue("@SHIPPING_PROVINCE", orden.Shipping_province);
            cmd.Parameters.AddWithValue("@LATITUDE", orden.Latitude);
            cmd.Parameters.AddWithValue("@LONGITUDE", orden.Longitude);
            cmd.Parameters.AddWithValue("@SHIPPING_FEE", orden.Shipping_fee);
            cmd.Parameters.AddWithValue("@TAXES", orden.Taxes);
            cmd.Parameters.AddWithValue("@PAYMENT_TYPE", orden.Payment_type);
            cmd.Parameters.AddWithValue("@NOTE", orden.Note);
            cmd.Parameters.AddWithValue("@USER_ID", orden.User_id);
            cmd.Parameters.AddWithValue("@ORDERSTATUS_ID", orden.Orderstatus_id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
