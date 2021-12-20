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
        public List<Book> books;
        public double howLongSub;
    }
    public interface IReaderStatistics
  {
    public ReaderStat GetReaderStatistics(int id);
    public AllReadersStat GetAllReadersStatistics(DateTime startingDate, DateTime endingDate);
    public List<int> GetInfoAboutNotReturnedBooks(int id);

  }
}
