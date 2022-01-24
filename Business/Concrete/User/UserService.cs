using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetByMail(string email)
        {
           return _userRepository.Get(x=> x.Email == email);
        }
        public void Add(User user)
        {
            _userRepository.Add(user);
        }
    }
}
