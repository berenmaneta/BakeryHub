using BakeryHub.Contracts.Users;
using BakeryHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryHub.Application.UseCases
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> ExecuteAsync(GetUserByIdRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                throw new KeyNotFoundException($"Usuário com ID '{request.Id}' não foi encontrado.");

            return new UserResponse(user.Id, user.Name, user.Email, user.Phone, user.Role);
        }
    }
}
