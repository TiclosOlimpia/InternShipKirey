using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AgendaDBFirst.Repositories.Interfaces;


namespace AgendaDBFirst.Repositories
{
    public class ContactRepository : Repository<Agendum>, IContactRepository
    {
        public ContactRepository(AgendaTelefonicaEntities context): base (context)
        { }
        public void AddContact(Agendum a)
        {
            var contact = GetAll().Any(x => x.NrTelefon.Equals(a.NrTelefon));
            if (contact)
                throw new Exception("Acest contact exista deja in agenda");

            Add(a);
        }

        public void DeleteContact(string s)
        {
            var contact = GetAll().Where(x => (x.Nume+x.Prenume).Contains(s)).FirstOrDefault();
            if (contact==null)
                throw new Exception("Acest contact nu exist in agenda");
            Remove(contact);
        }

        public void UpdateContact(string oldName, string newName)
        {
            var contact = GetAll().Where(x => x.Nume.Equals(oldName)).FirstOrDefault();
            if (contact == null)
                throw new Exception("Acest contact nu exist in agenda");

            contact.Nume = newName;
            Update(contact);
        }
    }
}
