using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using LocalBrands.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocalBrands.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepo _orderRepo;
        private readonly ICartRepo _cartRepo;
        private readonly ICartItemRepo _cartItemRepo;

        public OrderController(IOrderRepo orderRepo, ICartRepo cartRepo, ICartItemRepo cartItemRepo)
        {
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
        }

        // Index To Show All User Orders (Index For User)
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _orderRepo.GetAll()
                                   .Where(o => o.UserId == userId)
                                   .ToList();

            return View("Index", orders);
        }
        // // Index To Show All The Orders For The Admin (Index For Admin)
        [HttpGet]
        public IActionResult AdminIndex()
        {
            var orders = _orderRepo.GetAll().ToList();
            return View("AdminIndex", orders);
        }
        public IActionResult Details(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            return View("Details", order);
        }
        [HttpGet]
        public IActionResult AdminDetails(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            return View("AdminDetails", order);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new OrderCreateViewModel();
            return View("Create", vm);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel orderData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", orderData);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepo.GetByUserId(userId);

            if (cart == null || !cart.CartItems.Any())
                return BadRequest("Cart is empty");

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                ShippingAddress = orderData.ShippingAddress,
                PhoneNumber = orderData.PhoneNumber,
                Notes = orderData.Notes,
                TotalAmount = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity),
                PaymentMethod = orderData.PaymentMethod,   // PaymentMethod
                OrderItems = new List<OrderItem>()
            };

            foreach (var ci in cart.CartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    PriceAtPurchase = ci.Product.Price
                });
            }

            _orderRepo.Add(order);
            _orderRepo.Save();

            return View("Details", order);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            var vm = new OrderCreateViewModel
            {
                ShippingAddress = order.ShippingAddress,
                PhoneNumber = order.PhoneNumber,
                Notes = order.Notes,
                PaymentMethod = order.PaymentMethod   //  PaymentMethod
            };

            return View("Edit", vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, OrderCreateViewModel orderData)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", orderData);
            }

            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            order.ShippingAddress = orderData.ShippingAddress;
            order.PhoneNumber = orderData.PhoneNumber;
            order.Notes = orderData.Notes;
            order.PaymentMethod = orderData.PaymentMethod;   // PaymentMethod

            _orderRepo.Update(order);
            _orderRepo.Save();

            return RedirectToAction("Details", new { id = order.Id });
        }
        public IActionResult Delete(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            _orderRepo.Delete(order);
            _orderRepo.Save();

            var orders = _orderRepo.GetAll();
            return View("Index", orders); 
        }
        [HttpPost]
        public IActionResult AdminDelete(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            _orderRepo.Delete(order);
            _orderRepo.Save();

            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var order = _orderRepo.GetById(id);
            if (order == null) return NotFound();

            order.Status = status;
            _orderRepo.Update(order);
            _orderRepo.Save();

            return RedirectToAction("AdminDetails", new { id = order.Id });
        }
    }
}