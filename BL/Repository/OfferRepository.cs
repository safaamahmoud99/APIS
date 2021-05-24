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
    class OfferRepository : BaseRepository<Offer>
    {
        private DbContext EC_DbContext;
        public OfferRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Offer> GetAllOffer()
        {
            return GetAll().ToList();
        }

        public bool InsertOffer(Offer offer)
        {
            return Insert(offer);
        }
        public void UpdateOffer(Offer offer)
        {
            Update(offer);
        }
        public void DeleteOffer(int id)
        {
            Delete(id);
        }
        public bool CheckOfferExists(Offer offer)
        {
            return GetAny(l => l.ID == offer.ID);
        }

    }
    }
