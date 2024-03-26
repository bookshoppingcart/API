using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShopingCart_API.Controllers
{
    [Authorize]
    public class UserOrderController : ControllerBase
    {
        private readonly IUserOrderRepository _userOrderRepo;

        public UserOrderController(IUserOrderRepository userOrderRepo)
        {
            _userOrderRepo = userOrderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> UserOrders()
        {
            var orders = await _userOrderRepo.UserOrders();
            if (null == orders) return NotFound();

            return Ok(orders);
        }
    }
}