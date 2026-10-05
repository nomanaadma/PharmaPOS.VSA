using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Mappers;

public static class RoleMapper
{
	
    public static RoleFormViewModel MapToRoleForm(IdentityRole role, string description, List<string> selectedPermissions)
    {
        return new RoleFormViewModel
        {
            Id = role.Id,
            Name = role.Name ?? "",
            Description = description,
            SelectedPermissions = selectedPermissions,
            PermissionsGroup = Permissions.GetPermissionsTemplate()
        };
    }
}
