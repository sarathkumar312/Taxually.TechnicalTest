using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.Utilities;
using Taxually.TechnicalTest.Enums;
using Taxually.TechnicalTest.FileUploads;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private ILogUtility? logUtility;

        /// <summary>
        /// Gets or sets logger.
        /// </summary>
        public ILogUtility LogUtility
        {
            get
            {
                if (this.logUtility == null)
                {
                    this.logUtility = new LogUtility();
                }

                return this.logUtility;
            }

            set
            {
                this.logUtility = value;
            }
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post(VatRegistrationRequest request)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(request.Country))
                {
                    var countryType = (Country)Enum.Parse(typeof(Country), request.Country, true);
                    var fileFactory = new FileFactory();
                    var fileType = fileFactory.GetDataBasedOnFileType(countryType);
                    var result = fileType.PostData(request);
                    return await result;
                }
            }
            catch (Exception ex)
            {
                this.LogUtility.LogException(ex, "Country not supported.");
            }
            return Ok();
        }
    }
}
