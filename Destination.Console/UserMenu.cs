using Destination.DataAccess.Contexts;
using Destination.Service.DTOs.Users;
using Destination.Service.Services;
using Spectre.Console;
using System.Drawing;

namespace Destination.myConsole
{
    public class UserMenu()
    {
           AppDbContext appDbContext = new AppDbContext();
           UserService userService = new UserService(appDbContext);
        long? ThisUser;
        public void Registration()
        {
            bool cycle = true;
            while (cycle)
            {
                AnsiConsole.Clear();
                Console.Clear();
                AnsiConsole.Write(
                new FigletText("User Registration Menu")
                .Centered()
                .Color(Spectre.Console.Color.DeepSkyBlue4_1));
                var choice = AnsiConsole.Prompt(
                 new SelectionPrompt<string>()
                 .Title("[springgreen3_1 rapidblink]Select your choice[/]")
                .PageSize(10)
               .MoreChoicesText("[grey](Move up and down to view any choices)[/]")
               .AddChoices(new[] { "Sign Up", "Log In", "Exit" }));
                AnsiConsole.Clear();
                Console.Clear();
                switch (choice)
                {
                    case "Sign Up":
                        UserSignUpMenu();
                        break;
                    case "Log In":
                        UserLogInMenu();
                        break;
                    case "Exit":
                        cycle = false;
                        break;
                }
            }
        }
        public void UserSignUpMenu()
        {
            AnsiConsole.Write(
                new FigletText("Sign Up Menu")
                .Centered()
                .Color(Spectre.Console.Color.DeepSkyBlue4_1));
            var firstName = AnsiConsole.Ask<string>("[gold3]Enter user first name: [/]");
            var lastName = AnsiConsole.Ask<string>("[gold3]Enter user last name: [/]");
            string email = GetValidEmail();
            var password = AnsiConsole.Prompt(
                           new TextPrompt<string>("[gold3]Enter password: [/]")
                           .PromptStyle("deeppink3")
                           .Secret());
            var newUser = new UserCreationModel
            {
                Email = email,
                Password = password,
                LastName = lastName,
                FirstName = firstName
            };
            try
            {
                var forthisUserId = userService.Create(newUser);
                ThisUser = forthisUserId.Id;
                AnsiConsole.MarkupLine("[green]Successfully added...[/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
                Show();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
                Console.WriteLine();
                Console.WriteLine();
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
            }
        }
        public void UserLogInMenu()
        {
            AnsiConsole.Write(
                new FigletText("Log In Menu")
                .Centered()
                .Color(Spectre.Console.Color.DeepSkyBlue4_1));
            var userEmail = GetValidEmail();
            var userPassword = AnsiConsole.Prompt(
                           new TextPrompt<string>("[gold3]Enter password: [/]")
                           .PromptStyle("deeppink3")
                           .Secret());

            try
            {
                var forthisUserId = userService.LogIn(userEmail, userPassword);
                AnsiConsole.Markup("[green]Hello![/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                ThisUser = forthisUserId.Id;
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
                Show();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
            }
        }
        public void Show()
        {
            bool cycle = true;
            while (cycle)
            {
                AnsiConsole.Clear();
                Console.Clear();
                AnsiConsole.Write(
                new FigletText("User Menu")
                .Centered()
                .Color(Spectre.Console.Color.DeepSkyBlue4_1));
                var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[springgreen3_1 rapidblink]Select your choice[/]")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to view any choices)[/]")
        .AddChoices(new[] { "Update", "Delete", "View", "Exit" }));
                AnsiConsole.Clear();
                Console.Clear();
                Console.Clear();
                switch (choice)
                {
                    case "Update":
                        UserUpdateMenu();
                        break;
                    case "Delete":
                        UserDeleteMenu();
                        break;
                    case "View":
                        UserViewMenu();
                        break;
                    case "Exit":
                        cycle = false;
                        break;
                }
            }
        }
        public void UserUpdateMenu()
        {
            AnsiConsole.Write(
                new FigletText("User Update Menu")
                .Centered()
                .Color(Spectre.Console.Color.DeepSkyBlue4_1));
            var firstName = AnsiConsole.Ask<string>("[gold3]Enter user first name: [/]");
            var lastName = AnsiConsole.Ask<string>("[gold3]Enter user last name: [/]");
            var password = AnsiConsole.Prompt(
                           new TextPrompt<string>("[gold3]Enter password: [/]")
                           .PromptStyle("deeppink3")
                           .Secret());
            string email = GetValidEmail();
            var user = new UserUpdateModel()
            {
                Email = email,
                Password = password,
                LastName = lastName,
                FirstName = firstName,
            };
            try
            {
                userService.Update(ThisUser.Value, user);
                AnsiConsole.MarkupLine("[green]Successfully updated...[/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
            }
            catch (Exception ex)
            {

                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
            }
        }
        public void UserDeleteMenu()
        {
            AnsiConsole.Write(
                 new FigletText("User Delete Menu")
                 .Centered()
                 .Color(Spectre.Console.Color.DeepSkyBlue4_1));
            var userPassword = AnsiConsole.Prompt(
                           new TextPrompt<string>("[gold3]Enter password: [/]")
                           .PromptStyle("deeppink3")
                           .Secret());

            try
            {
                userService.Delete(ThisUser.Value, userPassword);
                AnsiConsole.MarkupLine("[green]Successfully deleted...[/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
                Registration();
            }
            catch (Exception ex)
            {

                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
            }
        }
        public void UserViewMenu()
        {
            AnsiConsole.Write(
                 new FigletText("User View Profile Menu")
                 .Centered()
                 .Color(Spectre.Console.Color.DeepSkyBlue4_1));
            try
            {
                Display(userService.Get(ThisUser.Value));
                Console.WriteLine();
                Console.WriteLine();
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]\n");
                AnsiConsole.MarkupLine("[grey58]Press any key to continue...[/]");
                Console.ReadKey();
                AnsiConsole.Clear();
                Console.Clear();
            }
        }
        static string GetValidEmail()
        {
            string email;
            do
            {
                email = AnsiConsole.Ask<string>("[gold3]Email address: [/]");

                if (!IsValidEmail(email))
                {
                    AnsiConsole.MarkupLine("[red]Invalid email address. Please enter the correct address![/]");
                }
            }
            while (!IsValidEmail(email));

            return email;
        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void Display(UserViewModel user)
        {
            AnsiConsole.MarkupLine($"User First Name: {user.FirstName}");
            AnsiConsole.MarkupLine($"User Last Name: {user.LastName}\n");
            AnsiConsole.MarkupLine($"User Email: {user.Email}\n");
        }
    }
}
