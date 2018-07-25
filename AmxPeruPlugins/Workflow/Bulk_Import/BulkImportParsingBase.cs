using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ericsson.ETELCRM.Business.BulkImport.Interfaces;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Repository;
using Ericsson.ETELCRM.Business.BulkImport;
using Ericsson.ETELCRM.Entities.Crm;


namespace AmxPeruPlugins.Workflow.Bulk_Import
{
    public abstract class BulkImportParsingBase<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected BulkImportParsingBase(IActionContext context)
        {
            ActionContext = context;
            BulkImportValidator = ActionContext.Resolve<IBulkImportValidator>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BulkImportParsingBase" /> class.
        /// </summary>
        protected BulkImportParsingBase()
        {
            BulkImportValidator = ActionContext.Resolve<IBulkImportValidator>();
        }

        protected BulkImportParsingBase(bool empty)
        {
            BulkImportValidator = ActionContext.Resolve<IBulkImportValidator>();
        }

        /// <summary>
        /// Gets or sets the action context.
        /// </summary>
        public IActionContext ActionContext { get; set; }

        /// <summary>
        /// Gets the corporate customers.
        /// </summary>
        /// <param name="bulkImportId">The bulk import identifier.</param>
        /// <returns></returns>
        public IEnumerable<ParsedEntityContainer<T>> GetParsedEntity(Annotation annotation)
        {
            var recordSet = RetrieveInputFileRecords(annotation);
            var fieldCount = RetrieveFieldCount();
            foreach (var record in recordSet)
            {
                var fields = record.Split(new[] { ',' }).Select(f => f.Trim()).ToArray();
                if (fields.Length == fieldCount)
                {
                    T parsedData = ParseData(fields);
                    var parsedResult = new ParsedEntityContainer<T>(parsedData);
                    ValidateRecord(parsedResult);
                    yield return parsedResult;
                }
            }
        }

        /// <summary>
        /// Gets the corporate customers.
        /// </summary>
        /// <param name="bulkImportId">The bulk import identifier.</param>
        /// <returns></returns>
        //public IEnumerable<ParsedEntityContainer<T>> GetParsedEntityWithoutValidation(Annotation annotation)
        //{
        //    var recordSet = RetrieveInputFileRecords(annotation);
        //    foreach (var record in recordSet)
        //    {
        //        var fields = record.Split(new[] { ',' }).Select(f => f.Trim()).ToArray();
        //        T parsedData = ParseData(fields);
        //        var parsedResult = new ParsedEntityContainer<T>(parsedData);
        //        yield return parsedResult;
        //    }
        //}

        public IEnumerable<ParsedEntityContainer<T>> GetParsedEntityWithoutValidation(List<string> recordSet)
        {
            foreach (var record in recordSet)
            {
                var fields = record.Split(new[] { ',' }).Select(f => f.Trim()).ToArray();
                T parsedData = ParseData(fields);
                var parsedResult = new ParsedEntityContainer<T>(parsedData);
                yield return parsedResult;
            }
        }


        /// <summary>
        /// Get Parsed Data
        /// </summary>
        /// <param name="bulkImportId">Bulk Import Id</param>
        /// <param name="annotationId">Annotation Id</param>
        /// <returns>List of New Subscription</returns>
        public List<string> RetrieveInputFileRecords(Annotation annotation)
        {
            return ReadTemplate(annotation);

        }
        /// <summary>
        /// to ReadTemplate
        /// </summary>
        /// <param name = "bulkImportId">BulkImport File</param>
        /// <returns>list of string</returns>
        public List<string> ReadTemplate(Annotation annotation)
        {
            if (annotation != null)
            {
                if (!string.IsNullOrEmpty(annotation.DocumentBody))
                {
                    var fileData = Convert.FromBase64String(annotation.DocumentBody);
                    if (fileData.Length > 0)
                    {
                        string[] data = Encoding.UTF8.GetString(fileData).Split(new char[] { '\n' });
                        data = data.Where((val, idx) => idx != 0).ToArray();            //// to skip header
                        return data.ToList();
                    }
                }
            }
            return null;

        }



        /// <summary>
        /// Retrieves the field count.
        /// </summary>
        /// <returns>Field Count</returns>
        public abstract int RetrieveFieldCount();

        /// <summary>
        /// Gets the bulk import validator.
        /// </summary>
        /// <value>
        /// The bulk import validator.
        /// </value>
        protected IBulkImportValidator BulkImportValidator { get; private set; }

        /// <summary>
        /// Parses the data.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        protected abstract T ParseData(String[] fields);

        /// <summary>
        /// Validates the record.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns></returns>
        protected abstract void ValidateRecord(ParsedEntityContainer<T> record);

        /// <summary>
        /// Initiates the import.
        /// </summary>
        /// <param name="bulkImportId">The bulk import identifier.</param>
        public abstract void InitiateImport(Annotation annotation);

        protected T ConvertTo<T>(string columnName, string data)
        {
            if (typeof(T).IsAssignableFrom(typeof(bool)))
            {
                if (data.ToLowerInvariant() == "yes")
                {
                    return (T)(object)true;
                }
                if (data.ToLowerInvariant() == "no")
                {
                    return (T)(object)false;
                }
                throw new ArgumentException(string.Format("{0} is invalid", columnName));
            }

            try
            {
                return (T)Convert.ChangeType(data, typeof(T));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("{0} is invalid", columnName), ex);
            }

        }
    }
}
