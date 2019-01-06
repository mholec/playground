using System;

namespace Model
{
	public class UserGroup
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int GroupId { get; set; }
		public DateTime Added { get; set; }

		public virtual User User { get; set; }
		public virtual Group Group { get; set; }
	}
}