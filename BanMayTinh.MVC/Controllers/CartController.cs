using BanMayTinh.DTO;
using BanMayTinh.UTILITIES.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BanMayTinh.UI.Controllers
{
    public class CartController : Controller
    {
        private WebbanmaytinhContext db = new WebbanmaytinhContext();
        
        private readonly IHttpContextAccessor _contx;

        public CartController(IHttpContextAccessor contx)
        {
            _contx = contx;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng
        /// </summary>
        /// <param name="pid">Mã sản phẩm</param>
        /// <param name="qty">Số lượng tương ứng</param>
        /// <returns>
        ///     1 - thêm mới sản phẩm vào giỏ
        ///     2 - thêm số lượng cho sản phẩm đã có trong giỏ
        /// /returns>
        public ActionResult Add(int pid, int qty)
        {
            var p = db.TblProducts.Where(m => m.IsActive == 1 && m.IsDelete == 0 && m.Id == pid).First();

            var cart = HttpContext.Session.GetString("Cart");
            if (cart == null)
            {
                var item = new ModelCart();
                item.ProductID = p.Id;
                item.Name = p.Name;
                item.Slug = p.Slug;
                item.Image = p.Image;
                item.Quantity = qty;
                item.Price = (p.IsDiscount == 1 ? (long)p.ProPrice : (long)p.Price);
                ////  your list object
                List<ModelCart> list = new List<ModelCart>();
                list.Add(item);
                string listString = JsonConvert.SerializeObject(list);
                _contx.HttpContext.Session.SetString("Cart", listString);
                return Json(new { result = 1 });
            }
            else
            {
                List<ModelCart> list = new List<ModelCart>();
                string listString = _contx.HttpContext.Session.GetString("Cart");
                list = JsonConvert.DeserializeObject<List<ModelCart>>(listString);

                if (list.Exists(m => m.ProductID == pid))
                {
                    foreach (var item in list)
                    {
                        if (item.ProductID == pid)
                            item.Quantity += qty;
                        string listCart = JsonConvert.SerializeObject(list);
                        _contx.HttpContext.Session.SetString("Cart", listCart);
                        return Json(new { result = 2 });
                    }
                }
                else
                {
                    var item = new ModelCart();
                    item.ProductID = p.Id;
                    item.Name = p.Name;
                    item.Slug = p.Slug;
                    item.Image = p.Image;
                    item.Quantity = qty;
                    item.Price =( p.IsDiscount == 1 ? (long)p.ProPrice : (long)p.Price);
                    list.Add(item);
                    string listCart = JsonConvert.SerializeObject(list);
                    _contx.HttpContext.Session.SetString("Cart", listCart);
                    return Json(new { result = 1 });
                }
                
            }
            return Json(new { result = 0 });
        }

        /// <summary>
        /// Cập nhật thông tin trong giỏ hàng
        /// </summary>
        /// <param name="pid">Mã sản phẩm</param>
        /// <param name="option">Lựa chọn</param>
        /// <returns>
        /// 1 - tăng số lượng của sản phẩm
        /// 2 - giảm số lượng của sản phẩm
        /// 3 - xóa sản phẩm khỏi giỏ hàng
        /// </returns>
        public JsonResult Update(int pid, string option)
        {
            Console.WriteLine("1");
            List<ModelCart> cart = new List<ModelCart>();
            string cartString = _contx.HttpContext.Session.GetString("Cart");
            cart = JsonConvert.DeserializeObject<List<ModelCart>>(cartString);
            ModelCart m = cart.First(m => m.ProductID == pid);
            if(m != null)
            {
                switch(option)
                {
                    case "add":
                        m.Quantity++;
                        string cartAdd = JsonConvert.SerializeObject(cart);
                        _contx.HttpContext.Session.SetString("Cart", cartAdd);
                        return Json(1);
                    case "minus":
                        m.Quantity--;
                        string cartMinus = JsonConvert.SerializeObject(cart);
                        _contx.HttpContext.Session.SetString("Cart", cartMinus);
                        return Json(2);
                    case "remove":
                        cart.Remove(m);
                        if(cart.Count() == 0)
                        {
                            HttpContext.Session.Remove("Cart");
                        }
                        return Json(3);
                    default:
                        break;
                }
            }
            return Json(null);
        }

        /// <summary>
        /// Xóa toàn bộ sản phẩm khỏi giỏ hàng
        /// </summary>
        /// <returns>Chuyển hướng tới Index(giỏ hàng)</returns>
        public ActionResult RemoveAll()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Checkout()
        {
            if (HttpContext.Session.GetString("User_Name") != null && HttpContext.Session.GetString("Cart") != null)
            {
                int user_id = Convert.ToInt32(HttpContext.Session.GetString("User_ID"));
                ViewBag.Info = db.TblAccounts.Where(m => m.Id == user_id).First();
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
            return View();
        }

        // thanh toán
        [HttpPost]
        public JsonResult Payment(string Address, string FullName, string Phone, string Email, string Note)
        {
            var order = new TblOrder();
            int user_id = Convert.ToInt32(HttpContext.Session.GetString("User_ID"));
            order.CustomerId = user_id;
            order.CreatedDate = DateTime.Now;
            order.ReceiverName = FullName;
            order.ReceiverPhone = Phone;
            order.ReceiverEmail = Email;
            order.ReceiverAddress = Address;
            order.IsDelete = 0;
            order.Status = 1;
            db.TblOrders.Add(order);
            db.SaveChanges();

            long orderTotal = 0; 

            var OrderId = order.Id;
            List<ModelCart> cart = new List<ModelCart>();
            string cartString = _contx.HttpContext.Session.GetString("Cart");
            cart = JsonConvert.DeserializeObject<List<ModelCart>>(cartString);
            foreach (var c in cart)
            {
                var orderdetails = new TblOrderDetail();
                orderdetails.OrderId = OrderId;
                orderdetails.ProductId = c.ProductID;
                orderdetails.Price = c.Price;
                orderdetails.Quantity = c.Quantity;
                orderdetails.Total = c.Price * c.Quantity;
                db.TblOrderDetails.Add(orderdetails);
                orderTotal += c.Price * c.Quantity;
            }
            db.SaveChanges();

            order.Code = DateTime.Now.ToString("yyyyMMddhhMMss").Trim() + (user_id + OrderId).ToString().Trim();   // yyyy-MM-dd hh:MM:ss
            order.TotalMoney = orderTotal;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            HttpContext.Session.Remove("Cart");
            return Json(1);

        }


        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <returns>
        /// 1 - đã đăng nhập
        /// 0 - chưa đăng nhập
        /// </returns>
        public JsonResult CheckAuth()
        {
            if(HttpContext.Session.GetString("User_Name") != null)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}
