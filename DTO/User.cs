using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User //DTO para moldear ventana de login
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
