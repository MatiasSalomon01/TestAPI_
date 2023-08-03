using ClosedXML.Excel;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;

namespace TestAPI_.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _context;

        public FileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            if (file is null || file.Length <= 0) return new Response(400, "BadRequest", DateTime.Now);

            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension is ".xlsx") return await ManageExcelFiles(file, cancellationToken);
            else return await ManageCsvFiles(file, cancellationToken);
        }

        public async Task<Response> ManageExcelFiles(IFormFile file, CancellationToken cancellationToken)
        {
            var workbook = new XLWorkbook(file.OpenReadStream());

            var page = workbook.Worksheet(1);

            int firstRowUsed = page.FirstRowUsed().RangeAddress.FirstAddress.RowNumber + 1;
            int lastRowUsed = page.LastRowUsed().RangeAddress.FirstAddress.RowNumber;

            var listModels = new List<ImportContentModel>();
            for (int i = firstRowUsed; i <= lastRowUsed; i++)
            {
                var model = new ImportContentModel();
                var row = page.Row(i);
                model.codigo = row.Cell(1).GetValue<int>();
                model.nombre = row.Cell(2).GetString();
                model.apellido = row.Cell(3).GetString();
                model.ciudad_recide = row.Cell(4).GetString();
                listModels.Add(model);
            }

            //await InsertBulkData(listModels, cancellationToken);

            return new Response(200, "Excel insertado con exito", DateTime.Now);
        }

        public async Task<Response> ManageCsvFiles(IFormFile file, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream, cancellationToken);
                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var streamReader = new StreamReader(memoryStream))
                {
                    var firstLine = streamReader.ReadLine();
                    var headers = firstLine.Split(",");

                    var propertiesName = typeof(ImportContentModel).GetProperties().Select(x => x.Name).ToList();

                    if (!propertiesName.SequenceEqual(headers)) 
                        throw new Exception("csv-headers");
                
                }

                using (var streamReader = new StreamReader(memoryStream))
                {
                    var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        UseNewObjectForNullReferenceMembers = true,
                        WhiteSpaceChars = new[] { '-' },
                        IgnoreBlankLines = true,
                        Delimiter = ",",
                        NewLine = "\r\n",
                        MissingFieldFound = null
                    };

                    var csvReader = new CsvReader(streamReader, configuration);
                    var records = csvReader.GetRecords<ImportContentModel>().ToList();

                    //await InsertBulkData(records, cancellationToken);
                    return new Response(200, "Csv insertado con exito", DateTime.Now);
                }
            }
        }

        public async Task InsertBulkData(List<ImportContentModel> importContentModels, CancellationToken cancellationToken)
        {
            var entities = importContentModels.Select(i => new ImportContent
            {
                Nombre = i.nombre,
                Apellido = i.apellido,
                Ciudad = i.ciudad_recide
            }).ToList();

            var entitiesToBeRemoved = await _context.ImportsContent.ToListAsync(cancellationToken);
            _context.ImportsContent.RemoveRange(entitiesToBeRemoved);

            await _context.ImportsContent.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
