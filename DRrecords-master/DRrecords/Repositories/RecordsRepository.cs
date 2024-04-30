using DRrecords.Models;

namespace DRrecords.Repositories
{
    public class RecordsRepository
    {
        private static int _nextId = 4;
        private static readonly List<Record> RecordList = new()
        {
            new Record { Id = _nextId++, Artist = "Death Grips", Title = "The Powers That B", ReleaseYear = 2015, Genre = "industrial hip hop", LengthInSeconds = 80},
            new Record { Id = _nextId++, Artist = "Swans", Title = "Soundtracks for the Blind", ReleaseYear = 1996, Genre = "experimental rock", LengthInSeconds = 141},
            new Record { Id = _nextId++, Artist = "Have A Nice Life", Title = "Deathconsciousness", ReleaseYear = 2008, Genre = "shoegaze", LengthInSeconds = 84 }
        };

        public IEnumerable<Record> GetAll()
        {
            return RecordList;
        }

        public Record? GetById(int id)
        {
            return RecordList.Find(record => record.Id == id);
        }

        public Record? AddRecord(Record newRecord)
        {
            newRecord.Id = _nextId++;
            newRecord.Validation();
            RecordList.Add(newRecord);
            return newRecord;
        }

        public Record? DeleteRecord(int id)
        {
            Record? record = GetById(id);
            if (record == null)
            {
                return null;
            }
            RecordList.Remove(record);
            return record;
        }

        public Record? UpdateRecord(int id, Record record)
        {
            record.Validation();
            Record? RecordToUpdate = GetById(id);
            if (RecordToUpdate == null)
            {
                return null;
            }
            RecordToUpdate.Id = record.Id;
            RecordToUpdate.Artist = record.Artist;
            RecordToUpdate.Title = record.Title;
            RecordToUpdate.Genre = record.Genre;
            RecordToUpdate.LengthInSeconds = record.LengthInSeconds;
            return RecordToUpdate;
        }
    }
}
