using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocalBrands.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepo _cartRepo;
        private readonly ICartItemRepo _cartItemRepo;

        public CartController(ICartRepo cartRepo, ICartItemRepo cartItemRepo)
        {
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
        }

        // عرض الكارت الخاص بالـ User الحالي
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByIdString(userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _cartRepo.Add(cart);
                _cartRepo.Save();
            }

            var lst = _cartItemRepo.GetAllIteam(cart.Id);
            return View("Index", lst);
        }

        // إضافة منتج للكارت أو تعديل الكمية لو موجود بالفعل
        public IActionResult UserCartCheck(int productID, int Quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByIdString(userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _cartRepo.Add(cart);
                _cartRepo.Save();
            }

            var item = _cartItemRepo.GetByProductIDCartID(productID, cart.Id);
            if (item != null)
            {
                item.Quantity = Quantity;
                item.AddedAt = DateTime.Now;
                _cartItemRepo.Update(item);
                _cartItemRepo.Save();
            }
            else
            {
                var newItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productID,
                    Quantity = Quantity,
                    AddedAt = DateTime.Now
                };
                _cartItemRepo.Add(newItem);
                _cartItemRepo.Save();
            }

            return RedirectToAction("Index");
        }

        // تعديل كمية منتج موجود بالفعل في الكارت
        public IActionResult Modifiy(int productID, int Quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByIdString(userId);

            var item = _cartItemRepo.GetByProductIDCartID(productID, cart.Id);
            if (item != null)
            {
                item.Quantity = Quantity;
                item.AddedAt = DateTime.Now;
                _cartItemRepo.Update(item);
                _cartItemRepo.Save();
            }

            return RedirectToAction("Index");
        }
    }
}