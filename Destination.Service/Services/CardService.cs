using Destination.DataAccess.Contexts;
using Destination.Domain.Entities;
using Destination.Service.DTOs.Cards;
using Destination.Service.DTOs.Users;
using Destination.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destination.Service.Services;

public class CardService : ICardService
{
    private readonly AppDbContext appDbContext;
    public CardService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public CardViewModel Create(CardCreationModel cardCreationModel)
    {
        var card = cardCreationModel.MapTo<Card>();
        appDbContext.Cards.Add(card);
        appDbContext.SaveChanges();
        return card.MapTo<CardViewModel>();
    }

    public bool Delete(int id)
    {
        var card = appDbContext.Cards.FirstOrDefault(x => x.Id == id);
        if (card is null)
        {
            throw new Exception("Card is not found");
        }
        var res = appDbContext.Cards.Remove(card);
        appDbContext.SaveChanges();
        return true;
    }

    public CardViewModel Get(int id)
    {
        var card = appDbContext.Cards.FirstOrDefault(x => x.Id == id);
        if (card is null)
        {
            throw new Exception("Card is not found");
        }
        return card.MapTo<CardViewModel>();
    }

    public List<CardViewModel> GetAll()
    {
       var cards= appDbContext.Cards.ToList();
        return cards.Select(x => x.MapTo<CardViewModel>()).ToList();
    }

    public CardViewModel Update(int id, CardViewModel cardViewModel)
    {
        var card = appDbContext.Cards.FirstOrDefault(x => x.Id == id);
        if (card is null)
        {
            throw new Exception("Card is not found");
        }
        cardViewModel.Id = id;
        card.Balance = cardViewModel.Balance;
        card.UserId=cardViewModel.UserId;
        card.UpdatedAt = DateTime.UtcNow;
        appDbContext.SaveChanges();
        return card.MapTo<CardViewModel>();
    }
}
