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
  public class BreweryController : Controller
  {
    private ApplicationDbContext _context;
    public BreweryManager _breweryManager;

    public BreweryController(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _context = context;
      _breweryManager = new BreweryManager(appSettings, _context);
    }

    [HttpGet]           // GET: Blogs
    public async Task<IActionResult> Get()
    {
      return Ok(await _breweryManager.Get());
    }

    [HttpGet("{id}")]   // GET: Blogs/Details/5
    public async Task<ActionResult> Get(string id)
    {
      return Ok(await _breweryManager.Get(id));
    }

    [HttpPost]          // Post: Blogs
    public async Task<ActionResult> Post([FromBody] Brewery brewery)
    {
      return Created("Object Created", await _breweryManager.Add(brewery));
    }

    [HttpPut("{id}")]   // GET: Blogs/5
    public async Task<ActionResult> Put(string id, [FromBody] Brewery brewery)
    {
      return Ok(await _breweryManager.Update(brewery));
    }

    [HttpDelete("{id}")] // DELETE: Blogs/delete/5
    public ActionResult Delete(string id)
    {
      _breweryManager.Delete(id);
      return NoContent();
    }
  }
}