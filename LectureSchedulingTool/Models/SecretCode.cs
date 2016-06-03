using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace LectureSchedulingTool.Models
{
    public class Secret_code
    {
        [Key]
        public int id_secret_code { get; set; }

        [Required]
        [StringLength(23)]
        public string secret_code { get; set; }

        public Secret_code()
        {

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
                    char sc_char;

                    if (rand.Next(1, 35) < 10)
                        sc_char = (char)rand.Next(48, 57);
                    else
                        sc_char = (char)rand.Next(65, 90);

                    if (sc_block.Contains(sc_char))
                    {
                        j--;
                        continue;
                    }
                    else
                        sc_block += sc_char;
                }

                sc += sc_block;

                if (i != 3)
                    sc += "-";
            }

            secret_code = sc;
        }

        public override string ToString()
        {
            return secret_code;
        }
    }
}
