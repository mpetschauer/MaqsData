using MaqsData.DataTransferObjects;
using MaqsData.Models;




namespace MaqsData.Data
{
    public class DocumentModel
    {

        public DocumentModel()
        {

        }



        public DocumentModel(Document doc)
        {
            DocumentId = doc.Id;
            Gkey = doc.Gkey;
            ShowDate = doc.ShowDate;
            EntryDate = doc.EntryDate;
            NecklacesSold = doc.NecklacesSold;
            BraceletsSold = doc.BraceletsSold;
            EarringsSold = doc.EarringsSold;
            RingsSold = doc.RingsSold;
            KeyChainsSold = doc.KeyChainsSold;
            HairClipsSold = doc.HairClipsSold;
            ExpensesForShow = doc.ExpensesForShow;         
            ShowNetProfit = doc.ShowNetProfit;
            ShowGrossProfit = doc.ShowGrossProfit;
            ShowDetails = doc.ShowDetails;
            Summary = doc.Summary;

        }


        public DocumentModel(Total doc)
        {
            TotalsId = doc.Id;
            YearToDateExpenses = doc.YearToDateExpenses;
            YearToDateNetProfit = doc.YearToDateNetProfit;
            YearToDateGrossProfit = doc.YearToDateGrossProfit;
            YearOfTotals = doc.YearOfTotals;
        }


        public DocumentModel(Inventory doc)
        {
            InventoryId = doc.Id;
            NecklaceTotal = doc.NecklaceTotal;
            BraceletTotal = doc.BraceletTotal;
            RingTotal = doc.RingTotal;
            EarringTotal = doc.EarringTotal;
            KeyChainTotal = doc.KeyChainTotal;
            HairClipTotal = doc.HairClipTotal;
            NeckalaceTotalValue = doc.NeckalaceTotalValue;
            BraceletTotalValue = doc.BraceletTotalValue;
            RingTotalValue = doc.RingTotalValue;
            EarringTotalValue = doc.EarringTotalValue;
            KeyChainTotalValue = doc.KeyChainTotalValue;
            HairClipTotalValue = doc.HairClipTotalValue;
            TotalInventoryValue = doc.TotalInventoryValue;

        }

        public int DocumentId { get; set; }
        public int TotalsId { get; set; }
        public int InventoryId { get; set; }
        public Guid Gkey { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ShowDate { get; set; }
        public string? YearOfTotals { get; set; }
        public string? FormSelection { get; set; }

        public string? TableSelection { get; set; }
        
        public int NecklacesSold { get; set; }
        public int BraceletsSold { get; set; }
        public int EarringsSold { get; set; }
        public int RingsSold { get; set; }
        public int KeyChainsSold { get; set; }
        public int HairClipsSold { get; set; }
        public decimal ExpensesForShow { get; set; }
        public decimal? YearToDateExpenses { get; set; }
        public decimal ShowNetProfit { get; set; }
        public decimal? YearToDateNetProfit { get; set; }
        public decimal ShowGrossProfit { get; set; }
        public decimal? YearToDateGrossProfit { get; set; }
        public string? ShowDetails { get; set; }
        public string? Summary { get; set; }
        public int NecklaceTotal { get; set; }
        public int BraceletTotal { get; set; }
        public int RingTotal { get; set; }
        public int EarringTotal { get; set; }
        public int KeyChainTotal { get; set; }
        public int HairClipTotal { get; set; }

        public decimal? NeckalaceTotalValue { get; set; }
        public decimal? BraceletTotalValue { get; set; }
        public decimal? RingTotalValue { get; set; }
        public decimal? EarringTotalValue { get; set; }
        public decimal? KeyChainTotalValue { get; set; }
        public decimal? HairClipTotalValue { get; set; }
        public decimal? TotalInventoryValue { get; set; }

        public bool? NavFromTableToShowForm { get; set; }
        public bool? NavFromTableToInventoryForm { get; set; }
    }
}