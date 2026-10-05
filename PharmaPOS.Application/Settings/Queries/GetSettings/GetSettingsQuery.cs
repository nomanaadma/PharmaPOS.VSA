using MediatR;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Settings.Queries.GetSettings;

public record GetSettingsQuery() : IRequest<SettingResponse>;
