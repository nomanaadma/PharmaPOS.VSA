using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Medicines.Queries.SearchMedicines;

[AuthorizeCommand(Permissions = Permissions.Medicine.List)]
public record SearchMedicinesQuery(string Term) : IRequest<object>;
