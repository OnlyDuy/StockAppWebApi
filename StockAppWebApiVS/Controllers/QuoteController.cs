using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text;
using StockAppWebApiVS.Services;
using StockAppWebApiVS.Models;

namespace StockAppWebApiVS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        public QuoteController (IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("ws")]
        //https://localhost:7064/api/quote/ws
        public async Task GetRealtimeQuotes(
            int page = 1, 
            int limit = 10,
            string sector = "",
            string industry = ""
            )
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                //await _webSocketManager.AddWebSocket(webSocket);
                while (webSocket.State == WebSocketState.Open)
                {
                    // lấy dữ liệu realtime dươi service, service gọi repository
                    List<RealtimeQuote>? quotes = await _quoteService
                                                    .GetRealtimeQuotes(page, limit, sector, industry);
                    //convert list of objects to json
                    string jsonString = JsonSerializer.Serialize(quotes);
                    var buffer = Encoding.UTF8.GetBytes(jsonString);
                    // Gửi ngược dữ liệu từ server trở về client
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer),
                        WebSocketMessageType.Text, true, CancellationToken.None);

                    await Task.Delay(2000); // Đợi 2 giây trước khi gửi giá trị tiếp theo
                }
            }
            else
            {

            }
        }
    }
}
