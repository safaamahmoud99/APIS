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
   public class ImageRepository : BaseRepository<Images>
    {
        private DbContext EC_DbContext;
        public ImageRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Images> GetAllImage()
        {
            return GetAll().ToList();
        }

        public bool InsertImage(Images image)
        {
            return Insert(image);
        }
        public void UpdateImage(Images image)
        {
            Update(image);
        }
        public void DeleteImage(int id)
        {
            Delete(id);
        }
        public bool CheckImageExists(Images image)
        {
            return GetAny(I=> I.ID == image.ID);
        }
        public Images GetImageById(int id)
        {
            return GetFirstOrDefault(I => I.ID == id);
        }
    }
}
