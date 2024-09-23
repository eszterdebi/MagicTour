using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTour
{
    internal class BadInputException(string message) : Exception(message)
    {
    }
}
