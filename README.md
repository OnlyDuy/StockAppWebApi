# StockAppWebApi
Xây dựng Backend ứng dụng chứng khoán với ASP .NET Core 7 Api và Websocket:
- Cài đặt dotnet 7 SDK, Visual Studio và VS Code
- Tạo dự án asp .net core api mới, tìm hiểu về cơ sở dữ liệu chứng khoán
- Tìm hiểu flow app, mô hình client-server, restful API
- Cài đặt Docker, dựng Database chứng khoán và dữ liệu Fake, cài Azure Data Studio, python
- Tạo model trong ASP .NET Core cho bảng users, validate dữ liệu
- Thêm Repository để lấy dữ liệu từ Database thông qua Model. Services gọi Repositories
- Thêm controller và các action trong Controller, cài Entity Framework Core
- Dựng Docker container chứa SQL Server và kết nối từ ASP .net core với SQL Server
- Dependency Injection trong ASP .NET Core Web API
- Gửi dữ liệu từ Postman lên Server qua ViewModel, viết api Register User
- Gọi Procedure trong SQL Server từ ứng dụng .net core api
- JWT - Json Web Token, chức năng login và lấy token
- Viết JwtAttribute kiểm tra token cho một số request yêu cầu đăng nhập
- Tạo request WatchList và thêm WatchList có kiểm tra token
- Làm việc với WebSocket lấy thông tin chứng khoán real-time
- Lấy dữ liệu 1 cố phiếu nào đó trong thời gian 3 ngày, 7 ngày, 30 ngày
- Xử lý nghiệp vụ phần đặt lệnh(Order)
- Lấy thông tin Covered Warrants theo tài sản cơ bản - underlying asset
