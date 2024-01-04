using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public enum AgeRating
    {
        G, // для всех возрастов
        PG, // для всех, но маленьким детям рекомендуется просмотр с родителями
        PG13, // детям до 13 лет просмотр не рекомендуется
        R, // до 17 лет просмотр исключительно с родителями
        NC17, // просмотр только после 17 лет

    }
}
