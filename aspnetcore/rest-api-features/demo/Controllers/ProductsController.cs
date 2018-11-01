using System;
using System.Collections.Generic;
using System.Linq;
using demo.ApiModels;
using demo.Repositories;
using demo.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    //[EnableCors("Default")]
    //[Produces("application/xml")]
    [ApiController]
    [ResponseCache(Duration = 1200)]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
		private readonly Context appContext;

	    public ProductsController(Context appContext)
	    {
		    this.appContext = appContext;
	    }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
		    List<Product> products = appContext.Products.Include(x => x.Tags).ToList();

	        return Ok(products);
        }

        //[FormatFilter]
        [HttpGet("{id}.{format?}",  Name = "GetProduct")]
        public ActionResult<Product> Get(Guid id, /*[Required]*/string test)
        {
	        Product product = appContext.Products.Include(x => x.Tags).FirstOrDefault(x => x.ProductId == id);

	        if (product == null)
	        {
		        return NotFound();
	        }

            //return MyOk();
			return Ok(product);
		}

        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product model)
        {
	        if (model == null)
	        {
		        return BadRequest();
	        }

	        string err;
	        if (!ValidationService.ValidateTitle(model.Title, out err))
	        {
		        ModelState.AddModelError("Title", err);
	        }

	        if (!ModelState.IsValid)
	        {
		        return BadRequest(ModelState);
	        }

	        appContext.Products.Add(model);
	        appContext.SaveChanges();

	        return CreatedAtRoute("GetProduct", new { id = model.ProductId }, model);
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(Guid id, [FromBody]JsonPatchDocument<Product> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var product = appContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            patchDocument.ApplyTo(product);

            TryValidateModel(product);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            appContext.SaveChanges();

            return Ok();
        }

        #region Another methods

        [HttpPut("{id}")]
        public ActionResult<Product> Put(Guid id, [FromBody]Product model)
        {
            var product = appContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Title = model.Title;

            try
            {
                appContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var product = appContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            appContext.Products.Remove(product);
            appContext.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}/tags")]
        public ActionResult<List<Tag>> GetProductTags(Guid id)
        {
            var product = appContext.Products.Include(x => x.Tags).FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.Tags);
        }

        [HttpOptions("{id}/tags")]
        public ActionResult GetProductTagsOptions(Guid id)
        {
            Response.Headers.Add("Allow",  "GET,OPTIONS");

            return Ok();
        }

        #endregion
	}
}
