using System.Drawing;
using ExileCore2;
using ExileCore2.PoEMemory;
using ExileCore2.PoEMemory.MemoryObjects;
using Merchant2.helper;
using Vector2 = System.Numerics.Vector2;

namespace Merchant2;

public class Merchant2 : BaseSettingsPlugin<Merchant2Settings>
{
    private int _currencyAmount = 0; // Stores extracted currency
    
    public override bool Initialise()
    {
       
        return true;
    }
    
    public override void Tick()
    {
        if (!Settings.Enable.Value) return;

        var sanctumWindow = GetSanctumUI();
        if (sanctumWindow == null || !sanctumWindow.IsVisible) return;

        // ✅ Use the helper function
        SanctumUiHelper.CurrencyText(sanctumWindow, out var currencyElement);

        if (currencyElement != null && !string.IsNullOrEmpty(currencyElement.Text))
        {
            string currencyText = currencyElement.Text.Replace(",", "").Trim();
            _currencyAmount = int.TryParse(currencyText, out int parsedCurrency) ? parsedCurrency : 0;
        }
        else
        {
            _currencyAmount = 0; // Default if no value found
        }
    }

    public override void Render()
    {
        if (!Settings.Enable.Value) return;

        int yOffset = 180; // ✅ Position of text on screen
        Graphics.DrawText($"Currency: {_currencyAmount}", new Vector2(100, yOffset), Color.Cyan);
    }

    private Element GetSanctumUI()
    {
        return GameController.IngameState.IngameUi?.SanctumRewardWindow;
    }
}