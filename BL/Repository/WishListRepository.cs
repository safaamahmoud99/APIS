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
    public class WishListRepository:BaseRepository<WishList>
    {
        private DbContext EC_DbContext;
        public WishListRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<WishList> GetAllWishlist()
        {
            return GetAll().ToList();
        }

        public bool InsertWishlist(WishList wishlist)
        {
            return Insert(wishlist);
        }
        public void UpdateWishlist(WishList wishlist)
        {
            Update(wishlist);
        }
        public void DeleteWishlist(int id)
        {
            Delete(id);
        }
        public bool CheckWishlistExists(WishList wishlist)
        {
            return GetAny(l => l.UserID == wishlist.UserID);
        }
        public WishList GetWishlistById(string id)
        {
            return GetFirstOrDefault(l => l.UserID == id);
        }
    }
}
