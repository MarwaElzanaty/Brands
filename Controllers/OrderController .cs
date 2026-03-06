//using LocalBrands.Data.Repository.Interfaces;
//using LocalBrands.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace LocalBrands.Controllers
//{
//    public class OrderController : Controller
//    {
//        private readonly IOrderRepo _orderRepo;
//        private readonly ICartRepo _cartRepo;
//        private readonly ICartItemRepo _cartItemRepo;

//        public OrderController(IOrderRepo orderRepo, ICartRepo cartRepo, ICartItemRepo cartItemRepo)
//        {
//            _orderRepo = orderRepo;
//            _cartRepo = cartRepo;
//            _cartItemRepo = cartItemRepo;
//        }

//        // ✅ عرض كل الطلبات
//        public IActionResult Index()
//        {
//            var orders = _orderRepo.GetAll();
//            return View("Index", orders);
//        }

//        // ✅ تفاصيل طلب واحد
//        public IActionResult Details(int id)
//        {
//            var order = _orderRepo.GetById(id);
//            if (order == null)
//                return NotFound();

//            return View("Details", order);
//        }

//        // ✅ إنشاء طلب جديد (Checkout)
//        [HttpGet]
//        public IActionResult Create()
//        {
//            var order = new Order(); // علشان الفورم يبقى جاهز
//            return View("Create", order);
//        }

//        [HttpPost]
//        public IActionResult Create(Order orderData)
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // ✅ ده بيرجع الـ UserId الحقيقي
//            var cart = _cartRepo.GetByUserId(userId);

//            if (cart == null || !cart.CartItems.Any())
//                return BadRequest("Cart is empty");

//            var order = new Order
//            {
//                UserId = userId,
//                OrderDate = DateTime.Now,
//                Status = "Pending",
//                ShippingAddress = orderData.ShippingAddress,
//                PhoneNumber = orderData.PhoneNumber,
//                Notes = orderData.Notes,
//                TotalAmount = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity),
//                OrderItems = new List<OrderItem>()
//            };

//            foreach (var ci in cart.CartItems)
//            {
//                order.OrderItems.Add(new OrderItem
//                {
//                    ProductId = ci.ProductId,
//                    Quantity = ci.Quantity,
//                    PriceAtPurchase = ci.Product.Price
//                });
//            }

//            _orderRepo.Add(order);
//            _orderRepo.Save();

//            return View("Details", order);
//        }

//        // ✅ حذف طلب
//        public IActionResult Delete(int id)
//        {
//            var order = _orderRepo.GetById(id);
//            if (order == null)
//                return NotFound();

//            _orderRepo.Delete(order);
//            _orderRepo.Save();

//            var orders = _orderRepo.GetAll();
//            return View("Index", orders); // ✅ بعد الحذف يرجع للـ Index بالطلبات
//        }
//    }
//}