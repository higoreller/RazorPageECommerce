using ECommerce.Models;
using System.Text.RegularExpressions;

namespace ECommerce.Services.Memory
{
    public class DatasetService : IDatasetService
    {
        private IList<Dataset> _datasets;
        public DatasetService() => LoadInicialList();

        private void LoadInicialList()
        {
            _datasets = new List<Dataset>()
            {
                new Dataset { Id = 1, Title = "Dataset 1", Description = "Descrição 1", ImageUrl="/img/dataset-default.jpg", Size = 100, Source = "Fonte 1", Category = "Categoria 1", DateCreated = DateTime.Now, Format = "CSV" },
                new Dataset { Id = 2, Title = "Dataset 2", Description = "Descrição 2", ImageUrl="/img/dataset-default.jpg", Size = 200, Source = "Fonte 2", Category = "Categoria 2", DateCreated = DateTime.Now.AddDays(-1), Format = "Excel" },
                new Dataset { Id = 3, Title = "Dataset 3", Description = "Descrição 3", ImageUrl="/img/dataset-default.jpg", Size = 300, Source = "Fonte 3", Category = "Categoria 3", DateCreated = DateTime.Now.AddDays(-2), Format = "JSON" },
                new Dataset { Id = 4, Title = "Dataset 4", Description = "Descrição 4", ImageUrl="/img/dataset-default.jpg", Size = 400, Source = "Fonte 4", Category = "Categoria 4", DateCreated = DateTime.Now.AddDays(-3), Format = "XML" },
                new Dataset { Id = 5, Title = "Dataset 5", Description = "Descrição 5", ImageUrl="/img/dataset-default.jpg", Size = 500, Source = "Fonte 5", Category = "Categoria 5", DateCreated = DateTime.Now.AddDays(-4), Format = "TXT" },
                new Dataset { Id = 6, Title = "Dataset 6", Description = "Descrição 6", ImageUrl="/img/dataset-default.jpg", Size = 600, Source = "Fonte 6", Category = "Categoria 6", DateCreated = DateTime.Now.AddDays(-5), Format = "CSV" },
                new Dataset { Id = 7, Title = "Dataset 7", Description = "Descrição 7", ImageUrl = "/img/dataset-default.jpg", Size = 700, Source = "Fonte 7", Category = "Categoria 7", DateCreated = DateTime.Now.AddDays(-6), Format = "Excel" },
                new Dataset { Id = 8, Title = "Dataset 8", Description = "Descrição 8", ImageUrl = "/img/dataset-default.jpg", Size = 800, Source = "Fonte 8", Category = "Categoria 8", DateCreated = DateTime.Now.AddDays(-7), Format = "JSON" },
                new Dataset { Id = 9, Title = "Dataset 9", Description = "Descrição 9", ImageUrl = "/img/dataset-default.jpg", Size = 900, Source = "Fonte 9", Category = "Categoria 9", DateCreated = DateTime.Now.AddDays(-8), Format = "XML" },
                new Dataset { Id = 10, Title = "Dataset 10", Description = "Descrição 10", ImageUrl="/img/dataset-default.jpg", Size = 1000, Source = "Fonte 10", Category = "Categoria 10", DateCreated = DateTime.Now.AddDays(-9), Format = "TXT" },
                new Dataset { Id = 11, Title = "Dataset 11", Description = "Descrição 11", ImageUrl="/img/dataset-default.jpg", Size = 1100, Source = "Fonte 11", Category = "Categoria 11", DateCreated = DateTime.Now.AddDays(-10), Format = "CSV" },
                new Dataset { Id = 12, Title = "Dataset 12", Description = "Descrição 12", ImageUrl="/img/dataset-default.jpg", Size = 1200, Source = "Fonte 12", Category = "Categoria 12", DateCreated = DateTime.Now.AddDays(-11), Format = "Excel" },
                new Dataset { Id = 13, Title = "Dataset 13", Description = "Descrição 13", ImageUrl="/img/dataset-default.jpg", Size = 1300, Source = "Fonte 13", Category = "Categoria 13", DateCreated = DateTime.Now.AddDays(-12), Format = "JSON" },
                new Dataset { Id = 14, Title = "Dataset 14", Description = "Descrição 14", ImageUrl="/img/dataset-default.jpg", Size = 1400, Source = "Fonte 14", Category = "Categoria 14", DateCreated = DateTime.Now.AddDays(-13), Format = "XML" },
                new Dataset { Id = 15, Title = "Dataset 15", Description = "Descrição 15", ImageUrl="/img/dataset-default.jpg", Size = 1500, Source = "Fonte 15", Category = "Categoria 15", DateCreated = DateTime.Now.AddDays(-14), Format = "TXT" },
            };
        }
        public IList<Dataset> ListAll() => _datasets;

        public Dataset GetDataset(int id)
        {
            return _datasets.SingleOrDefault(item => item.Id == id);
        }

        public void Insert(Dataset dataset)
        {
            var nextNumber = _datasets.Max(item => item.Id) + 1;
            dataset.Id = nextNumber;
            _datasets.Add(dataset);
        }

        public void Update(Dataset dataset)
        {
            var datasetFound = GetDataset(dataset.Id);
            if (datasetFound != null)
            {
                datasetFound.Title = dataset.Title;
                datasetFound.Description = dataset.Description;
                datasetFound.ImageUrl = dataset.ImageUrl;
                datasetFound.Size = dataset.Size;
                datasetFound.Source = dataset.Source;
                datasetFound.Category = dataset.Category;
                datasetFound.DateCreated = dataset.DateCreated;
                datasetFound.Format = dataset.Format;
            }

        }

        public void Delete(int id)
        {
            var datasetFound = GetDataset(id);
            _datasets.Remove(datasetFound);
        }

        public IList<Brand> GetAllBrands()
        {
            return new List<Brand>()
            {
                new Brand() { Description = "OpenAI" },
                new Brand() { Description = "Discord" },
            new Brand() { Description = "TeamAI" },
        };
        }

        public IList<Category> GetAllCategories()
        {
            return new List<Category>()
        {
            new Category() { Description = "Plants" },
            new Category() { Description = "Faces" },
            new Category() { Description = "Animals" },
            new Category() { Description = "Numbers" },
        };

        }

        public void InitializeData()
        {
            throw new NotImplementedException();
        }
    }
}
