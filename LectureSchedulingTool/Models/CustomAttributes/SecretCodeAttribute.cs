using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

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
                if ((secretCode[1] == '-') || (secretCode[1] == ' '))
                {
                    ErrorMessage = "Некорректный секретный код. Неверный ввод. Пример: AAAAA-AAAAA-AAAAA-AAAAA";
                    return false;
                }

            }

            for (int i = 0; i < secretCode.Length - 2; i++)
            {
                if ((secretCode[i] == secretCode[i + 1]) && (secretCode[i + 1] == secretCode[i + 2]))
                {
                    ErrorMessage = "Некорректный секретный код. Неверный ввод. Пример: AAAAA-AAAAA-AAAAA-AAAAA";
                    return false;

                }
                break;
            }

            return true;
        }
    }

    public class Secret_code
    {
        [Key]
        public int id_secret_code { get; set; }

        [Required]
        [StringLength(23)]
        public string secret_code { get; set; }

        public Secret_code()
        {
            secret_code = "";
        }

        public void GenerateCode()
        {
            Random rand = new Random();
            string sc = "";

            for (int i = 0; i < 4; i++)
            {
                string sc_block = "";

                for (int j = 0; j < 5; j++)
                {                    
                    char sc_char = '?';
                    if (rand.Next(35) < 10)
                        sc_char = (char)rand.Next(48, 57);
                    else
                        sc_char = (char)rand.Next(65, 90);

                    if (sc_block.Contains(sc_char.ToString()))
                    {
                        j--;
                        continue;
                    }
                    else
                        sc_block += sc_char;
                }

                if (sc.Contains(sc_block))
                {
                    i--;
                    continue;
                }
                else
                    sc += sc_block;
                
                if (i != 3)
                    sc += "-";
            }
            
            secret_code = sc;
        }
    }

    public class SecretCodeContext : DbContext
    {
        public DbSet<Secret_code> Secret_code { get; set; }
    }
}
