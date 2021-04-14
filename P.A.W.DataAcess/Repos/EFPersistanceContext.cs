using PAW.DataAcess;
using PAWDataAcess.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PAWDataAcess.Repos
{
    public class EFPersistanceContext : IPersistanceContext
    {
        private readonly PAWDbContext dbContext;
        private TransactionScope currentTransactionScope = null;  // nui adaugat
        public EFPersistanceContext(PAWDbContext context)
        {
            this.dbContext = context;

            SongRepository = new EFSongRepository(context);
          
        }

        public ISongRepository SongRepository { get; private set; }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
           
        }
    }
}
