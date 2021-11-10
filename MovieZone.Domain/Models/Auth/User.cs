using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieZone.Domain.Models.Auth
{
    public class User: IdentityUser<int>
    {
    }
}
