using System.ComponentModel.DataAnnotations;

namespace MaqsData.Models
{
    public partial class Inventory
    {



        [Key]
        public int Id { get; set; }
        public DateTime? entryDate { get; set; }
        public int NecklaceTotal { get; set; }
        public int BraceletTotal { get; set; }
        public int RingTotal { get; set; }
        public int EarringTotal { get; set; }
        public int KeyChainTotal { get; set; }
        public int HairClipTotal{ get; set; }

        public decimal? NeckalaceTotalValue { get; set; }
        public decimal? BraceletTotalValue { get; set; }
        public decimal? RingTotalValue { get; set; }
        public decimal? EarringTotalvalue { get; set;}
        public decimal? KeyChainTotalvalue { get; set; }
        public decimal? HairClipTotalValue { get; set; }
        public decimal? TotalInventoryValue { get; set; }



    }
}
