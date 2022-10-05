using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.FileUploads
{
    public class ApiAsFile : FileTypes
    {
        /// <summary>
        /// API to Register VAT for UK Companies
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override Task<ActionResult> PostData(VatRegistrationRequest request)
        {
            var httpClient = new TaxuallyHttpClient();
            httpClient.PostAsync("https://api.uktax.gov.uk", request).Wait();
            return (Task<ActionResult>)Task.CompletedTask;
        }
    }
}
