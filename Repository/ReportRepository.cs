using C_sharp_egzaminas.Entity;

namespace C_sharp_egzaminas.Repository
{
    public class ReportRepository
    {
        List<ReportItem> Reports { get; }

        public ReportRepository()
        {
            Reports = new List<ReportItem>();
        }

        public void AddItem(ReportItem item)
        {
            Reports.Add(item);
        }

        public void AddItems(List<ReportItem> items)
        {
            Reports.Concat(items);
        }

        public void DeleteById(int id)
        {
            Reports.Remove(GetById(id));
        }

        public ReportItem GetById(int id)
        {
            return Reports.SingleOrDefault(x => x.Id == id);
        }

        public List<ReportItem> GetAll()
        {
            return Reports;
        }

    }
}