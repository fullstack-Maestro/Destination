using Destination.Service.DTOs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destination.Service.Interfaces;

public interface ITransitionServices
{
    TransactionViewModel Create(TransactionCreationModel creationModel);
    TransactionViewModel GetTransaction(int transactionId);
    List<TransactionViewModel> GetTransactions();
}
