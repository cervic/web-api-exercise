using DataAccess.Dto;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccess.DtoFactory
{
    public class UserDtoFactory
    {
        public UserDto GetUserDto(user user)
        {
            return new UserDto
            {
                id = user.id,
                name = user.name,
                lastName = user.lastName,
                email = user.email,
                password = user.password,
            };
        }

        public List<UserDto> GetUsersDto(List<user> users)
        {
            return users.Select(x => GetUserDto(x)).ToList();
        }

        public user GetUser(UserDto userDto)
        {
            return new user()
            {
                id = userDto.id,
                name = userDto.name,
                lastName = userDto.lastName,
                email = userDto.email,
                password = userDto.password
            };
        }

        public user GetUserByDto(UserDto userDto, user user)
        {
            user.name = userDto.name;
            user.lastName = userDto.lastName;
            user.password = userDto.password;
            user.email = userDto.email;

            return user;
        }
    }
}
