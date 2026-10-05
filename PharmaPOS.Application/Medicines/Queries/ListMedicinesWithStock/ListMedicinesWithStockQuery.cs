using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Medicines.Queries.ListMedicinesWithStock;

[AuthorizeCommand(Permissions = Permissions.Medicine.List)]
public record ListMedicinesWithStockQuery() : IRequest<List<MedicineResponse>>;
