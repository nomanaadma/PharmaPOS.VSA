using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.SettingAggregate;

namespace PharmaPOS.Application.Settings.Commands.UpdateSettings;

public class UpdateSettingsCommandHandler(
	ISettingRepository settingRepo,
	IUnitOfWork unitOfWork) : IRequestHandler<UpdateSettingsCommand, ErrorOr<Updated>>
{
	public async Task<ErrorOr<Updated>> Handle(UpdateSettingsCommand command, CancellationToken ct)
	{
		var request = command.Request;
		var settings = await settingRepo.GetRawSettingsAsync(ct);
		var settingFields = new SettingFields(request.Name, request.LegalName, request.Mail, request.Phone);
		
		if (settings == null)
		{
			var settingsResult = Setting.Create(settingFields);
			if (settingsResult.IsError)
			{
				return settingsResult.Errors;
			}
			settings = settingsResult.Value;
			await settingRepo.AddAsync(settings, ct);
		}
		else
		{
			var updateResult = settings.Update(settingFields);
			if (updateResult.IsError)
			{
				return updateResult.Errors;
			}
		}

		settings.UpdateImages(request.Logo, request.LogoIcon, request.LgBackground, request.Favicon);
		settings.UpdateAddress(new Address(request.AddressLine1, request.AddressLine2, request.City, request.Country, request.Postal));

		await unitOfWork.SaveChangesAsync(ct);
		return Result.Updated;
	}
}
