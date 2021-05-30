using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class AdvertisementRepository :BaseRepository<Advertisement>
    {
            private DbContext EC_DbContext;
            public AdvertisementRepository(DbContext EC_DbContext) : base(EC_DbContext)
            {
                this.EC_DbContext = EC_DbContext;
            }
            public List<Advertisement> GetAllAdvertisement()
            {
                return GetAll().ToList();
            }

            public bool InsertAdvertisement(Advertisement  advertisement)
            {
                return Insert(advertisement);
            }
            public void UpdateAdvertisement(Advertisement advertisement)
            {
                Update(advertisement);
            }
            public void DeleteAdvertisement(int id)
            {
                Delete(id);
            }
            public bool CheckAdvertisementExists(Advertisement  advertisement)
            {
                return GetAny(b => b.ID == advertisement.ID);
            }
            public Advertisement GetAdvertisementById(int id)
            {
                return GetFirstOrDefault(b => b.ID == id);
            }
        }
}
