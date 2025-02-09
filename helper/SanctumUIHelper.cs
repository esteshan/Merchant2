using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExileCore2.PoEMemory;

namespace Merchant2.helper
{
    public static class SanctumUiHelper
    {
        public static void LocateButtons(Element sanctumRewardWindow, 
                                         out Element downArrow, 
                                         out Element upArrow, 
                                         out Element purchaseButton, 
                                         out Element closeButton)
        {
            downArrow = sanctumRewardWindow.Children.ElementAtOrDefault(0)?
                                                 .Children.ElementAtOrDefault(1)?
                                                 .Children.ElementAtOrDefault(0)?
                                                 .Children.ElementAtOrDefault(2)?
                                                 .Children.ElementAtOrDefault(1);

            upArrow = sanctumRewardWindow.Children.ElementAtOrDefault(0)?
                                               .Children.ElementAtOrDefault(1)?
                                               .Children.ElementAtOrDefault(0)?
                                               .Children.ElementAtOrDefault(2)?
                                               .Children.ElementAtOrDefault(0);

            purchaseButton = sanctumRewardWindow.Children.ElementAtOrDefault(0)?
                                                       .Children.ElementAtOrDefault(2);

            closeButton = sanctumRewardWindow.Children.ElementAtOrDefault(3);
        }

        public static void CurrencyText(Element sanctumRewardWindow,
            out Element currencyText)
        {
            currencyText = sanctumRewardWindow.Children.ElementAtOrDefault(100)?
                .Children.ElementAtOrDefault(0)?
                .Children.ElementAtOrDefault(0)?
                .Children.ElementAtOrDefault(0)?
                .Children.ElementAtOrDefault(1);
        }

        public static async Task<List<Element>> BoonWindow(Element sanctumRewardWindow)
        {
            return await Task.Run(() =>
            {
                var boons = new List<Element>();
                var boonContainer = sanctumRewardWindow.Children.ElementAtOrDefault(100)?
                    .Children.ElementAtOrDefault(0)?
                    .Children.ElementAtOrDefault(1)?
                    .Children.ElementAtOrDefault(0)?
                    .Children.ElementAtOrDefault(1);

                if (boonContainer != null)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var boonText = boonContainer.Children.ElementAtOrDefault(i)?
                            .Children.ElementAtOrDefault(1)?
                            .Children.ElementAtOrDefault(0)?
                            .Children.ElementAtOrDefault(0);
                        if (boonText != null)
                            boons.Add(boonText);
                    }
                }
                return boons;
            });
        }
        
    }
}
