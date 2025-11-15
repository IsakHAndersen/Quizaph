using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.UserModels
{
    public class CreateExternalUserDTO
    {
        public string ExternalProviderName { get; set; } = string.Empty;
        public string ExternalProviderId { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
