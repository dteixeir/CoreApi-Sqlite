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
  public class StyleController : Controller
  {
    private ApplicationDbContext _context;
    public StyleManager _styleManager;

    public StyleController(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _context = context;
      _styleManager = new StyleManager(appSettings, _context);
    }

    [HttpGet]           // GET: Blogs
    public async Task<IActionResult> Get()
    {
      return Ok(await _styleManager.Get());
    }

    [HttpGet("{id}")]   // GET: Blogs/Details/5
    public async Task<ActionResult> Get(string id)
    {
      return Ok(await _styleManager.Get(id));
    }

    [HttpPost]          // Post: Blogs
    public async Task<ActionResult> Post([FromBody] Style style)
    {
      return Created("Object Created", await _styleManager.Add(style));
    }

    [HttpPut("{id}")]   // GET: Blogs/5
    public async Task<ActionResult> Put(string id, [FromBody] Style style)
    {
      return Ok(await _styleManager.Update(style));
    }

    [HttpDelete("{id}")] // DELETE: Blogs/delete/5
    public ActionResult Delete(string id)
    {
      _styleManager.Delete(id);
      return NoContent();
    }
  }
}