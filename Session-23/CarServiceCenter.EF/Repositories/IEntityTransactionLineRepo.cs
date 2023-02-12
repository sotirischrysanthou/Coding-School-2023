using CarServiceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public interface IEntityTransactionLineRepo {
        IList<TransactionLine> GetAllWithTransactionID(int transactionId);
    }
}
