using BanMayTinh.DTO;
using BanMayTinh.DTO.DTO.Image;
using BanMayTinh.UTILITIES.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BanMayTinh.DAO
{
    public class ProductImageDAO
    {
        public static List<TblProductImage> GetById(long productId)
        {
            List<TblProductImage> list = new List<TblProductImage>();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblProductImages.Where(ip => ip.IdProduct == productId).ToList();
            }
            return list;
        }

        public static List<TblProductImage> GetById(long productId, int page, int take) 
        { 
            List<TblProductImage> list = new List<TblProductImage> ();
            using (var context = new WebbanmaytinhContext())
            {
                list = context.TblProductImages.Where(ip => ip.IdProduct == productId).Skip((page - 1) * take).Take(take).ToList();
            }
            return list;
        }

        public static int CreateSingle(ImgProduct i)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    if (i.FileImage != null)
                    {
                        string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Product-Images\\";
                        int index;
                        var strSlug = context.TblProducts.Where(p => p.Id == i.IdProduct).First().Slug;
                        int countImg = context.TblProductImages.Where(pi => pi.IdProduct == i.IdProduct).Count();

                        if (countImg != 0)
                        {
                            string maxName = context.TblProductImages.Where(pi => pi.IdProduct == i.IdProduct).OrderByDescending(pi => pi.Id).Take(1).First().Name;
                            string[] lstCharac = maxName.Split("-");
                            string[] lastCharac = (lstCharac[lstCharac.Length - 1]).Split(".");
                            index = Int16.Parse(lastCharac[0]);
                        }
                        else
                        {
                            index = 0;
                        }
                        var productImage = new TblProductImage()
                        {
                            IdProduct = i.IdProduct,
                        };
                        String fileName = strSlug + '-' + (index + 1).ToString() + i.FileImage[0].FileName.Substring(i.FileImage[0].FileName.LastIndexOf('.'));
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            i.FileImage[0].CopyTo(stream);
                        }
                        productImage.Name = fileName;
                        context.TblProductImages.Add(productImage);
                        context.SaveChanges();
                        return (int)ReturnStatus.Success;
                    }
                    return (int)ReturnStatus.NotPictureUploaded;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }

        public static int CreateList(ImgProduct i)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    if (i.FileImage.Length > 0)
                    {
                        string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Product-Images\\";
                        int index;
                        var strSlug = context.TblProducts.Where(p => p.Id == i.IdProduct).First().Slug;
                        int countImg = context.TblProductImages.Where(pi => pi.IdProduct == i.IdProduct).Count();
                        if (countImg != 0)
                        {
                            string maxName = context.TblProductImages.Where(pi => pi.IdProduct == i.IdProduct).OrderByDescending(pi => pi.Id).Take(1).First().Name;
                            string[] lstCharac = maxName.Split("-");
                            string[] lastCharac = (lstCharac[lstCharac.Length - 1]).Split(".");
                            index = Int16.Parse(lastCharac[0]);
                        }
                        else
                        {
                            index = 0;
                        }
                        int stt = 1;
                        foreach (var file in i.FileImage)
                        {
                            var productImage = new TblProductImage()
                            {
                                IdProduct = i.IdProduct,
                            };
                            String fileName = strSlug + '-' + (index + stt).ToString() + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                            var path = Path.Combine(route, fileName);
                            using (var stream = File.Create(path))
                            {
                                file.CopyTo(stream);
                            }
                            productImage.Name = fileName;
                            context.TblProductImages.Add(productImage);
                            context.SaveChanges();
                            stt++;
                        }
                        return (int)ReturnStatus.Success;
                    }
                    return (int)ReturnStatus.NotPictureUploaded;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }
    
        public static int DeleteSingleByProductId(long productId, long imageId)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Product-Images\\";
                    var image = context.TblProductImages.Where(i => i.IdProduct == productId && i.Id == imageId).FirstOrDefault();
                    if (image == null)
                    {
                        return (int)ReturnStatus.NotExists;
                    }
                    string fileName = image.Name;
                    if (fileName != null && File.Exists(route + fileName))
                    {
                        File.Delete(route + fileName);
                    }
                    context.TblProductImages.Remove(image);
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

        public static int DeleteListByProductId(long  productId)
        {
            try
            {
                using (var context = new WebbanmaytinhContext())
                {
                    string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Product-Images\\";
                    var listImage = context.TblProductImages.Where(i => i.IdProduct == productId).ToList();
                    if (listImage.Count == 0)
                    {
                        return (int)ReturnStatus.NotExists;
                    }
                    foreach(var i in listImage)
                    {
                        string fileName = i.Name;
                        if (fileName != null && File.Exists(route + fileName))
                        {
                            File.Delete(route + fileName);
                        }
                        context.TblProductImages.Remove(i);
                    }
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

        public static int Edit(long imageId, ImgProduct i)
        {
            try
            {
                using(var context = new WebbanmaytinhContext())
                {
                    if (i.FileImage != null)
                    {
                        string route = "D:\\MyProject\\WebBanMayTinh\\BanMayTinh.MVC\\wwwroot\\Pictures\\Product-Images\\";
                        string fileName = context.TblProductImages.Where(p => p.Id == imageId && p.IdProduct == i.IdProduct).First().Name;
                        var productImage = new TblProductImage()
                        {
                            Id = imageId,
                            IdProduct = i.IdProduct,
                            Name = fileName,
                        };
                        var path = Path.Combine(route, fileName);
                        using (var stream = File.Create(path))
                        {
                            i.FileImage[0].CopyTo(stream);
                        }

                        context.Entry(productImage).State = EntityState.Detached;
                        context.SaveChanges();
                        return (int)ReturnStatus.Success;
                    }
                    return (int)ReturnStatus.NotPictureUploaded;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (int)ReturnStatus.Exception;
            }
        }
    }
}
