using MaqsData.ConstantClasses;
using MaqsData.Contexts;
using MaqsData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MudBlazor;


namespace MaqsData.Modules
{
    public class Functions
    {

        private ISnackbar snackbar;
        private IDbContextFactory<DocumentContext> _contextFactory;
        private INavigation navigation;
        public Functions(IDbContextFactory<DocumentContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }



        public async Task<bool> SaveShowForm(DocumentModel doc)
        {
            try
            {

                Document document = new(doc);
                Total total = new(doc);
                Inventory Inventory = new(doc);
                using (var context = _contextFactory.CreateDbContext())
                {


                    AddToTotal(total, document);
           
                    await context.Documents.AddAsync(document);

                    await context.Totals.AddAsync(total);

                   
                    context.SaveChanges();
                  
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return true;
        }


        public async Task<bool>SaveInventoryForm(DocumentModel doc)
        {
                try
                {
                    CalculateInventoryValue(doc);

                    Inventory Inventory = new(doc);
                    Inventory.entryDate = DateTime.Now;

                    using (var context = _contextFactory.CreateDbContext())
                    {
                        await context.Inventorys.AddAsync(Inventory);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return true;
            
        }


        public void AddToTotal(Total total, Document document)
        {
            using (var context = _contextFactory.CreateDbContext())
            {

                if (context.Totals.Select(x => x.YearToDateNetProfit).Any())
                {
                    var YTDNetData = context.Totals.Select(x => x.YearToDateNetProfit);
                    decimal maxNet = (decimal)YTDNetData.Max();
                    total.YearToDateNetProfit = Decimal.Add(maxNet, document.ShowNetProfit);
                }
                else
                {
                    total.YearToDateNetProfit = 0;
                }

                if (context.Totals.Select(x => x.YearToDateGrossProfit).Any())
                {
                    var YTDGrossData = context.Totals.Select(x => x.YearToDateGrossProfit);
                    decimal maxGross = (decimal)YTDGrossData.Max();
                    total.YearToDateGrossProfit = Decimal.Add(maxGross, document.ShowGrossProfit);
                }
                else
                {
                    total.YearToDateGrossProfit = 0;
                }

                if (context.Totals.Select(x => x.YearToDateExpenses).Any())
                {
                    var YTDExpenseData = context.Totals.Select(x => x.YearToDateExpenses);
                    decimal maxExpense = (decimal)YTDExpenseData.Max();
                    total.YearToDateExpenses = Decimal.Add(maxExpense, document.ExpensesForShow);
                }
                else
                {
                    total.YearToDateExpenses = 0;
                }
            }
        }

        public void CalculateInventoryValue(DocumentModel doc)
        {
            JewelryValue jv = new();
            doc.NeckalaceTotalValue = doc.NecklaceTotal * JewelryValue.NecklaceValue;
            doc.RingTotalValue = doc.RingTotal * JewelryValue.RingValue;
            doc.BraceletTotalValue = doc.BraceletTotal * JewelryValue.BraceletValue;
            doc.EarringTotalValue = doc.EarringTotal * JewelryValue.EarringValue;
            doc.KeyChainTotalValue = doc.KeyChainTotal * JewelryValue.KeyChainValue;
            doc.HairClipTotalValue = doc.HairClipTotal * JewelryValue.HairClipValue;

            List<decimal?> TotalVal = new();
            TotalVal.Add(doc.NeckalaceTotalValue);
            TotalVal.Add(doc.RingTotalValue);
            TotalVal.Add(doc.BraceletTotalValue);
            TotalVal.Add(doc.EarringTotalValue);
            TotalVal.Add(doc.KeyChainTotalValue);
            TotalVal.Add(doc.HairClipTotalValue);


            var TotalValSum = TotalVal.Sum();


            doc.TotalInventoryValue = (decimal?)TotalValSum;


        }

    }
}
