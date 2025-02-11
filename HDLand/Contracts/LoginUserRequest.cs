using System.ComponentModel.DataAnnotations;

namespace HDLand.Contracts
{
    public record LoginUserRequest(
   [Required] string Email,
   [Required] string Password);
}
