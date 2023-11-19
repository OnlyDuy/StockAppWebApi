using Microsoft.AspNetCore.Mvc;
using StockAppWebApiVS.Services;
using StockAppWebApiVS.Attributes;
using StockAppWebApiVS.Extensions;
using StockAppWebApiVS.ViewModels;

namespace StockAppWebApiVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public OrderController(
            IOrderService orderService,
            IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }
        [HttpPost("place_order")]
        [JwtAuthorize]
        public async Task<IActionResult> PlaceOrder(OrderViewModel orderViewModel)
        {
            // Lấy UserId từ context
            int userId = HttpContext.GetUserId();
            // Kiểm tra người dùng và cổ phiếu tồn tại
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            orderViewModel.UserId = userId;
            var createdOrder = await _orderService.PlaceOrder(orderViewModel);
            return Ok(createdOrder);
        }

    }
}
