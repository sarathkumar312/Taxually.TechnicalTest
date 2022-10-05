using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.FileUploads
{
    public class XmlFileType : FileTypes
    {
        /// <summary>
        /// XML file VAT Return for different countries.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override Task<ActionResult> PostData(VatRegistrationRequest request)
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringwriter, this);
                var xml = stringwriter.ToString();
                var xmlQueueClient = new TaxuallyQueueClient();
                // Queue xml doc to be processed
                xmlQueueClient.EnqueueAsync("vat-registration-xml", xml).Wait();
                return (Task<ActionResult>)Task.CompletedTask;
            }
        }
    }
}
