
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;

namespace StockAppWebApiVS.Controllers
{
    [Route("api/ws")]
    public class WebSocketController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                // Kiểm tra có WebSocket nếu có thì tực thi tiếp
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                // Sinh ngẫu nhiên giá trị x, y thay đổi 2s một lần
                var random = new Random();
                while (webSocket.State == WebSocketState.Open)
                {
                    // Tạo giá trị x, y ngẫu nhiên
                    int x = random.Next(1, 100);
                    int y = random.Next(1, 100);
                    var buffer = Encoding.UTF8.GetBytes($"{{ \"x\": {x}, \"y\": {y} }}");
                    Console.WriteLine($"x : {x}, y: {y}");
                    await webSocket.SendAsync(
                        new ArraySegment<byte>(buffer),
                        WebSocketMessageType.Text, true, CancellationToken.None);
                    await Task.Delay(2000); // Đợi 2 giây trước khi gửi giá trị tiếp theo
                }
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                            "Connection closed by the server", CancellationToken.None);
            } else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
