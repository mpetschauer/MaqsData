using MaqsData.Data;

namespace MaqsData.Models
{
    public partial class Total
    {
        public Total()
        {

        }

            public Total(DocumentModel doc)
            {
                Id = doc.TotalsId;
                YearOfTotals = doc.YearOfTotals;
                YearToDateExpenses = doc.YearToDateExpenses;
                YearToDateNetProfit = doc.YearToDateNetProfit;
                YearToDateGrossProfit = doc.YearToDateGrossProfit;

            }    }
}
