using MaqsData.Data;
using MaqsData.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace MaqsData.Models
{
    public partial class Document
    {



        [Key]
        public int Id { get; set; }
        public Guid Gkey { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ShowDate { get; set; }
        public int NecklacesSold{ get; set; }
        public int BraceletsSold { get; set; }
        public int EarringsSold { get; set; }
        public int RingsSold { get; set; }
        public int KeyChainsSold { get; set; }
        public int HairClipsSold { get; set; }
        public decimal ExpensesForShow { get; set; }
        public decimal ShowNetProfit { get; set; }
        public decimal ShowGrossProfit { get; set; }
        public string ShowDetails { get; set; }
        public string? Summary { get; set; }

    }



}
