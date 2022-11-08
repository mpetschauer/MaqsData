using System.ComponentModel.DataAnnotations;

namespace MaqsData.Models
{
    public partial class Total
    {


        [Key]
        public int Id { get; set; }
        public string? YearOfTotals { get; set; }
        public decimal? YearToDateExpenses { get; set; }
        public decimal? YearToDateNetProfit { get; set; }
        public decimal? YearToDateGrossProfit { get; set; }

        public string? Notes { get; set; }
        public string? YearSummary { get; set; }
    }
}
