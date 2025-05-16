using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using hoolsitebiydaalt.Data;
using hoolsitebiydaalt.Models;

namespace hoolsitebiydaalt.Controllers
{
    [Authorize]  // зөвхөн нэвтэрсэн хэрэглэгчид зөвшөөрнө
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Хэрэглэгчийн сагсыг үзэх
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Food)
                .FirstOrDefaultAsync(c => c.UserName == userName);

            if (cart == null)
            {
                cart = new Cart { UserName = userName };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            ViewBag.TotalPrice = cart.CartItems.Sum(ci => ci.Food.Price * ci.Quantity);

            return View(cart);
        }

        // Сагсанд хоол нэмэх
        [HttpPost]
        public async Task<IActionResult> AddToCart(int foodId)
        {
            var food = await _context.Food.FindAsync(foodId);
            if (food == null)
            {
                return NotFound();
            }

            var userName = User.Identity.Name;
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserName == userName);

            if (cart == null)
            {
                cart = new Cart { UserName = userName };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.FoodId == foodId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = cart.Id,
                    FoodId = food.Id,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
                _context.CartItems.Update(cartItem);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Сагснаас хоол устгах
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
