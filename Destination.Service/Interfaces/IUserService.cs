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
    public UserViewModel Update(int id, UserCreationModel userViewModel);
    public bool Delete(int id);
    public UserViewModel Get(int id);
    public List<UserViewModel> GetAll();
}
