using System.ComponentModel.DataAnnotations;

namespace HDLand.Contracts
{
    public record RegisterUserRequest(
        [Required] string Username,
        [Required] string Password,
        [Required] string Email);
}
