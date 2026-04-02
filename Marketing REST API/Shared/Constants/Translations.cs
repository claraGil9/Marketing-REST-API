using MarketingRESTAPI.Domain.Enums;

namespace MarketingRESTAPI.Shared.Constants;

public static class Translations
{
    public static string GetGreeting(Language language) => language switch
    {
        Language.ES => "Hola",
        Language.EN => "Hello",
        Language.AR => "مرحبا",
        _ => "Hello"
    };

    public static string GetEmailSubject(Language lang, string companyName) => lang switch
    {
        Language.ES => $"Propuesta para {companyName}",
        Language.EN => $"Proposal for {companyName}",
        Language.AR => $"عرض لـ {companyName}",
        _ => $"Proposal for {companyName}"
    };

    public static string GetEmailIntro(Language lang, string companyName) => lang switch
    {
        Language.ES => $"Tenemos una propuesta especial para su empresa <strong>{companyName}</strong>.",
        Language.EN => $"We have a special proposal for your company <strong>{companyName}</strong>.",
        Language.AR => $"لدينا عرض خاص لشركتكم <strong>{companyName}</strong>.",
        _ => $"We have a special proposal for your company <strong>{companyName}</strong>."
    };

    public static string GetSectorLabel(Language lang) => lang switch
    {
        Language.ES => "Sector",
        Language.EN => "Sector",
        Language.AR => "القطاع",
        _ => "Sector"
    };

    public static string GetContactLabel(Language lang) => lang switch
    {
        Language.ES => "Contacto",
        Language.EN => "Contact",
        Language.AR => "جهة الاتصال",
        _ => "Contact"
    };

    public static string GetEmailtLabel(Language lang) => lang switch
    {
        Language.ES => "Email",
        Language.EN => "Email",
        Language.AR => "البريد الإلكتروني",
        _ => "Email"
    };

    public static string GetBudgetLabel(Language lang) => lang switch
    {
        Language.ES => "Presupuesto",
        Language.EN => "Budget",
        Language.AR => "الميزانية",
        _ => "Budget"
    };
}