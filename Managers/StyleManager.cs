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
  public class StyleManager
  {
    private readonly ConnectionStrings _settings;
    private ApplicationDbContext _context;
    private readonly int _takeCount = 10;

    public StyleManager(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _settings = appSettings.Value;
      _context = context;
    }

    public StyleManager(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Style> Add(Style style)
    {
      var result = await _context.Styles.AddAsync(style);
      _context.SaveChanges();

      return style;
    }

    public async void Delete(string id)
    {
      Style style = await _context.Styles.SingleOrDefaultAsync(x => x.Id == id);
      _context.Styles.Remove(style);
      var result = await _context.SaveChangesAsync();

      return;
    }

    public async Task<List<Style>> Get()
    {
      return await _context.Styles.Take(_takeCount).ToListAsync();
    }

    public async Task<Style> Get(string id)
    {
      return await _context.Styles.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Style> Update(Style style)
    {
      _context.Styles.Update(style);
      await _context.SaveChangesAsync();
      return style;
    }
  }
}