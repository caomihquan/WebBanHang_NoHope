using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang_NoHope.Areas.Admin.Models
{
    public class LoginModel
    {
      //  [Required(ErrorMessage = "Nhập tài khoản")]
        public string UserName { set; get; }

       // [Required(ErrorMessage = "Nhập Mật khẩu")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}