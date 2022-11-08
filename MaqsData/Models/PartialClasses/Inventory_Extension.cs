using MaqsData.Data;

namespace MaqsData.Models
{
    public partial class Inventory
    {
        public Inventory()
        {

        }

        public Inventory(DocumentModel doc)
        {
            Id = doc.InventoryId;
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
    }
}
