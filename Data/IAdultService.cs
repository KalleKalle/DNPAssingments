using System.Collections.Generic;
using Models;

namespace DNP_Assignment_1.Data
{
    public interface IAdultService
    {
        IList<Adult> getAdults();
        void addAdult(Adult adult);
        void removeAdult(Adult adult);
        
    }
}