using System.ComponentModel;

namespace ScreeningApp.Models
{
    public enum CurrencyType
    {
        [Description("U.S. Dollars")]
        USD = 1,
        [Description("Belarusian Rubles")]
        BYR = 2,
        [Description("Kenyan Shillings")]
        KES = 3,
        [Description("Brazilian Real")]
        BRL = 4,
        [Description("Chinese Yuan")]
        CNY = 5,
    }
}