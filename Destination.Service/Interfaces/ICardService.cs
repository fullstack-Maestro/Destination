using Destination.Service.DTOs.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destination.Service.Interfaces;

public interface ICardService
{
    CardViewModel Create(CardCreationModel cardCreationModel);
    CardViewModel Update(int id, CardViewModel cardViewModel);
    bool Delete(int id);
    CardViewModel Get(int id);
    List<CardViewModel> GetAll();
}
