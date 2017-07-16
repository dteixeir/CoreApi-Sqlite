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
  public class CategoryManager
  {
    private readonly ConnectionStrings _settings;
    private ApplicationDbContext _context;
    private readonly int _takeCount = 10;

    public CategoryManager(IOptions<ConnectionStrings> appSettings, ApplicationDbContext context)
    {
      _settings = appSettings.Value;
      _context = context;
    }

    public CategoryManager(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Category> Add(Category category)
    {
      var result = await _context.Categories.AddAsync(category);
      _context.SaveChanges();

      return category;
    }

    public async void Delete(string id)
    {
      Category category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
      _context.Categories.Remove(category);
      var result = await _context.SaveChangesAsync();

      return;
    }

    public async Task<List<Category>> Get()
    {
      return await _context.Categories.Take(_takeCount).ToListAsync();
    }

    public async Task<Category> Get(string id)
    {
      return await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Category> Update(Category category)
    {
      _context.Categories.Update(category);
      await _context.SaveChangesAsync();
      return category;
    }
  }
}