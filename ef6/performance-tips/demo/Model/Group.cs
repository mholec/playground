using System.Collections.Generic;

namespace Model
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual List<UserGroup> UserGroups { get; set; }
	}
}