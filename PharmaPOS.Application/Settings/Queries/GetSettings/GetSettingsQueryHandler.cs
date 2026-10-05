using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.SettingAggregate;

namespace PharmaPOS.Application.Settings.Queries.GetSettings;

public class GetSettingsQueryHandler(
	ISettingRepository settingRepo,
	IFilePathProvider pathProvider) : IRequestHandler<GetSettingsQuery, SettingResponse>
{
	public async Task<SettingResponse> Handle(GetSettingsQuery query, CancellationToken ct)
	{
		var settings = await settingRepo.GetSettingsAsync(ct);
	
		// 1. If records are not found, create a new Setting and Address object with default values
		if (settings == null)
		{
			var settingFields = new SettingFields("PharmaPOS Store", "PharmaPOS Store LLC", "store@pharmapos.com", "1234567890");
			var settingsResult = Setting.Create(settingFields);
			if (settingsResult.IsError) throw new Exception("Failed to initialize default settings");
			settings = settingsResult.Value;
			settings.UpdateAddress(Address.Empty);
		}
		
		var logo = "/images/logo.png";
		if (!string.IsNullOrEmpty(settings.Logo) && File.Exists(pathProvider.GetUploadsFilePath(settings.Logo)))
		{
			logo = $"/uploads/{settings.Logo}";
		}
		
		var logoIcon = "/images/icon.png";
		if (!string.IsNullOrEmpty(settings.LogoIcon) && File.Exists(pathProvider.GetUploadsFilePath(settings.LogoIcon)))
		{
			logoIcon = $"/uploads/{settings.LogoIcon}";
		}
		
		var favicon = "/images/favicon.png";
		if (!string.IsNullOrEmpty(settings.Favicon) && File.Exists(pathProvider.GetUploadsFilePath(settings.Favicon)))
		{
			favicon = $"/uploads/{settings.Favicon}";
		}
		
		var lgBackground = "/images/login-bg.jpg";
		if (!string.IsNullOrEmpty(settings.LgBackground) && File.Exists(pathProvider.GetUploadsFilePath(settings.LgBackground)))
		{
			lgBackground = $"/uploads/{settings.LgBackground}";
		}
		
		settings.UpdateImages(logo, logoIcon, lgBackground, favicon);

		var settingResponse = settings.Adapt<SettingResponse>(); 
		
		return settingResponse;
	}
}
