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

    public async Task<string> GetCardDataAsync(string name)
    {
      Card cardData = await _cardContext.Cards.AsNoTracking().Where(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefaultAsync();
      return cardData?.ToString() ?? $"{name} not found.";
    }
  }
}
