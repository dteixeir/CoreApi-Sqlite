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
  public class BeerController : Controller
  {
    private ApplicationDbContext _context;
    public BeerManager _beerManager;

    public BeerController(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _context = context;
      _beerManager = new BeerManager(appSettings, _context);
    }

    [HttpGet]           // GET: Blogs
    public async Task<IActionResult> Get()
    {
      List<Beer> response = await _beerManager.Get();
      return Ok(response);
    }

    [HttpGet("{id}")]   // GET: Blogs/Details/5
    public async Task<ActionResult> Get(string id)
    {
      var response = await _beerManager.Get(id);
      return Ok(response);
    }

    [HttpPost]          // Post: Blogs
    public async Task<ActionResult> Post([FromBody] Beer beer)
    {
      Beer result = await _beerManager.Add(beer);
      return Created("Object Created", result);
    }

    [HttpPut("{id}")]   // GET: Blogs/5
    public async Task<ActionResult> Put(string id, [FromBody] Beer beer)
    {
      beer.Id = id;
      Beer result = await _beerManager.Update(beer);
      return Ok(result);
    }

    [HttpDelete("{id}")] // DELETE: Blogs/delete/5
    public ActionResult Delete(string id)
    {
      _beerManager.Delete(id);
      return NoContent();
    }
  }
}