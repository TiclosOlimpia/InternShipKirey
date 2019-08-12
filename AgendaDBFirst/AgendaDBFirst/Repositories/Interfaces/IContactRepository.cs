using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDBFirst.Repositories.Interfaces
{
    public interface IContactRepository: IRepository<Agendum>
    {
        void AddContact(Agendum a);
        void DeleteContact(string s);

        void UpdateContact(string s1, string s2);

    }
}
