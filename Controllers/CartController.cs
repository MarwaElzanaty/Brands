<<<<<<< HEAD
﻿using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
=======
﻿using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
namespace LocalBrands.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepo _cartRepo;
        private readonly ICartItemRepo _cartItemRepo;
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        public CartController(ICartRepo cartRepo, ICartItemRepo cartItemRepo)
        {
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
        }
<<<<<<< HEAD
=======

        // عرض الكارت الخاص بالـ User الحالي
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByIdString(userId);
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _cartRepo.Add(cart);
                _cartRepo.Save();
            }
<<<<<<< HEAD
            var lst = _cartItemRepo.GetAllIteam(cart.Id);
            return View("Index", lst);
        }
=======

            var lst = _cartItemRepo.GetAllIteam(cart.Id);
            return View("Index", lst);
        }

        // إضافة منتج للكارت أو تعديل الكمية لو موجود بالفعل
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        public IActionResult UserCartCheck(int productID, int Quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByIdString(userId);
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _cartRepo.Add(cart);
                _cartRepo.Save();
            }
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
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
<<<<<<< HEAD
            return RedirectToAction("Index");
        }
        public IActionResult Modifiy(int productID, int Quantity)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByIdString(userId);
=======

            return RedirectToAction("Index");
        }

        // تعديل كمية منتج موجود بالفعل في الكارت
        public IActionResult Modifiy(int productID, int Quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByIdString(userId);

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
            var item = _cartItemRepo.GetByProductIDCartID(productID, cart.Id);
            if (item != null)
            {
                item.Quantity = Quantity;
                item.AddedAt = DateTime.Now;
                _cartItemRepo.Update(item);
                _cartItemRepo.Save();
            }
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
            return RedirectToAction("Index");
        }
    }
}