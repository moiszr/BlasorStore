using System.Data;
using BlazorStore.Entities;
using System.Data.SqlClient;

namespace BlazorStore.Data
{
    public class D_Products
    {
        public SqlConnection conn = new SqlConnection("Server=StoreBlazorBro.mssql.somee.com;Database=StoreBlazorBro; TrustServerCertificate=True; user id=Danielpba_SQLLogin_1;pwd=fs9omqkqgh;");


        public List<E_Products> MostrosProductos()
        {
            List<E_Products> Listar = new List<E_Products>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_MOSTRARPRODUCTOS", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Listar.Add(new E_Products
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Product_name = Convert.ToString(reader["PRODUCT_NAME"])!,
                    Sale_price = Convert.ToInt32(reader["SALE_PRICE"])!,
                    Stock = Convert.ToInt32(reader["STOCK"])!,
                    Offer_sale = Convert.ToInt32(reader["OFFER_SALE"])!,
                    Product_image = Convert.ToString(reader["PRODUCT_IMAGE"])!,
                    Product_data = Convert.ToDateTime(reader["PRODUCT_DATE"])!,
                    Category_id = Convert.ToInt32(reader["CATEGORY_ID"])!,

                });
            }

            conn.Close();
            reader.Close();


            return Listar;
        }

        public void InsertarProductos(E_Products products)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERTPRODUCT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@PRODUCT_NAME", products.Product_name);
                cmd.Parameters.AddWithValue("@SALE_PRICE", products.Sale_price);
                cmd.Parameters.AddWithValue("@STOCK", products.Stock);
                cmd.Parameters.AddWithValue("@OFFER_SALE", products.Offer_sale);
                cmd.Parameters.AddWithValue("@PRODUCT_IMAGE", products.Product_image);
                cmd.Parameters.AddWithValue("@PRODUCT_DATE", products.Product_data);
                cmd.Parameters.AddWithValue("@CATEGORY_ID", products.Category_id);


                cmd.ExecuteNonQuery();
                conn.Close();
                E_Products.E_product.Add(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public List<E_Products> MostrosProductosCategoria(int categoria_id)
        {
            List<E_Products> Listar = new List<E_Products>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_MOSTRARPRODUCTOCATERIAS", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@CATEGORY_ID", categoria_id);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Listar.Add(new E_Products
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Product_name = Convert.ToString(reader["PRODUCT_NAME"])!,
                    Sale_price = Convert.ToInt32(reader["SALE_PRICE"])!,
                    Stock = Convert.ToInt32(reader["STOCK"])!,
                    Offer_sale = Convert.ToInt32(reader["OFFER_SALE"])!,
                    Product_image = Convert.ToString(reader["PRODUCT_IMAGE"])!,
                    Product_data = Convert.ToDateTime(reader["PRODUCT_DATE"])!,
                    Category_id = Convert.ToInt32(reader["CATEGORY_ID"])!,

                });
            }

            conn.Close();
            reader.Close();


            return Listar;
        }

        public List<E_Products> ProductSearh(int id)
        {
            List<E_Products> Listar = new List<E_Products>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_BUSCARPRODUCTO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@ID", id);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Listar.Add(new E_Products
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Product_name = Convert.ToString(reader["PRODUCT_NAME"])!,
                    Sale_price = Convert.ToDecimal(reader["SALE_PRICE"])!,
                    Stock = Convert.ToInt32(reader["STOCK"])!,
                    Offer_sale = Convert.ToDecimal(reader["OFFER_SALE"])!,
                    Product_image = Convert.ToString(reader["PRODUCT_IMAGE"])!,
                    Product_data = Convert.ToDateTime(reader["PRODUCT_DATE"])!,
                    Category_id = Convert.ToInt32(reader["CATEGORY_ID"])!,
                    Category_name = Convert.ToString(reader["CATEGORY_NAME"])!
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarCarrito(int IdProduct, int IdUser)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERTCARD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@IDPRODUCTO", IdProduct);
                cmd.Parameters.AddWithValue("@USER_ID", IdUser);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<E_Products> MostrarCarrito(int iduser)
        {
            List<E_Products> Listar = new List<E_Products>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_MOSTRARCARRITO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@IDUSER", iduser);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Listar.Add(new E_Products
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Product_name = Convert.ToString(reader["PRODUCT_NAME"])!,
                    Sale_price = Convert.ToInt32(reader["SALE_PRICE"])!,
                    Stock = Convert.ToInt32(reader["STOCK"])!,
                    Offer_sale = Convert.ToInt32(reader["OFFER_SALE"])!,
                    Product_image = Convert.ToString(reader["PRODUCT_IMAGE"])!,
                });
            }

            conn.Close();
            reader.Close();


            return Listar;
        }

        public void EditarProductos(E_Products products)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITPRODUCT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@ID", products.Id);
            cmd.Parameters.AddWithValue("@PRODUCT_NAME", products.Product_name);
            cmd.Parameters.AddWithValue("@SALE_PRICE", products.Sale_price);
            cmd.Parameters.AddWithValue("@STOCK", products.Stock);
            cmd.Parameters.AddWithValue("@OFFER_SALE", products.Offer_sale);
            cmd.Parameters.AddWithValue("@PRODUCT_IMAGE", products.Product_image);
            cmd.Parameters.AddWithValue("@PRODUCT_DATE", products.Product_data);
            cmd.Parameters.AddWithValue("@CATEGORY_ID", products.Category_id);


            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public List<E_Products> MOSTRARPRODUCTID(int idpro)
        {
            List<E_Products> Listar = new List<E_Products>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_MOSTRARPRODUCTID", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@ID", idpro);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Listar.Add(new E_Products
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Product_name = Convert.ToString(reader["PRODUCT_NAME"])!,
                    Sale_price = Convert.ToInt32(reader["SALE_PRICE"])!,
                    Stock = Convert.ToInt32(reader["STOCK"])!,
                    Offer_sale = Convert.ToInt32(reader["OFFER_SALE"])!,
                    Product_image = Convert.ToString(reader["PRODUCT_IMAGE"])!,
                    Product_data = Convert.ToDateTime(reader["PRODUCT_DATE"])!,
                    Category_id = Convert.ToInt32(reader["CATEGORY_ID"])!

                });
            }

            conn.Close();
            reader.Close();


            return Listar;
        }

        public void Deleteproduct(int idpro)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETEPRODUCT", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@ID", idpro);

            cmd.ExecuteReader();
            conn.Close();
        }

        public void DeleteproductCard(int idproductcard)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETEPRODUCTCARD", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.Parameters.AddWithValue("@ID", idproductcard);

            cmd.ExecuteReader();
            conn.Close();
        }
    }
}