using C_sharp_egzaminas.Entity;

namespace C_sharp_egzaminas.Repository
{
    public class RecordRepository
    {
        List<ReportItem> Records { get; }

        public RecordRepository()
        {
            Records = new List<ReportItem>();
        }

        public void AddItem(ReportItem item)
        {
            Records.Add(item);
        }

        public void AddItems(List<ReportItem> items)
        {
            Records.Concat(items);
        }

        public void DeleteById(int id)
        {
            Records.Remove(GetById(id));
        }

        public ReportItem GetById(int id)
        {
            return Records.SingleOrDefault(x => x.Id == id);
        }

        public List<ReportItem> GetAll()
        {
            return Records;
        }

    }
}