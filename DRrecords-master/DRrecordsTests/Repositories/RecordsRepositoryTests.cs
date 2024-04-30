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
            Record record = new Record();
        }
        [TestMethod()]
        public void GetByIdTest()
        { 
        }
        [TestMethod()]
        public void AddRecordTest()2
        {
        }
        [TestMethod()]
        public void DeleteRecordTest()
        {
        }
        [TestMethod()]
        public void UpdateRecord()
        {
        }
    }
}