using PharmaPOS.Contracts.Responses;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Mappers;

public static class SettingMapper
{
    public static SystemInfoViewModel MapToSystemInfo(SettingResponse? rawSetting, SettingResponse siteInfo)
    {
        return new SystemInfoViewModel
        {
            Logo = rawSetting?.Logo,
            LogoIcon = rawSetting?.LogoIcon,
            LgBackground = rawSetting?.LgBackground,
            Favicon = rawSetting?.Favicon,
            Name = siteInfo.Name,
            LegalName = siteInfo.LegalName,
            Mail = siteInfo.Mail,
            Phone = siteInfo.Phone,
            AddressLine1 = siteInfo.Address?.Line1,
            AddressLine2 = siteInfo.Address?.Line2,
            City = siteInfo.Address?.City,
            Country = siteInfo.Address?.Country,
            Postal = siteInfo.Address?.Postal
        };
    }
    
}
