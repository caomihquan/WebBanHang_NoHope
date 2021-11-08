﻿using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        WebBanHangDbContext db = null;
        public ProductCategoryDao()
        {
            db = new WebBanHangDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(ProductCategory entity)
        {
            try
            {
                var productcategory = db.ProductCategories.Find(entity.ID);
                productcategory.Name = entity.Name;
                productcategory.MetaTitle = entity.MetaTitle;
                productcategory.ParentID = entity.ParentID;
                productcategory.DisplayOrder = entity.DisplayOrder;
                productcategory.SeoTitle = entity.SeoTitle;
                productcategory.ModifiedBy = entity.ModifiedBy;
                productcategory.ModifiedDate = DateTime.Now;
                productcategory.MetaDescriptions = entity.MetaDescriptions;
                productcategory.MetaKeywords = entity.MetaKeywords;
                productcategory.ShowOnHome = entity.ShowOnHome;
                productcategory.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var productcategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productcategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
