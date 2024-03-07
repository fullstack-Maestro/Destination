using Destination.DataAccess.Contexts;
using Destination.Domain.Entities;
using Destination.Service.DTOs.Users;
using Destination.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destination.Service.Services;

public class UserService : IUserService
{
    private readonly AppDbContext appDbContext;
    public UserService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public UserViewModel Create(UserCreationModel userCreation)
    {
        var user = userCreation.MapTo<User>();
        appDbContext.Users.Add(user);
        appDbContext.SaveChanges();
        return user.MapTo<UserViewModel>();
    }

    public bool Delete(int id)
    {
       var user= appDbContext.Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
        {
            throw new Exception("User is not found");
        }
       var res= appDbContext.Users.Remove(user);
       appDbContext.SaveChanges();
       return true;
    }

    public UserViewModel Get(int id)
    {
        var user = appDbContext.Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
        {
            throw new Exception("User is not found");
        }
        return user.MapTo<UserViewModel>();
    }

    public List<UserViewModel> GetAll()
    {
        var list= appDbContext.Users.ToList();
        var res = list.Select(x => x.MapTo<UserViewModel>());
        return res.ToList();
    }

    public UserViewModel Update(int id, UserCreationModel userViewModel)
    {
        var user = appDbContext.Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
        {
            throw new Exception("User is not found");
        }
        user.FirstName= userViewModel.FirstName;
        user.LastName= userViewModel.LastName;
        user.Email= userViewModel.Email;
        user.Password= userViewModel.Password;
        user.UpdatedAt= DateTime.UtcNow;
        appDbContext.SaveChanges();
        return user.MapTo<UserViewModel>();
    }
}
