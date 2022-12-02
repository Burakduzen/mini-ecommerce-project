using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class PasswordChangeFailedExcepiton : Exception
    {
        public PasswordChangeFailedExcepiton() : base("Şifre güncellenirken hata!")
        {
        }

        public PasswordChangeFailedExcepiton(string? message) : base(message)
        {
        }

        public PasswordChangeFailedExcepiton(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
