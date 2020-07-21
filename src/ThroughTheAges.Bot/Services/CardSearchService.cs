using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThroughTheAges.Bot.Context;
using ThroughTheAges.Bot.Models;

namespace ThroughTheAges.Bot.Services
{
  public class CardSearchService
  {
    private readonly CardContext _cardContext;

    public CardSearchService(CardContext cardContext)
    {
      _cardContext = cardContext;
    }

    public async Task<Card> GetCardDataAsync(string name)
    {
      return await _cardContext.Cards.AsNoTracking().Where(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefaultAsync();
    }

    public async Task<List<Card>> GetAllCardsAsync()
    {
      return await _cardContext.Cards.AsNoTracking().ToListAsync();
    }
  }
}
