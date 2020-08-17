using System.Collections.Generic;

namespace Chase.UI.Models
{
    public class AppUserLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public  bool RememberMe { get; set; }
    }
}