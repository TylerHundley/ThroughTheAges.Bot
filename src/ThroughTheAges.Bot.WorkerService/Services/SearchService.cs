using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThroughTheAges.Bot.WorkerService.Models;

namespace ThroughTheAges.Bot.WorkerService.Services
{
  public class SearchService
  {
    private readonly CardContext _context;

    public SearchService(CardContext context)
    {
      _context = context;
    }

    public async Task<string> SearchCard(string cardname)
    {
      Card temp = await _context.Cards.AsNoTracking().FirstOrDefaultAsync(x => string.Equals(x.Name, cardname, StringComparison.InvariantCultureIgnoreCase));
      return temp?.ToString() ?? $"{cardname} not found.";
    }
  }
}
