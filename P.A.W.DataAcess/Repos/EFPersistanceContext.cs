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
        private TransactionScope currentTransactionScope = null;
        public EFPersistanceContext(PAWDbContext context)
        {
            this.dbContext = context;

            SongRepository = new EFSongRepository(context);
            QuizRepository = new EFQuizRepository(context);
          
        }

        public ISongRepository SongRepository { get; private set; }

        public IQuizRepository QuizRepository { get; private set; }

        public TransactionScope BeginTransaction()
        {
            if (currentTransactionScope != null)
            {
                throw new TransactionException("A transaction is already in progress for this context");
            }
            currentTransactionScope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            return currentTransactionScope;
        }

        public void Dispose()
        {

            dbContext.Dispose();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
            if (currentTransactionScope != null)
            {
                currentTransactionScope.Complete();
            }

            currentTransactionScope = null;
        }
    }
}
