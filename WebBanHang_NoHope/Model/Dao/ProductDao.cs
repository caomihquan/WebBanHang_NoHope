﻿using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        WebBanHangDbContext db = null;
        public ProductDao()
        {
            db = new WebBanHangDbContext();
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public int? InsertViewCount(Product entity)
        {

            var product = db.Products.Find(entity.ID);
            product.ViewCount = entity.ViewCount;
            db.SaveChanges();
            return product.ViewCount + 1;

        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.MoreImages = entity.MoreImages;
                product.Price = entity.Price;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                //product.Link = entity.Link;
                product.Status = entity.Status;
                product.ModifiedBy = entity.ModifiedBy;
                product.ModifiedDate = DateTime.Now;
                product.TopHot = entity.TopHot;
                product.ViewCount = entity.ViewCount;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Product> ListPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListAllProduct()
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            var maxValue = db.Products.Max(x => x.ViewCount);
            return db.Products.Where(x => x.Status == true).OrderByDescending(x => x.ViewCount).Take(top).ToList();
        }

        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }

        public List<Product> ListByCategoryId(long categoryID, ref int totalRecord, int page = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return model;
            
        }

        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Products
                         join b in db.ProductCategories
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price,
                             
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price,
                             
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public void UpdateImages(long productId, string images)
        {
            var product = db.Products.Find(productId);
            product.MoreImages = images;
            db.SaveChanges();
        }

        public Product ViewDetail(long id)
        {
            var model = db.Products.Find(id);
            model.ViewCount++;
            db.SaveChanges();
            return model;
        }
    }
}
