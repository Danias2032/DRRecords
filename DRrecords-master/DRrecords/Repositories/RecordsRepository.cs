using DRrecords.Models;

namespace DRrecords.Repositories
{
    public class RecordsRepository
    {
        private static int _nextId = 4;
        private static readonly List<Record> RecordList = new()
        {
            new Record { id = _nextId++, artist = "Death Grips", title = "The Powers That B", releaseYear = 2015, genre = "industrial hip hop", lengthInMin = 80},
            new Record { id = _nextId++, artist = "Swans", title = "Soundtracks for the Blind", releaseYear = 1996, genre = "experimental rock", lengthInMin = 141},
            new Record { id = _nextId++, artist = "Have A Nice Life", title = "Deathconsciousness", releaseYear = 2008, genre = "shoegaze", lengthInMin = 84 }
        };

        public IEnumerable<Record> GetAll()
        {
            return RecordList;
        }

        public Record? GetById(int id)
        {
            return RecordList.Find(record => record.id == id);
        }

        public Record? AddRecord(Record newRecord)
        {
            newRecord.id = _nextId++;
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
            Record? RecordToUpdate = GetById(id);
            if (RecordToUpdate == null)
            {
                return null;
            }
            RecordToUpdate.id = record.id;
            RecordToUpdate.artist = record.artist;
            RecordToUpdate.title = record.title;
            RecordToUpdate.genre = record.genre;
            RecordToUpdate.lengthInMin = record.lengthInMin;
            return RecordToUpdate;
        }
    }
}
