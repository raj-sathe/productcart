using productcart.Context;
using productcart.Dto;
using productcart.Entity;
using productcart.IDal;

namespace productcart.Dal
{
    public class UserDal(productcontext _context) : IUserDal
    {
        public async Task CreateUser(userDto userDto)
        {
            var user = new user {
                UserName = userDto.UserName,
                MobileNumber = userDto.MobileNumber,
            };

            _context.User.Add(user);
            _context.SaveChanges();
           
        }

        public async Task DeleteUser(int userId)
        {
            var user =  _context.User.Find(userId);
            if (user == null) {
                throw new Exception("user not found for Delete");
            }
            _context.User.Remove(user);
            _context.SaveChanges();
           
        }

        public async Task<userDto> FetchUserById(int userId)
        {
            var user = _context.User.Find(userId);

            if (user == null) {
                throw new Exception("user not found");
            }

            return new userDto
            {
                Id = user.Id,
                UserName = user.UserName,
                MobileNumber = user.MobileNumber,
            };
        }


        public async Task<bool> IsUserExist(int UserId)
        {
           var isExist =  _context.User.Any(w=> w.Id == UserId);
            return isExist;
        }

        public async Task UpdateUser(userDto userDto)
        {

            var user = _context.User.Find(userDto.Id);

            if (user == null)
            {
                throw new Exception("user not found for Delete");
            }

            user.UserName = userDto.UserName;
            user.MobileNumber = userDto.MobileNumber;

            _context.User.Add(user);
            _context.SaveChanges();
            
        }
    }
}
