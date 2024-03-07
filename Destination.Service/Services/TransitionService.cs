using Destination.DataAccess.Contexts;
using Destination.Domain.Entities;
using Destination.Service.DTOs.Transactions;
using Destination.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destination.Service.Services;

public class TransitionService : ITransitionServices
{
    private readonly AppDbContext appDbContext;
    public TransitionService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public TransactionViewModel Create(TransactionCreationModel creationModel)
    {
       var transaction= creationModel.MapTo<Transaction>();
        appDbContext.Transactions.Add(transaction);
        appDbContext.SaveChanges();
        return transaction.MapTo<TransactionViewModel>();
    }

    public TransactionViewModel GetTransaction(int transactionId)
    {
        var exist = appDbContext.Transactions.FirstOrDefault(x=>x.Id==transactionId);
        return exist.MapTo<TransactionViewModel>();
    }

    public List<TransactionViewModel> GetTransactions()
    {
        var transaction = appDbContext.Transactions.ToList();
        return transaction.Select(x => x.MapTo<TransactionViewModel>()).ToList();
    }
}
