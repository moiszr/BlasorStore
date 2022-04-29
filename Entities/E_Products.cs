namespace BlazorStore.Entities
{
    public class E_Products
    {
		private int id;
		private string code = "";
		private string product_name = "" ;
		private decimal sale_price;
		private int stock;
		private decimal offer_sale;
		private string product_image = "" ;
		private DateTime product_data;
		private int category_id;
		private string category_name = "";
		private int cantidadcarrito;



		public int Id { get => id;  set => id = value;  }
		public string Code { get => code; set => code = value; }

		public string Product_name { get => product_name; set => product_name = value; }

		public decimal Sale_price { get => sale_price; set => sale_price = value; }

		public int Stock { get => stock; set => stock = value; }

		public decimal Offer_sale { get => offer_sale; set => offer_sale = value; }

		public string Product_image { get => product_image; set => product_image = value; }

		public DateTime Product_data { get => product_data; set => product_data = value; }

		public int Category_id { get => category_id; set => category_id = value; }

        public string Category_name { get => category_name; set => category_name = value; }
        public int Cantidadcarrito { get => cantidadcarrito; set => cantidadcarrito = value; }

        public static List<E_Products> E_product = new List<E_Products>();



	}
}
