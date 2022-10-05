using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.FileUploads
{
    /// <summary>
    /// post data for VAT Registration.
    /// </summary>
    public abstract class FileTypes
    {
        public abstract Task<ActionResult> PostData(VatRegistrationRequest request);
    }
}
