using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNetApi.Managers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using dotNetApi;
using dotNetApi.Domain;

namespace dotNetApi.Controllers
{
  [Route("api/[controller]/")]
  public class CategoryController : Controller
  {
    private ApplicationDbContext _context;
    public CategoryManager _categoryManager;

    public CategoryController(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _context = context;
      _categoryManager = new CategoryManager(appSettings, _context);
    }

    [HttpGet]           // GET: Blogs
    public async Task<IActionResult> Get()
    {
      List<Category> response = await _categoryManager.Get();
      return Ok(response);
    }

    [HttpGet("{id}")]   // GET: Blogs/Details/5
    public async Task<ActionResult> Get(string id)
    {
      var response = await _categoryManager.Get(id);
      return Ok(response);
    }

    [HttpPost]          // Post: Blogs
    public async Task<ActionResult> Post([FromBody] Category category)
    {
      Category result = await _categoryManager.Add(category);
      return Created("Object Created", result);
    }

    [HttpPut("{id}")]   // GET: Blogs/5
    public async Task<ActionResult> Put(string id, [FromBody] Category category)
    {
      category.Id = id;
      Category result = await _categoryManager.Update(category);
      return Ok(result);
    }

    [HttpDelete("{id}")] // DELETE: Blogs/delete/5
    public ActionResult Delete(string id)
    {
      _categoryManager.Delete(id);
      return NoContent();
    }
  }
}