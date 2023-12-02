using ECommerce.Models;

namespace ECommerce.Services
{
    public interface IDatasetService
    {
        IList<Dataset> ListAll();
        Dataset GetDataset(int id);
        void Insert(Dataset dataset);
        void Update(Dataset dataset);
        void Delete(int id);
    }
}
