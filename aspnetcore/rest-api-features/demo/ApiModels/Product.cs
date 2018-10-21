using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using demo.Repositories;

namespace demo.ApiModels
{
    public class Product : IValidatableObject
    {
        private Context Context { get; set; }

        public Product()
        {
        }

        //private Product(Context context)
        //{
        //    this.Context = context; 
        //}

        public Guid ProductId { get; set; }

		[Required]
		public string Title { get; set; }
		public string Language { get; set; }
		public List<Tag> Tags { get; set; }
	    

	    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	    {
            if (Title.StartsWith("B")) 
		    {
			    yield return new ValidationResult("Title cannot starts with B", new[] {"Title"});
		    }
        }
    }
}
