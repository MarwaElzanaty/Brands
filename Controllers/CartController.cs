using LocalBrands.Data.Repository;
using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace LocalBrands.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepo _cartRepo;
        private readonly ICartItemRepo _cartItemRepo;

        public CartController(ICartRepo CartClass, ICartItemRepo cartItemRepo)
        {
            _cartRepo = CartClass;
            _cartItemRepo = cartItemRepo;
        }
        public IActionResult Index(string UserID)
        {
           Cart cart =_cartRepo.GetByIdString(UserID);

            List<CartItem> lst=_cartItemRepo.GetAllIteam(cart.Id);

            return View("index",lst);
        }

        // check if user have car or no
        public IActionResult UserCartCheck(string Userid,int productID,int Quantity)
        {
           

           
            Cart cart = new Cart();
           


            if (_cartRepo.GetByIdString(Userid) == null )
            {
                
                cart.UserId = Userid;
                _cartRepo.Add(cart);
                _cartRepo.Save();
            }
             
            cart = _cartRepo.GetByIdString(Userid);
            CartItem item = new CartItem();
            if(_cartItemRepo.GetByProductIDCartID(productID, cart.Id) != null)
            {
                item = _cartItemRepo.GetByProductIDCartID(productID, cart.Id);
                item.CartId = cart.Id;
                item.ProductId = productID;
                item.Quantity = Quantity;
                item.AddedAt = DateTime.Now;
                _cartItemRepo.Update(item);
                _cartItemRepo.Save();

            }
            else
            {
                item.CartId = cart.Id;
                item.ProductId = productID;
                item.Quantity = Quantity;
                item.AddedAt = DateTime.Now;
                _cartItemRepo.Add(item);
                _cartItemRepo.Save();
            }
            
           



            return RedirectToAction("index","Home");
        }


        public IActionResult Modifiy(string Userid, int productID, int Quantity)
        {
            CartItem item = new CartItem();
            Cart cart = _cartRepo.GetByIdString(Userid);
            item = _cartItemRepo.GetByProductIDCartID(productID, cart.Id);
            item.CartId = cart.Id;
            item.ProductId = productID;
            item.Quantity = Quantity;
            item.AddedAt = DateTime.Now;
            _cartItemRepo.Update(item);
            _cartItemRepo.Save();


            return RedirectToAction("Index", new { UserID = "b0cc7bbc-ead6-44f0-bf85-8e54ec7e95dc" });
        }



    }
}
