using MaqsData.Data;


namespace MaqsData.Models
{
    public partial class InventoryEntry
    {
        public InventoryEntry()
        {

        }

        public InventoryEntry(DocumentModel doc)
        {
            Id = doc.InventoryId;
            EntryDate = doc.EntryDate;

            NecklaceTotal = doc.NecklaceTotal;
            BraceletTotal = doc.BraceletTotal;
            RingTotal = doc.RingTotal;
            EarringTotal = doc.EarringTotal;
            KeyChainTotal = doc.KeyChainTotal;
            HairClipTotal = doc.HairClipTotal;

        }

        public InventoryEntry(DocumentModel doc, string type)
        {
            Id = doc.InventoryId;
            EntryDate = doc.EntryDate;
            EntryType = type;
            NecklaceTotal = doc.NecklacesSold;
            BraceletTotal = doc.BraceletsSold;
            RingTotal = doc.RingsSold;
            EarringTotal = doc.EarringsSold;
            KeyChainTotal = doc.KeyChainsSold;
            HairClipTotal = doc.HairClipsSold;

        }
    }
}
