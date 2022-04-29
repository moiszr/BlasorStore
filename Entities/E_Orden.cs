namespace BlazorStore.Entities
{
    public class E_Orden
    {

		private int id;
		private string code = "";
		private decimal cost_order;
		private DateTime order_date;
		private DateTime shipped_date;
		private string shipping_addres = "";
		private string shipping_city = "";
		private string shipping_province = "";
		private int latitude;
		private int longitude;
		private decimal shipping_fee;
		private decimal taxes;
		private string payment_type = "";
		private string note = "";
		private int user_id;
		private int orderstatus_id;

		public int Id { get => id; set => id = value; }
		public string Code { get => code; set => code = value; }
		public decimal Cost_order { get => cost_order; set => cost_order = value; }
		public DateTime Order_date { get => order_date; set => order_date = value; }
		public DateTime Shipped_date { get => shipped_date; set => shipped_date = value; }
		public string Shipping_addres { get => shipping_addres; set => shipping_addres = value; }
		public string Shipping_city { get => shipping_city; set => shipping_city = value; }
		public string Shipping_province { get => shipping_province; set => shipping_province = value; }
		public int Latitude { get => latitude; set => latitude = value; }
		public int Longitude { get => longitude; set => longitude = value; }
		public decimal Shipping_fee { get => shipping_fee; set => shipping_fee = value; }
		public decimal Taxes { get => taxes; set => taxes = value; }
		public string Payment_type { get => payment_type; set => payment_type = value; }
		public string Note { get => note; set => note = value; }
		public int User_id { get => user_id; set => user_id = value; }
		public int Orderstatus_id { get => orderstatus_id; set => orderstatus_id = value; }


		public static List<E_Orden> E_ordens = new List<E_Orden>();
	}
}
