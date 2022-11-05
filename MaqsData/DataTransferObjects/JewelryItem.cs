namespace MaqsData.DataTransferObjects
{
    public class JewelryItem
    {


        public JewelryItem()
        {

        }


        public int Id { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool IsItemNew { get; set; } = false;

        public string? ItemType { get; set; }
        public decimal? ItemValue { get; set; }
        public decimal? ItemSalePrice { get; set; }
        public decimal? CostToCreate { get; set; }
        public int? CustomInventoryCount { get; set; }
    }
}
