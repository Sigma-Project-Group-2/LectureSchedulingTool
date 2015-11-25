using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LectureSchedulingTool.Models
{
    public class SecretCodeAttribute : ValidationAttribute
    {
        public SecretCodeAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            string secretCode = value as string;

            if (secretCode == null)
            {
                ErrorMessage = "Некорректный секретный код. Пример: AAAAA-AAAAA-AAAAA-AAAAA";
                return false;
            }

            if (secretCode.Length != 23)
            {
                ErrorMessage = "Некорректный секретный код. Не совпадает кол-во символов. Пример: AAAAA-AAAAA-AAAAA-AAAAA";
                return false;
            }

            for (int i = 0; i < secretCode.Length; i++)
            {
                if (secretCode[i] != '-' && (i == 5 || i == 11 || i == 17))
                {
                    ErrorMessage = "Некорректный секретный код. Некорректно расставлены дефисы. Пример: AAAAA-AAAAA-AAAAA-AAAAA";
                    return false;
                }
                if ((secretCode[1]=='-')||(secretCode[1] == ' '))
                {
                    ErrorMessage = "Некорректный секретный код. Неверный ввод. Пример: AAAAA-AAAAA-AAAAA-AAAAA";
                    return false;
                }
                
            }

            for (int i = 0; i < secretCode.Length - 2; i++)
            {
                if ((secretCode[i]==secretCode[i+1])&&(secretCode[i+1] == secretCode[i + 2]))
                {
                    ErrorMessage = "Некорректный секретный код. Неверный ввод. Пример: AAAAA-AAAAA-AAAAA-AAAAA";
                    return false;
                    
                }
                break;
            }

            return true;
        }
    }
}
