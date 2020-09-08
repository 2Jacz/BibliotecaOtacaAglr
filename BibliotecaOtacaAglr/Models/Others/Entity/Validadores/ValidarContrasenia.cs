using BibliotecaOtacaAglr.Models.Usuarios.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaOtacaAglr.Models.Others.Entity.Validadores
{
    /// <summary>
    /// Valida que la contrasenia cumpla com siertos criterios
    /// *No sea igual al nombre de usuario
    /// *No contenga palabras prohibidas
    /// *No contenga menos de 6 caracteres
    /// </summary>
    public class ValidarContrasenia : PasswordValidator<Usuario>
    {
        private readonly string[] blackList = new string[] {
            "000000",
            "111111",
            "222222",
            "333333",
            "444444",
            "555555",
            "666666",
            "777777",
            "888888",
            "999999",
            "123456",
            "1234567",
            "12345678",
            "123456789",
            "1234567890",
            "123abc",
            "administrador",
            "contrasenia",
            "password",
            "asdfgh",
            "asdfghj",
            "asdfghjk",
            "asdfghjkl",
            "asdfghjkl;",
            "asdfghjkl;'",
            "qwerty",
            "qwertyu",
            "qwertyui",
            "qwertyuio",
            "qwertyuiop",
            "qwertyuiop[",
            "qwertyuiop[]",
            "zxcvbn",
            "zxcvbnm",
            "zxcvbnm,",
            "zxcvbnm,.",
            ""
        };

        public override async Task<IdentityResult> ValidateAsync(UserManager<Usuario> manager, Usuario user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Equals(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Description = "La contrasenia no puede ser igual al nombre de usuario."
                });
            }

            if (blackList.Any(pass => pass == password))
            {
                errors.Add(new IdentityError
                {
                    Description = "No es posible utilizar esa contrsenia."
                });
            }

            if (password.Trim().Length < 6)
            {
                errors.Add(new IdentityError
                {
                    Description = "La contrasenia no contiene los 6 caracteres minimos."
                });
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
