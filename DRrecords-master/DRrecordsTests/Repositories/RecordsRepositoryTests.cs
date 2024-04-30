using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRrecords.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRrecords.Models;

namespace DRrecords.Repositories.Tests
{
    [TestClass()]
    public class RecordsRepositoryTests
    {
        private static RecordsRepository _recordsRepository = new();
        private readonly Record rGood = new Record() { Id = 0, Artist = "Hollow Front", Title = "Breaking Teeth", ReleaseYear = 2024, Genre = "Metal", LengthInSeconds = 4 };
        private readonly Record rBad = new Record() { Id = 0, Artist = "", Title = "", ReleaseYear = 2000, Genre = "", LengthInSeconds = -1 };
        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<Record> records = _recordsRepository.GetAll();
            Assert.AreEqual(3, records.Count());
            Assert.AreEqual("Death Grips", records.First().Artist);
        }
        [TestMethod()]
        public void GetByIdTest()
        { 
            Assert.IsNotNull(_recordsRepository.GetById(4));
            Assert.IsNull(_recordsRepository.GetById(3));
        }
        [TestMethod()]
        public void AddRecordTest()
        {
            Assert.AreEqual(7, _recordsRepository.AddRecord(rGood)?.Id);
            Assert.AreEqual(4, _recordsRepository.GetAll().Count());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _recordsRepository.AddRecord(rBad));

        }
        [TestMethod()]
        public void DeleteRecordTest()
        {
            Assert.IsNull(_recordsRepository.DeleteRecord(7));
            Assert.AreEqual(7, _recordsRepository.DeleteRecord(7)?.Id);
            Assert.AreEqual(3, _recordsRepository.GetAll().Count());
        }
        [TestMethod()]
        public void UpdateRecord()
        {
        }
    }
}