using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Interfaces
{
    interface IAuthorService
    {
        public Author GetAuthorById(int id);
        public List<Author> GetAuthorByName(string name);
        public List<Author> GetAuthorBySurname(string surname);
        public List<Author> GetAuthorByFullName(string name, string surname);


    }
}
