using Above_All_Beauty_Pageant.Core.Repositories;
using Above_All_Beauty_Pageant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Above_All_Beauty_Pageant.Persistant.Repository
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly AboveAllContext _context;
        public ReceiptRepository(AboveAllContext db)
        {
            _context = db;
        }

        public void PurchaseMade(int id, double amount, DateTime purchaseDate)
        {
            _context.Receipts.Add(new Receipt(id, amount, purchaseDate));
        }

        public Receipt GetReceipt(int id)
        {
            return _context.Receipts.FirstOrDefault(r => r.ParticipantId == id);
        }
    }
}