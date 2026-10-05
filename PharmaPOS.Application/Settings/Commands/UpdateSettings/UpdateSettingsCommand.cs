using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Settings.Commands.UpdateSettings;

public record UpdateSettingsCommand(SettingRequest Request) : IRequest<ErrorOr<Updated>>;
