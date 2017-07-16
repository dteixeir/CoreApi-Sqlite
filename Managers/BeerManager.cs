using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetApi.Domain;
using dotNetApi;
using System;

namespace dotNetApi.Managers
{
  public class BeerManager
  {
    private readonly ConnectionStrings _settings;
    private ApplicationDbContext _context;
    private readonly int _takeCount = 10;


    public BeerManager(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _settings = appSettings.Value;
      _context = context;
    }

    public BeerManager(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Beer> Add(Beer beer)
    {
      var result = await _context.Beers.AddAsync(beer);
      _context.SaveChanges();

      return beer;
    }

    public async void Delete(string id)
    {
      Beer beer = await _context.Beers.SingleOrDefaultAsync(x => x.Id == id);
      _context.Beers.Remove(beer);
      var result = await _context.SaveChangesAsync();

      return;
    }

    public async Task<List<Beer>> Get()
    {
      return await _context.Beers.Take(_takeCount).ToListAsync();
    }

    public async Task<Beer> Get(string id)
    {
      return await _context.Beers.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Beer> Update(Beer beer)
    {
      _context.Beers.Update(beer);
      await _context.SaveChangesAsync();
      return beer;
    }
  }
}