using MediatR;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Settings.Queries.GetRawSettings;

public record GetRawSettingsQuery() : IRequest<SettingResponse?>;
