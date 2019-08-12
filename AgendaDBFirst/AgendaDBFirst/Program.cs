using AgendaDBFirst.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //    GetContacts();

            //    GetContactsFromRO();

            //    GetCountContacts();

            //AgendaTelefonicaEntities context = new AgendaTelefonicaEntities();

            //    GetContactsGroupedByState(context);

            //    GetCallsHistory(context);

            var contact = new Agendum
            {
                Nume = "Popescu",
                Prenume = "Georgel",
                NrTelefon = "0347654321",
                DataNasterii = new DateTime(2019, 01, 01),
                Stat = "RO"
            };

            //context.Agenda.Add(contact);
            //context.SaveChanges();

            //DeletePop(context);


            //UpdateName(context);

            using (UnitOfWork unitOfWork = new UnitOfWork(new AgendaTelefonicaEntities()))
            {
                var contacts = unitOfWork.Contacts;

                unitOfWork.Contacts.AddContact(contact);
                unitOfWork.Contacts.UpdateContact("Popescu", "Georgescu");
                unitOfWork.Contacts.DeleteContact("Geo");

                var allContacts = unitOfWork.Contacts.GetAll();

                foreach(var co in allContacts)
                {
                    Console.WriteLine(co.Nume+" "+co.Prenume);
                }

            }

            Console.ReadLine();
        }
        public static void GetContacts()
        {
            IEnumerable result = new List<string>();
            using (AgendaTelefonicaEntities context = new AgendaTelefonicaEntities())
            {
                result = context.Agenda
                    .OrderByDescending(c => c.DataNasterii)
                    .ToArray()
                    .Select(c => string.Format("nume: {0} \n prenume: {1} \n dataNasterii: {2}", c.Nume, c.Prenume, c.DataNasterii?.ToString("dd-MMM-yyyy")));
            };
            Console.WriteLine("Contacte ordonate: \n");


            foreach (var r in result)
            {
                Console.WriteLine(r);
            }

        }

        public static void GetContactsFromRO()
        {
            IEnumerable result = new List<string>();
            using (AgendaTelefonicaEntities context = new AgendaTelefonicaEntities())
            {
                result = context.Agenda
                    .Where(c => c.Stat.Equals("RO"))
                    .ToArray()
                    .Select(c => string.Format("nume: {0} \n prenume: {1} \n dataNasterii: {2} \n Stat: {3}", c.Nume, c.Prenume, c.DataNasterii?.ToString("dd-MMM-yyyy"), c.Stat));
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Contacte din Romania: \n");
            foreach (var r in result)
            {
                Console.WriteLine(r);
                Console.WriteLine();
            }
        }

        public static void GetCountContacts()
        {
            IEnumerable result = new List<string>();
            using (AgendaTelefonicaEntities context = new AgendaTelefonicaEntities())
            {
                result = context.Agenda
                    .GroupBy(c=> c.Stat)
                    .ToArray()
                    .Select(c => string.Format("NR contacte din {0} este {1}", c.Key, c.Count()));
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Numarul de contacte din fiecare stat: \n");
            foreach (var r in result)
            {
                Console.WriteLine(r);
                Console.WriteLine();
            }
        }

        public static void GetContactsGroupedByState(AgendaTelefonicaEntities context)
        {
            var result = from c in context.Agenda
                         group c by c.Stat;

            Console.WriteLine("\r\n ----These are contacts blabla ------------");

            foreach (var r in result)
            {
                Console.WriteLine("\r\n  State: {0} \r\n", r.Key);

                foreach(var i in r)
                {
                    Console.WriteLine("{0} {1}", i.Nume, i.Prenume);
                }
            }
        }

        public static void GetCallsHistory(AgendaTelefonicaEntities context)
        {
            var result = from c in context.IstoricApeluris
                         join s in context.Agenda on c.NrTelefon equals s.NrTelefon
                         select new { primit = c.Ptimit==true? "DA": "NU", DataSIOra= c.DataSiOra, Durata= c.Durata , Nume = s.Nume+" "+s.Prenume };

            Console.WriteLine("---------------------------Hitory---------------\r\n");
            Console.WriteLine("Primit \t DataSiOra \t\t\t Durata \t Nume \r\n");

            foreach(var r in result)
            {
                Console.WriteLine("{0} \t{1} \t\t{2} \t{3}", r.primit, r.DataSIOra, r.Durata, r.Nume);
            }

        }

        public static void DeletePop(AgendaTelefonicaEntities context)
        {
            var res = from c in context.Agenda
                      where c.Nume.Contains("Pop")
                      select c;

            if (res.Count() == 0)
                return;
            context.Agenda.Remove(res.FirstOrDefault());
            context.SaveChanges();
        }

        public static void UpdateName(AgendaTelefonicaEntities context)
        {
            var res = from c in context.Agenda
                      where c.Nume.Equals("Ticlos") && c.Prenume.Equals("Olimpia")
                      select c;

            if (res.Count() == 0)
                return;
            res.FirstOrDefault().Prenume = "Iustina";
            context.SaveChanges();
        }

        public static void LazyLoading(AgendaTelefonicaEntities context)
        {
            var res = from c in context.Agenda
                      select c;

            var final = from c in res
                        select c.Nume;


        }

        public static void EagerLoading(AgendaTelefonicaEntities context)
        {
            var res = from c in context.IstoricApeluris.Include("Agenda")
                      select new { Nume = c.Agendum.Nume, DataSiOra = c.DataSiOra };
        }

        public static void ExplicitLoading(AgendaTelefonicaEntities context)
        {
            context.Configuration.LazyLoadingEnabled = false;

            var calls = (from c in context.Agenda
                        orderby c.Nume
                        select c).Take(3).ToList();

        }

    }
}
