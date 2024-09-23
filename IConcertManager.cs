using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTour
{
    internal interface IConcertManager
    { 
        void AboutTour();
        void ListItinerary(List<Concert> concerts);
        void ListSetlist();
        void MaxAttendace(List<Concert> concerts);
        void AvrAttendance(List<Concert> concerts);
        void ListBy(List<Concert> concerts);
        void Delilah();
    }
}
