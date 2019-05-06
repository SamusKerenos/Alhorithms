namespace CallStack.BinaryTree
{
	public class Node
	{
		private int? _data;

		public Node Left { get; private set; }

		public Node Right { get; private set; }

		public int Data 
		{ 
			get { return _data.HasValue ? _data.Value : default(int); }
			set
			{
				if (_data.HasValue)
				{
					if (value < _data)
					{
						if (Left == null)
						{
							Left = new Node() { Data = value };
						}
						else
						{
							Left.Data = value;
						}
					}
					else
					{
						if (Right == null)
						{
							Right = new Node() { Data = value };
						}
						else
						{
							Right.Data = value;
						}
					}
				}
				else
				{
					_data = value;
				}
			}
		}
	}
}
