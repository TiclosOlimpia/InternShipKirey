using AgendaDBFirst.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDBFirst.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AgendaTelefonicaEntities _context;
        public IContactRepository Contacts { get; private set; }

        public UnitOfWork(AgendaTelefonicaEntities context)
        {
            _context = context;
            Contacts = new ContactRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
