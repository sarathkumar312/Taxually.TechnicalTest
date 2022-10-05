using Taxually.TechnicalTest.Enums;

namespace Taxually.TechnicalTest.FileUploads
{
    public class FileFactory
    {
        /// <summary>
        /// file type dictionary to store country and file type.
        /// </summary>
        private Dictionary<Country, Func<FileTypes>> _fileTypes;

        /// <summary>
        /// file factory for each country's VAT calculation.
        /// </summary>
        public FileFactory()
        {
            _fileTypes = new Dictionary<Country, Func<FileTypes>>();
            _fileTypes.Add(Country.GB, () => { return new ApiAsFile(); });
            _fileTypes.Add(Country.FR, () => { return new CsvFileType(); });
            _fileTypes.Add(Country.DE, () => { return new XmlFileType(); });
        }

        /// <summary>
        /// send data based on file type and country.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public FileTypes GetDataBasedOnFileType(Country country)
        {
            return _fileTypes[country]();
        }

    }
}
