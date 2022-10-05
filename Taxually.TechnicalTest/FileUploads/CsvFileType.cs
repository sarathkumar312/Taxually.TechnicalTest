using Microsoft.AspNetCore.Mvc;
using System.Text;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.FileUploads
{
    public class CsvFileType : FileTypes
    {
        /// <summary>
        /// csv file VAT Calculation Return for different countries.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override Task<ActionResult> PostData(VatRegistrationRequest request)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var excelQueueClient = new TaxuallyQueueClient();
            // Queue file to be processed
            excelQueueClient.EnqueueAsync("vat-registration-csv", csv).Wait();
            return (Task<ActionResult>)Task.CompletedTask;
        }
    }
}
