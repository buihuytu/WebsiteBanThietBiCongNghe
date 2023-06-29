using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.DTO.DTO.Modal;
using BanMayTinh.UTILITIES.Enums;
using BanMayTinh.UTILITIES.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BanMayTinh.DAO
{
    public class ProductDAO
    {
        public static List<ProductEntity> GetAll(int isDelete)
        {
            var list = new List<ProductEntity>();
            using (var context = new WebbanmaytinhContext())
            {
                list = (from p in context.TblProducts
                       where p.IsDelete == isDelete
                       select new ProductEntity()
                       {
                           ProductId = p.Id,
                           ProductName = p.Name,
                           Slug = p.Slug,
                           Description = p.Description == null ? "" : p.Description,
                           Detail = p.Detail == null ? "" : p.Detail,
                           ProductImage = p.Image,
                           BrandId = p.IdBrand,
                           BrandName = p.IdBrand == null ? "" : (from b in context.TblBrands where b.Id == p.IdBrand select b.Name).FirstOrDefault(),
                           CategoryId = p.IdCategory,
                           CategoryName = p.IdCategory == null ? "" : (from c in context.TblCategories where c.Id == p.IdCategory select c.Name).FirstOrDefault(),
                           Specification = p.Specification == null ? "" : p.Specification,
                           Feature = p.Feature == null ? "" : p.Feature,
                           NewPromotion = p.NewPromotion == null ? "" : p.NewPromotion,
                           ImPrice = p.ImPrice,
                           Price = p.Price,
                           ProPrice = p.ProPrice,
                           Quantity = p.Quantity,
                           Guarantee = p.Guarantee == null ? "" : p.Guarantee,
                           Gift = p.Gift == null ? "" : p.Gift,
                           MetaTitle = p.MetaTitle == null ? "" : p.MetaTitle,
                           MetaKey = p.MetaKey == null ? "" : p.MetaKey,
                           MetaDesc = p.MetaDesc == null ? "" : p.MetaDesc,
                           CreatedDate = p.CreatedDate,
                           CreatedBy = (p.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.CreatedBy select a.Username).FirstOrDefault()),
                           UpdatedDate = p.UpdatedDate,
                           UpdatedBy = (p.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.UpdatedBy select a.Username).FirstOrDefault()),
                           IsDelete = p.IsDelete,
                           IsActive = p.IsActive,
                           IsDiscount = p.IsDiscount,
                           IsHotProduct = p.IsHotProduct,
                       }).ToList();
            }
            return list;
        }

        public static List<ProductEntity> GetAll(int page, int take, int isDelete)
        {
            var list = new List<ProductEntity>();
            using (var context = new WebbanmaytinhContext())
            {
                list = (from p in context.TblProducts
                        where p.IsDelete == isDelete
                        select new ProductEntity()
                        {
                            ProductId = p.Id,
                            ProductName = p.Name,
                            Slug = p.Slug,
                            Description = p.Description == null ? "" : p.Description,
                            Detail = p.Detail == null ? "" : p.Detail,
                            ProductImage = p.Image,
                            BrandId = p.IdBrand,
                            BrandName = p.IdBrand == null ? "" : (from b in context.TblBrands where b.Id == p.IdBrand select b.Name).FirstOrDefault(),
                            CategoryId = p.IdCategory,
                            CategoryName = p.IdCategory == null ? "" : (from c in context.TblCategories where c.Id == p.IdCategory select c.Name).FirstOrDefault(),
                            Specification = p.Specification == null ? "" : p.Specification,
                            Feature = p.Feature == null ? "" : p.Feature,
                            NewPromotion = p.NewPromotion == null ? "" : p.NewPromotion,
                            ImPrice = p.ImPrice,
                            Price = p.Price,
                            ProPrice = p.ProPrice,
                            Quantity = p.Quantity,
                            Guarantee = p.Guarantee == null ? "" : p.Guarantee,
                            Gift = p.Gift == null ? "" : p.Gift,
                            MetaTitle = p.MetaTitle == null ? "" : p.MetaTitle,
                            MetaKey = p.MetaKey == null ? "" : p.MetaKey,
                            MetaDesc = p.MetaDesc == null ? "" : p.MetaDesc,
                            CreatedDate = p.CreatedDate,
                            CreatedBy = (p.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = p.UpdatedDate,
                            UpdatedBy = (p.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = p.IsDelete,
                            IsActive = p.IsActive,
                            IsDiscount = p.IsDiscount,
                            IsHotProduct = p.IsHotProduct,
                        }).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static ProductEntity GetById(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    var product = new ProductEntity();
                    product = (from p in context.TblProducts
                            where p.Id == id
                            select new ProductEntity()
                            {
                                ProductId = p.Id,
                                ProductName = p.Name,
                                Slug = p.Slug,
                                Description = p.Description == null ? "" : p.Description,
                                Detail = p.Detail == null ? "" : p.Detail,
                                ProductImage = p.Image,
                                BrandId = p.IdBrand,
                                BrandName = p.IdBrand == null ? "" : (from b in context.TblBrands where b.Id == p.IdBrand select b.Name).FirstOrDefault(),
                                CategoryId = p.IdCategory,
                                CategoryName = p.IdCategory == null ? "" : (from c in context.TblCategories where c.Id == p.IdCategory select c.Name).FirstOrDefault(),
                                Specification = p.Specification == null ? "" : p.Specification,
                                Feature = p.Feature == null ? "" : p.Feature,
                                NewPromotion = p.NewPromotion == null ? "" : p.NewPromotion,
                                ImPrice = p.ImPrice,
                                Price = p.Price,
                                ProPrice = p.ProPrice,
                                Quantity = p.Quantity,
                                Guarantee = p.Guarantee == null ? "" : p.Guarantee,
                                Gift = p.Gift == null ? "" : p.Gift,
                                MetaTitle = p.MetaTitle == null ? "" : p.MetaTitle,
                                MetaKey = p.MetaKey == null ? "" : p.MetaKey,
                                MetaDesc = p.MetaDesc == null ? "" : p.MetaDesc,
                                CreatedDate = p.CreatedDate,
                                CreatedBy = (p.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.CreatedBy select a.Username).FirstOrDefault()),
                                UpdatedDate = p.UpdatedDate,
                                UpdatedBy = (p.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.UpdatedBy select a.Username).FirstOrDefault()),
                                IsDelete = p.IsDelete,
                                IsActive = p.IsActive,
                                IsDiscount = p.IsDiscount,
                                IsHotProduct = p.IsHotProduct,
                            }).FirstOrDefault();
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ProductEntity> GetByName(string name, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<ProductEntity>();
                list = (from p in context.TblProducts
                        where p.Name.Contains(name) && p.IsDelete == isDelete
                        select new ProductEntity()
                        {
                            ProductId = p.Id,
                            ProductName = p.Name,
                            Slug = p.Slug,
                            Description = p.Description == null ? "" : p.Description,
                            Detail = p.Detail == null ? "" : p.Detail,
                            ProductImage = p.Image,
                            BrandId = p.IdBrand,
                            BrandName = p.IdBrand == null ? "" : (from b in context.TblBrands where b.Id == p.IdBrand select b.Name).FirstOrDefault(),
                            CategoryId = p.IdCategory,
                            CategoryName = p.IdCategory == null ? "" : (from c in context.TblCategories where c.Id == p.IdCategory select c.Name).FirstOrDefault(),
                            Specification = p.Specification == null ? "" : p.Specification,
                            Feature = p.Feature == null ? "" : p.Feature,
                            NewPromotion = p.NewPromotion == null ? "" : p.NewPromotion,
                            ImPrice = p.ImPrice,
                            Price = p.Price,
                            ProPrice = p.ProPrice,
                            Quantity = p.Quantity,
                            Guarantee = p.Guarantee == null ? "" : p.Guarantee,
                            Gift = p.Gift == null ? "" : p.Gift,
                            MetaTitle = p.MetaTitle == null ? "" : p.MetaTitle,
                            MetaKey = p.MetaKey == null ? "" : p.MetaKey,
                            MetaDesc = p.MetaDesc == null ? "" : p.MetaDesc,
                            CreatedDate = p.CreatedDate,
                            CreatedBy = (p.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = p.UpdatedDate,
                            UpdatedBy = (p.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = p.IsDelete,
                            IsActive = p.IsActive,
                            IsDiscount = p.IsDiscount,
                            IsHotProduct = p.IsHotProduct,
                        }).ToList();
                return list;
            }
        }

        public static List<ProductEntity> GetByName(string name, int page, int take, int isDelete)
        {
            using (var context = new WebbanmaytinhContext())
            {
                var list = new List<ProductEntity>();
                list = (from p in context.TblProducts
                        where p.Name.Contains(name) && p.IsDelete == isDelete
                        select new ProductEntity()
                        {
                            ProductId = p.Id,
                            ProductName = p.Name,
                            Slug = p.Slug,
                            Description = p.Description == null ? "" : p.Description,
                            Detail = p.Detail == null ? "" : p.Detail,
                            ProductImage = p.Image,
                            BrandId = p.IdBrand,
                            BrandName = p.IdBrand == null ? "" : (from b in context.TblBrands where b.Id == p.IdBrand select b.Name).FirstOrDefault(),
                            CategoryId = p.IdCategory,
                            CategoryName = p.IdCategory == null ? "" : (from c in context.TblCategories where c.Id == p.IdCategory select c.Name).FirstOrDefault(),
                            Specification = p.Specification == null ? "" : p.Specification,
                            Feature = p.Feature == null ? "" : p.Feature,
                            NewPromotion = p.NewPromotion == null ? "" : p.NewPromotion,
                            ImPrice = p.ImPrice,
                            Price = p.Price,
                            ProPrice = p.ProPrice,
                            Quantity = p.Quantity,
                            Guarantee = p.Guarantee == null ? "" : p.Guarantee,
                            Gift = p.Gift == null ? "" : p.Gift,
                            MetaTitle = p.MetaTitle == null ? "" : p.MetaTitle,
                            MetaKey = p.MetaKey == null ? "" : p.MetaKey,
                            MetaDesc = p.MetaDesc == null ? "" : p.MetaDesc,
                            CreatedDate = p.CreatedDate,
                            CreatedBy = (p.CreatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.CreatedBy select a.Username).FirstOrDefault()),
                            UpdatedDate = p.UpdatedDate,
                            UpdatedBy = (p.UpdatedBy == null ? "" : (from a in context.TblAccounts where a.Id == p.UpdatedBy select a.Username).FirstOrDefault()),
                            IsDelete = p.IsDelete,
                            IsActive = p.IsActive,
                            IsDiscount = p.IsDiscount,
                            IsHotProduct = p.IsHotProduct,
                        }).Skip((page - 1) * take).Take(take).ToList();
                return list;
            }
        }

        public static int Create(ProductImage p)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    string route = @"D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Products\\";
                    string slug = XString.ToAscii(p.Name);
                    CheckSlug check = new CheckSlug(context);
                    if(!check.KiemTraSlug("tblProduct", slug, null))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var product = new TblProduct
                    {
                        Name = p.Name,
                        Slug = slug,
                        Description = p.Description,
                        Detail = p.Detail,
                        IdBrand = p.IdBrand == 0 ? null : p.IdBrand,
                        IdCategory = p.IdCategory == 0 ? null : p.IdCategory,
                        Specification = p.Specification,
                        Feature = p.Feature,
                        NewPromotion = p.NewPromotion,
                        ImPrice = p.ImPrice,
                        Price = p.Price,
                        ProPrice = p.ProPrice,
                        Quantity = p.Quantity,
                        Guarantee = p.Guarantee,
                        Gift = p.Gift,
                        MetaTitle = p.MetaTitle,
                        MetaKey = p.MetaKey,
                        MetaDesc = p.MetaDesc,
                        CreatedDate = DateTime.Now,
                        CreatedBy = p.CreatedBy,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = p.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = p.IsActive,
                        IsDiscount = p.IsDiscount,
                        IsHotProduct = p.IsHotProduct
                    };
                    if(p.FileImage != null)
                    {
                        string fileName = slug + p.FileImage.FileName.Substring(p.FileImage.FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using(var stream = File.Create(path))
                        {
                            p.FileImage.CopyTo(stream);
                        }
                        product.Image = fileName;
                    }
                    else
                    {
                        product.Image = null;
                    }
                    context.TblProducts.Add(product);
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int Delete(long id)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string routeProduct = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Products\\";
                    string routeListImg = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Product-Images\\";
                    var product = context.TblProducts.Find(id);
                    if (product == null)
                    {
                        return (int)ReturnStatus.NotExists;
                    }
                    string fileName = product.Image;
                    if (fileName != null)
                    {
                        File.Delete(routeProduct + fileName);
                    }
                    var listImage = context.TblProductImages.Where(pi => pi.IdProduct == id).ToList();
                    foreach (var img in listImage)
                    {
                        File.Delete(routeListImg + img.Name);
                    }
                    context.TblProducts.Remove(product);
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int Update(long id, ProductImage p) 
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Products\\";
                    string slug = XString.ToAscii(p.Name);
                    CheckSlug check = new CheckSlug(context);
                    if (!check.KiemTraSlug("tblProduct", slug, id))
                    {
                        return (int)ReturnStatus.Exists;
                    }
                    var product = new TblProduct
                    {
                        Id = id,
                        Name = p.Name,
                        Slug = slug,
                        Description = p.Description,
                        Detail = p.Detail,
                        IdBrand = p.IdBrand == 0 ? null : p.IdBrand,
                        IdCategory = p.IdCategory == 0 ? null : p.IdCategory,
                        Specification = p.Specification,
                        Feature = p.Feature,
                        NewPromotion = p.NewPromotion,
                        ImPrice = p.ImPrice,
                        Price = p.Price,
                        ProPrice = p.ProPrice,
                        Quantity = p.Quantity,
                        Guarantee = p.Guarantee,
                        Gift = p.Gift,
                        MetaTitle = p.MetaTitle,
                        MetaKey = p.MetaKey,
                        MetaDesc = p.MetaDesc,
                        CreatedDate = (from pr in context.TblProducts where pr.Id == id select pr.CreatedDate).FirstOrDefault(),
                        CreatedBy = (from pr in context.TblProducts where pr.Id == id select pr.CreatedBy).FirstOrDefault(),
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = p.UpdatedBy,
                        IsDelete = (byte?)DeleteStatus.IsNotDelete,
                        IsActive = p.IsActive,
                        IsDiscount = p.IsDiscount,
                        IsHotProduct = p.IsHotProduct
                    };
                    string oldName = (from pr in context.TblProducts where pr.Id == id select pr.Image).FirstOrDefault();
                    if (p.FileImage != null)
                    {
                        string fileName = slug + p.FileImage.FileName.Substring(p.FileImage.FileName.LastIndexOf('.'));
                        if (fileName != oldName && oldName != null && File.Exists(route + oldName))
                        {
                            File.Delete(route + oldName);
                        }
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            p.FileImage.CopyTo(stream);
                        }
                        product.Image = fileName;
                    }
                    else
                    {
                        string[] newNameImage = oldName.Split(".");
                        string newName = slug + "." + newNameImage[newNameImage.Length - 1];
                        if (newName != oldName && File.Exists(route + oldName))
                        {
                            File.Move(route + oldName, route + newName);
                            product.Image = newName;
                        }
                        else
                        {
                            product.Image = oldName;
                        }
                    }
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int DelTrash(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblProduct product = context.TblProducts.Find(id);
                    product.IsDelete = 1;

                    product.UpdatedDate = DateTime.Now;
                    product.UpdatedBy = updatedBy;

                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int ReTrash(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblProduct product = context.TblProducts.Find(id);
                    product.IsDelete = 0;

                    product.UpdatedDate = DateTime.Now;
                    product.UpdatedBy = updatedBy;

                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int ChangeActive(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblProduct product = context.TblProducts.Find(id);
                    product.IsActive = (byte?)((product.IsActive == 1) ? 0 : 1);
                    product.UpdatedDate = DateTime.Now;
                    product.UpdatedBy = updatedBy;
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int ChangeDiscount(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblProduct product = context.TblProducts.Find(id);
                    product.IsDiscount = (byte?)((product.IsDiscount == 1) ? 0 : 1);
                    product.UpdatedDate = DateTime.Now;
                    product.UpdatedBy = updatedBy;
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int ChangeHotProduct(long id, long updatedBy)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    TblProduct product = context.TblProducts.Find(id);
                    product.IsHotProduct = (byte?)((product.IsHotProduct == 1) ? 0 : 1);
                    product.UpdatedDate = DateTime.Now;
                    product.UpdatedBy = updatedBy;
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return (int)ReturnStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static long GetIdByName(string name)
        {
            using(var context = new WebbanmaytinhContext())
            {
                long id = (from c in context.TblProducts where c.Name ==  name select c.Id).FirstOrDefault();
                return id;
            }
        }
    }
}
