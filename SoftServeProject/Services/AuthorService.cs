using Microsoft.EntityFrameworkCore;
using SoftServeProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeProject.Services
{
    public class AuthorService : IAuthorService
    {
        UserDBContext db;
        public AuthorService(UserDBContext _db)
        {
            db = _db;
        }

        public List<Author> GetAuthorByFullName(string name, string surname)
        {
            List<Author> auth = new List<Author>();
            if (GetAuthorByName(name).SequenceEqual(GetAuthorBySurname(surname)))
                auth = GetAuthorByName(name).Where(s => s.Name == name && s.Surname == surname).ToList();
            return auth;
        }

        public Author GetAuthorById(int id)
        {
            Author auth = db.Authors.Where(s => s.Authorid == id)
                .Include(s => s.Books)
                .FirstOrDefault();
            return auth;
        }

        public List<Author> GetAuthorByName(string name)
        {
            List<Author> auth = db.Authors
                .Where(s => s.Name == name)
                .Include(s => s.Books)
                .ToList();
            return auth;
        }

        public List<Author> GetAuthorBySurname(string surname)
        {
            List<Author> auth = db.Authors
                .Where(s => s.Surname == surname)
                .Include(s => s.Books)
                .ToList();
            return auth;
        }

      
    }
}
