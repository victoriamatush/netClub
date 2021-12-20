using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SoftServeProject.Services
{
    public struct AllReadersStat
    {
        public double avgAgeOfClient;
        public double avgTimeOfWorking;
        public double avgNumOfRequest;
    }
    public struct ReaderStat
    {
        public readonly List<Book> books;
        public readonly double howLongIsSubscriber;
        public readonly double howLongRead;
        public ReaderStat(List<Book> _books, double _howLongIsSubscriber, double _howLongRead)
        {
            books = _books;
            howLongIsSubscriber = _howLongIsSubscriber;
            howLongRead = _howLongRead;

        }
    }
    public interface IReaderStatistics
  {
    public ReaderStat GetReaderStatistics(int id);
    public AllReadersStat GetAllReadersStatistics(DateTime startingDate, DateTime endingDate);
    public List<Reader> GetInfoAboutNotReturnedBooks(int id);

  }
}
