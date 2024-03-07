using Destination.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destination.Service.Interfaces;

public interface IUserService
{
    public UserViewModel Create(UserCreationModel userCreation);
    public UserViewModel Update(long id, UserUpdateModel userViewModel);
    public bool Delete(long id, string password);
    public UserViewModel Get(long id);
    public List<UserViewModel> GetAll();
}
