using System.Collections.Generic;
using FileData;
using DNP_Assignment_1.Models;
using Models;

namespace DNP_Assignment_1.Data
{
    public class AdultService : IAdultService
    {
        private FileContext _fileContext = new FileContext();
        
        
        public IList<Adult> getAdults()
        {
            return _fileContext.Adults;
        }

        public IList<User> getUsers()
        {
            return _fileContext.Users;
        }

        public void addAdult(Adult adult)
        {
            int id = addId();
            adult.Id = id;
            _fileContext.Adults.Insert(id,adult);
            _fileContext.SaveChanges();
        }

        public void removeAdult(Adult adult)
        {
            _fileContext.Adults.Remove(adult);
            _fileContext.SaveChanges();
        }

        public int addId()
        {
            int j = 0;
            for (int i = 0; i < _fileContext.Adults.Count; i++)
            {
                if (_fileContext.Adults[i].Id != i)
                {
                    return i;
                }
            }

            return _fileContext.Adults.Count;
        }
        
    }
}