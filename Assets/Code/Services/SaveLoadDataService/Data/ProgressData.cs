using System;

namespace Code.Services.SaveLoadDataService.Data
{
    [Serializable]
    public class ProgressData : ILoadable, ISavable
    {
        public int Record { get; set; }
        
        public event Action<int> RecordUpdated;

        public void WriteRecord(int newRecord)
        {
            if (newRecord < 0)
                throw new ArgumentException(nameof(newRecord));
            
            Record = newRecord;
            
            RecordUpdated?.Invoke(Record);
        }
        
        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            var loadable = saveLoadDataService.Load<ProgressData>();

            if (loadable == null)
                return;

            Record = loadable.Record;
            
            RecordUpdated?.Invoke(Record);
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService) => 
            saveLoadDataService.Save<ProgressData>(this);
    }
}