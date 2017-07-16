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
  public class BreweryManager
  {
    private readonly ConnectionStrings _settings;
    private ApplicationDbContext _context;
    private readonly int _takeCount = 10;

    public BreweryManager(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _settings = appSettings.Value;
      _context = context;
    }

    public BreweryManager(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Brewery> Add(Brewery brewery)
    {
      var result = await _context.Breweries.AddAsync(brewery);
      _context.SaveChanges();

      return brewery;
    }

    public async void Delete(string id)
    {
      Brewery brewery = await _context.Breweries.SingleOrDefaultAsync(x => x.Id == id);
      _context.Breweries.Remove(brewery);
      var result = await _context.SaveChangesAsync();

      return;
    }

    public async Task<List<Brewery>> Get()
    {
      return await _context.Breweries.Take(_takeCount).ToListAsync();
    }

    public async Task<Brewery> Get(string id)
    {
      return await _context.Breweries.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Brewery> Update(Brewery brewery)
    {
      _context.Breweries.Update(brewery);
      await _context.SaveChangesAsync();
      return brewery;
    }
  }
}