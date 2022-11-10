using MaqsData.Components;
using MaqsData.ConstantClasses;
using MaqsData.Contexts;
using MaqsData.Data;
using MaqsData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
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
                    if (document.Gkey == Guid.Empty || document.Gkey == null)
                    { 
                        document.Gkey = Guid.NewGuid();

                        AddToTotal(total, document);
                        await AdjustInventoryBasedOnFormSubmission(Inventory, document);


                        await context.Documents.AddAsync(document);
                        await context.Totals.AddAsync(total);

                        context.SaveChanges();
                    }


                    else
                    {
                        context.Attach(document);
                        context.Entry(document).State = EntityState.Modified;
                        context.SaveChanges();
                    }
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
                    Inventory.EntryDate = DateTime.Now;

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

        public async Task<Inventory> GetLatestInventory()
        {
            Inventory latestInv = new();
            using (var context = _contextFactory.CreateDbContext())
            {
                if (context.Inventorys.Any())
                {
                    latestInv = context.Inventorys.OrderByDescending(x => x.Id).First();
                }

            }
            return latestInv;
        }


        public void AddToTotal(Total total, Document document)
        {
            using (var context = _contextFactory.CreateDbContext())
            {

                if (context.Totals.Any())
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
                else
                {
                    DateTime CurrentYear = DateTime.UtcNow;
                    string year = CurrentYear.Year.ToString();
                    total.YearOfTotals = year;
                    total.YearToDateExpenses = document.ExpensesForShow;
                    total.YearToDateGrossProfit = document.ShowGrossProfit;
                    total.YearToDateNetProfit = document.ShowNetProfit;
                }
            }
        }

        public async Task AdjustInventoryBasedOnFormSubmission(Inventory inv, Document doc)
        {

            Inventory LatestInventory = new();
            LatestInventory = await GetLatestInventory();
            LatestInventory.BraceletTotal -= doc.BraceletsSold;
            LatestInventory.RingTotal -= doc.RingsSold;
            LatestInventory.NecklaceTotal -= doc.NecklacesSold;
            LatestInventory.EarringTotal -= doc.EarringsSold;
            LatestInventory.HairClipTotal -= doc.HairClipsSold;
            LatestInventory.KeyChainTotal -= doc.KeyChainsSold;

            LatestInventory.NeckalaceTotalValue = LatestInventory.NecklaceTotal * JewelryValue.NecklaceValue;
            LatestInventory.RingTotalValue = LatestInventory.RingTotal * JewelryValue.RingValue;
            LatestInventory.BraceletTotalValue = LatestInventory.BraceletTotal * JewelryValue.BraceletValue;
            LatestInventory.EarringTotalValue = LatestInventory.EarringTotal * JewelryValue.EarringValue;
            LatestInventory.KeyChainTotalValue = LatestInventory.KeyChainTotal * JewelryValue.KeyChainValue;
            LatestInventory.HairClipTotalValue = LatestInventory.HairClipTotal * JewelryValue.HairClipValue;


            List<decimal?> TotalVal = new();
            TotalVal.Add(LatestInventory.NeckalaceTotalValue);
            TotalVal.Add(LatestInventory.RingTotalValue);
            TotalVal.Add(LatestInventory.BraceletTotalValue);
            TotalVal.Add(LatestInventory.EarringTotalValue);
            TotalVal.Add(LatestInventory.KeyChainTotalValue);
            TotalVal.Add(LatestInventory.HairClipTotalValue);


            var TotalValSum = TotalVal.Sum();


            LatestInventory.TotalInventoryValue = (decimal?)TotalValSum;

            try
            {

                using (var context = _contextFactory.CreateDbContext())
                {
                    if (context.Inventorys.Any())
                    {
                        context.Attach(LatestInventory);
                        context.Entry(LatestInventory).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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


        public async Task AdjustInventory(DocumentModel Dataset)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var LatestInventory = await GetLatestInventory();
                    if(LatestInventory != null)
                    {
                        LatestInventory.NecklaceTotal += Dataset.NecklacesSold;
                        LatestInventory.BraceletTotal += Dataset.BraceletsSold;
                        LatestInventory.EarringTotal += Dataset.EarringsSold;
                        LatestInventory.RingTotal += Dataset.RingsSold;
                        LatestInventory.HairClipTotal += Dataset.HairClipsSold;
                        LatestInventory.KeyChainTotal += Dataset.KeyChainsSold;

                        LatestInventory.NeckalaceTotalValue = LatestInventory.NecklaceTotal * JewelryValue.NecklaceValue;
                        LatestInventory.RingTotalValue = LatestInventory.RingTotal * JewelryValue.RingValue;
                        LatestInventory.BraceletTotalValue = LatestInventory.BraceletTotal * JewelryValue.BraceletValue;
                        LatestInventory.EarringTotalValue = LatestInventory.EarringTotal * JewelryValue.EarringValue;
                        LatestInventory.KeyChainTotalValue = LatestInventory.KeyChainTotal * JewelryValue.KeyChainValue;
                        LatestInventory.HairClipTotalValue = LatestInventory.HairClipTotal * JewelryValue.HairClipValue;

                        List<decimal?> TotalVal = new();
                        TotalVal.Add(LatestInventory.NeckalaceTotalValue);
                        TotalVal.Add(LatestInventory.RingTotalValue);
                        TotalVal.Add(LatestInventory.BraceletTotalValue);
                        TotalVal.Add(LatestInventory.EarringTotalValue);
                        TotalVal.Add(LatestInventory.KeyChainTotalValue);
                        TotalVal.Add(LatestInventory.HairClipTotalValue);


                        var TotalValSum = TotalVal.Sum();


                        LatestInventory.TotalInventoryValue = (decimal?)TotalValSum;
                    }
                    if (context.Inventorys.Any())
                    {
                        context.Attach(LatestInventory);
                        context.Entry(LatestInventory).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            
            

        }

        public async Task<Inventory> CalculateTotals(DocumentModel Dataset, Inventory LatestInventory)
        {
            LatestInventory = await GetLatestInventory();
            if (LatestInventory != null)
            {
                LatestInventory.NecklaceTotal += Dataset.NecklacesSold;
                LatestInventory.BraceletTotal += Dataset.BraceletsSold;
                LatestInventory.EarringTotal += Dataset.EarringsSold;
                LatestInventory.RingTotal += Dataset.RingsSold;
                LatestInventory.HairClipTotal += Dataset.HairClipsSold;
                LatestInventory.KeyChainTotal += Dataset.KeyChainsSold;

                LatestInventory.NeckalaceTotalValue = LatestInventory.NecklaceTotal * JewelryValue.NecklaceValue;
                LatestInventory.RingTotalValue = LatestInventory.RingTotal * JewelryValue.RingValue;
                LatestInventory.BraceletTotalValue = LatestInventory.BraceletTotal * JewelryValue.BraceletValue;
                LatestInventory.EarringTotalValue = LatestInventory.EarringTotal * JewelryValue.EarringValue;
                LatestInventory.KeyChainTotalValue = LatestInventory.KeyChainTotal * JewelryValue.KeyChainValue;
                LatestInventory.HairClipTotalValue = LatestInventory.HairClipTotal * JewelryValue.HairClipValue;

                List<decimal?> TotalVal = new();
                TotalVal.Add(LatestInventory.NeckalaceTotalValue);
                TotalVal.Add(LatestInventory.RingTotalValue);
                TotalVal.Add(LatestInventory.BraceletTotalValue);
                TotalVal.Add(LatestInventory.EarringTotalValue);
                TotalVal.Add(LatestInventory.KeyChainTotalValue);
                TotalVal.Add(LatestInventory.HairClipTotalValue);


                var TotalValSum = TotalVal.Sum();


                LatestInventory.TotalInventoryValue = (decimal?)TotalValSum;
            }
            return LatestInventory;
        }

    }
}
