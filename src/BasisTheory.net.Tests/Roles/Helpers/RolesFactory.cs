using System.Collections.Generic;
using BasisTheory.net.Roles.Entities;

namespace BasisTheory.net.Tests.Roles.Helpers;

public class RolesFactory
{
    public static IEnumerable<Role> Roles()
    {
        return new[]
        {
            new Role { Name = "admin" },
            new Role { Name = "read-only" }
        };
    }
}