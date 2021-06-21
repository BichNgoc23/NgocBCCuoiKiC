using ModelEF.EF;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class ProductDao
    {
        private NguyenThiBichNgocContext db;
        public ProductDao()
        {
            db = new NguyenThiBichNgocContext();
        }
        public List<ProductModel> ListWhereAll(string keysearch)
        {
            var list_pro = from p in db.Products
                               join c in db.Categories
                               on p.IDCategory equals c.ID
                               orderby p.Quantity, p.UnitCost descending
                               select new ProductModel
                               {
                                   ID = p.ID,
                                   Name = p.Name,
                                   UnitCost = (decimal)p.UnitCost,
                                   Quantity = p.Quantity,
                                   Image = p.Image,
                                   Description = p.Description,
                                   category_name=c.Name
                               };
            var list_pro_1 = from p in db.Products
                                 join c in db.Categories
                                 on p.IDCategory equals c.ID
                                 where p.Name.Contains(keysearch)
                                 orderby p.Quantity, p.UnitCost descending
                                 select new ProductModel 
                                 {
                                     ID = p.ID,
                                     Name = p.Name,
                                     UnitCost = (decimal)p.UnitCost,
                                     Quantity = p.Quantity,
                                     Image = p.Image,
                                     Description = p.Description,
                                     category_name = c.Name
                                 };
            if (!string.IsNullOrEmpty(keysearch))
                return list_pro_1.ToList();
            return list_pro.ToList();
        }
        public List<Product> ListAll()
        {
            return db.Products.Where(x => x.Status == 1).ToList();
        }
        public Product FindId(System.Int32 id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
