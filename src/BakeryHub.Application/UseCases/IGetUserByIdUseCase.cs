using BakeryHub.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryHub.Application.UseCases
{
    public interface IGetUserByIdUseCase
    {
        Task<UserResponse> ExecuteAsync(GetUserByIdRequest request);
    }
}
