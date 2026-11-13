using Asp.Versioning;
using BakeryHub.Application.UseCases.Users;
using BakeryHub.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace BakeryHub.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IRegisterUserUseCase _registerUserUseCase;

    public UsersController(IRegisterUserUseCase registerUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        try
        {
            var response = await _registerUserUseCase.ExecuteAsync(request);
            return CreatedAtAction(nameof(Register), new { version = "1.0", id = response.Id }, response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}