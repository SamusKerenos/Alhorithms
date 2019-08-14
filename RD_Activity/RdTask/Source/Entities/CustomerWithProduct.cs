namespace Source.Entities
{
	public class CustomerWithProduct
	{
		public string Name { get; set; }
		public string Product { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null || obj as CustomerWithProduct == null)
			{
				return false;
			}

			return Equals((CustomerWithProduct)obj);
		}

		public bool Equals(CustomerWithProduct obj)
		{
			return Name.Equals(obj.Name)
				&& Product.Equals(obj.Product);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode() + Product.GetHashCode();
		}
	}
}
