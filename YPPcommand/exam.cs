using System;
using System.Collections.Generic;
using System.Text;

namespace YPPcommand
{
    class Exam

        {
            public string Namepredmet { get; set; }
            public int Otsenka { get; set; }
            public DateTime Data { get; set; }

            public Exam(string Namepredmet, int Otsenka, DateTime Data)
            {
                this.Namepredmet = Namepredmet;
                this.Otsenka = Otsenka;
                this.Data = Data;
            }
            public Exam()
            {
                Namepredmet = "kpiap";
                Otsenka = 10;
                Data = new DateTime(2025, 2, 4);
            }
            public override string ToString()
            {
                return $"Предмет: {Namepredmet} Оценка: {Otsenka} дата: {Data}";
            }
        }
    }

