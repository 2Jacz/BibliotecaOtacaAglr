using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse
{
    public class LoginUserToken
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string ReturnURL { get; set; }
    }
}
