using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTour
{
    internal static class SearchErrorTypeExtension
    {
        public static string GetErrorMessage(this SearchErrorType errorType)
        {
            return errorType switch
            {
                SearchErrorType.INVALID_OPTION => "Csak a fent felsorolt lehetőségek közül választhat!(O,V,S,H,N)\n",
                SearchErrorType.TOO_LONG => "Túl hosszú szám!\n",
                SearchErrorType.NOT_NUMBER => "Csak számokat tartalmazhat!\n",
                SearchErrorType.NOT_STRING => "Csak betűket tartalmazhat!\n",
                _ => "Ismeretlen hiba!\n",
            };
        }
    }
}
