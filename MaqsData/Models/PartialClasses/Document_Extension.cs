using MaqsData.Data;
using static MudBlazor.CategoryTypes;

namespace MaqsData.Models
{
    public partial class Document
    {


        public Document()
        {

        }
        public Document(DocumentModel doc)
        {
            Id = doc.DocumentId;
            Gkey = doc.Gkey;
            ShowName = doc.ShowName;
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



    }




   
}
