using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class User
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateTime DateOfBirth { get; set; }

		public virtual List<UserGroup> UserGroups { get; set; }
	}
}
