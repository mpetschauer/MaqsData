


using MaqsData.Data;

namespace MaqsData.Modules
{
    public class CreateData
    {
        public CreateData()
        {

        }




        public DocumentModel GetDefaultForm()
        {
            DocumentModel doc = new()
            {
                EntryDate = DateTime.Now,
                DocumentId = 0,
            };

            return doc;
        }


        public List<string>GetFormDropdown()
        {
            List<string> formDropdown = new()
            
            {
                "Show Results Form",
                "Inventory Form",
                "Totals By Year Form"
            };

            return formDropdown;
        }

        public List<string> GetTableDropdown()
        {
            List<string> formDropdown = new()

            {
                "Show Results Table",
                "Inventory Table",
                "Totals By Year Table"
            };

            return formDropdown;
        }

    }
}
