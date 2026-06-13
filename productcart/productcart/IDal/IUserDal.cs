

using productcart.Dto;

namespace productcart.IDal
{
    public interface IUserDal
    {
        public Task CreateUser(userDto userDto);
        public Task UpdateUser(userDto userDto);
        public Task DeleteUser(int userId);
        public Task<userDto> FetchUserById(int userId);

        public Task<bool> IsUserExist(int UserId);

    }
}
