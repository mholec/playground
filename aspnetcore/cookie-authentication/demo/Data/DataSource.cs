using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Data
{
	public class DataSource
	{
		public List<Document> Documents { get; set; } = new List<Document>();

		public DataSource()
		{
			Documents.Add(new Document(){DocumentId = 1, AuthorName = "Mirek", Title = "Mirkovo dokument"});
			Documents.Add(new Document(){DocumentId = 2, AuthorName = "Lenka", Title = "Lenčin dokument"});
			Documents.Add(new Document(){DocumentId = 3, AuthorName = "Josef", Title = "Josefův dokument"});
		}
	}
}
