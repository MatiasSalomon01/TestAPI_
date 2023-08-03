using TestAPI_.Models;

namespace TestAPI_.Interfaces.Services
{
    public interface IFileService
    {
        Task<Response> UploadFile(IFormFile file, CancellationToken cancellationToken);
        Task<Response> ManageExcelFiles(IFormFile file, CancellationToken cancellationToken);
        Task<Response> ManageCsvFiles(IFormFile file, CancellationToken cancellationToken);
        Task InsertBulkData(List<ImportContentModel> importContentModels, CancellationToken cancellationToken);
    }
}
