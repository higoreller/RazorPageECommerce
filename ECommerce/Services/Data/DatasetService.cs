using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Data;

public class DatasetService : IDatasetService
{
    private DatasetDbContext _context;

    public DatasetService(DatasetDbContext context)
    {
        _context = context;
    }

    public void Update(Dataset dataset)
    {
        var datasetFound = GetDataset(dataset.Id);
        datasetFound.Title = dataset.Title;
        datasetFound.Description = dataset.Description;
        datasetFound.ImageUrl = dataset.ImageUrl;
        datasetFound.Size = dataset.Size;
        datasetFound.Source = dataset.Source;
        datasetFound.Category = dataset.Category;
        datasetFound.DateCreated = dataset.DateCreated;
        datasetFound.Format = dataset.Format;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var datasetFound = GetDataset(id);
        _context.Dataset.Remove(datasetFound);
        _context.SaveChanges();
    }

    public void Insert(Dataset dataset)
    {
        _context.Dataset.Add(dataset);
        _context.SaveChanges();
    }

    public Dataset GetDataset(int id)
    {
        return _context.Dataset
                        .Include(item => item.Categories)
                        .SingleOrDefault(item => item.Id == id);
    }

    public IList<Category> GetAllCategories()
    {
        return _context.Category.ToList();
    }

    public IList<Brand> GetAllBrands()
    {
        return _context.Brand.ToList();
    }

    public IList<Dataset> ListAll()
    {
        return _context.Dataset.ToList();
    }

    public void InitializeData()
    {
        if (!_context.Brand.Any())
        {
            _context.Brand.AddRange(
                new Brand { Description = "OpenAI" },
                new Brand { Description = "DALL-E" }
            );
        }

        if (!_context.Category.Any())
        {
            _context.Category.AddRange(
                new Category { Description = "Categoria da Plantas" },
                new Category { Description = "Categoria de Animais" }
            );
        }

        _context.SaveChanges();
    }
}