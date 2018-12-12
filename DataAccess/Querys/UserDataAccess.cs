using System.Collections.Generic;
using System.Linq;
using DataAccess.DtoFactory;
using DataAccess.Dto;
using System;

namespace DataAccess.Querys
{
    public class UserDataAccess
    {
        private readonly UserDtoFactory userDtoFactory;
        public UserDataAccess()
        {
            userDtoFactory = new UserDtoFactory();
        }

        public IList<UserDto> GetAllUsers()
        {
            using (var db = new bd_usersEntities())
            {
                var users =  db.users.Select(x => x).ToList();
                return userDtoFactory.GetUsersDto(users);
            }                
        }

        public string Insert(UserDto userDto)
        {
            var user = userDtoFactory.GetUser(userDto);
            try
            {
                using (var db = new bd_usersEntities())
                {
                    db.users.Add(user);
                    db.SaveChanges();
                }
                return "Succesfully inserted user.";
            }
            catch (Exception e)
            {
                return "User could not be inserted. " + e.Message;
            }                    
        }

        public string Update(UserDto userDto)
        {
            
            try
            {
                using (var db = new bd_usersEntities())
                {
                    var user = db.users.SingleOrDefault(x => x.id == userDto.id);
                    user = userDtoFactory.GetUserByDto(userDto, user);
                    db.SaveChanges();
                }
                return "Succesfully updated user.";
            }
            catch (Exception e)
            {
                return "User could not be updated. " + e.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                using (var db = new bd_usersEntities())
                {
                    var user = db.users.FirstOrDefault(x => x.id == id);
                    db.users.Remove(user);
                    db.SaveChanges();
                }
                return "Succesfully deleted user.";
            }
            catch (Exception e)
            {
                return "User could not be deleted. " + e.Message;
            }
        }
    }
}
