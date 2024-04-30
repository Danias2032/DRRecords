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
        RecordsRepository _recordsRepository = new();
        [TestMethod()]
        public void GetAllTest()
        {
            IEnumerable<Record> records = _recordsRepository.GetAll();
            Assert.AreEqual(3, records.Count());
            Assert.AreEqual("Death Grips", records.First().artist);
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
            Record r = new Record() { id = 0, artist = "Hollow Front", title = "Breaking Teeth", releaseYear = 2024, genre = "Metal", lengthInMin = 4 };
            Assert.AreEqual(7, _recordsRepository.AddRecord(r).id);
            Assert.AreEqual(4, _recordsRepository.GetAll().Count());
            Assert.ThrowsException<IndexOutOfRangeException>(() => _recordsRepository.AddRecord(r));

        }
        [TestMethod()]
        public void DeleteRecordTest()
        {
            Record r = new Record() { id = 0, artist = "Hollow Front", title = "Breaking Teeth", releaseYear = 2024, genre = "Metal", lengthInMin = 4 };
            Assert.IsNull(_recordsRepository.DeleteRecord(7));
            Assert.AreEqual(7, _recordsRepository.DeleteRecord(r).id);
            Assert.AreEqual(3, _recordsRepository.GetAll().Count());
        }
        [TestMethod()]
        public void UpdateRecord()
        {
        }
    }
}