using MarketingRESTAPI.Domain.Enums;

namespace MarketingRESTAPI.Shared.Helpers;

static class DataNormalizer
{
    public static decimal NormalizeBudget(string budget)
    {
        budget = budget.Replace("€", "")
                       .Replace("$", "")
                       .Replace(",", "");
        budget = budget.Trim().ToLower();
        if (budget == null || budget== string.Empty || budget == "unknown")
            return 0 ;

        if (decimal.TryParse(budget, out var normalizedBudget))
            return normalizedBudget;

        return 0;
    }

    public static bool NormalizeIsActive(string isActive)
    {
        if (string.IsNullOrWhiteSpace(isActive))
            return false;

        isActive = isActive.Trim().ToLower();

        return isActive switch
        {
            "true" => true,
            "1" => true,
            "yes" => true,
            "y" => true,
            "si" => true,
            "on" => true,

            "false" => false,
            "0" => false,
            "no" => false,
            "n" => false,
            "off" => false,

            _ => false
        };
    }

    public static Language NormalizeLanguage(string language)
    {
        if (string.IsNullOrWhiteSpace(language))
            return Language.EN;                     // default

        language = language.Trim().ToLower();

        return language switch
        {
            "es" or "esp" or "se" => Language.ES,
            "en" or "gb" or "uk" or "us" or "ne" => Language.EN,
            "ar" or "ra" => Language.AR,

            _ => Language.EN
        };
    }
}