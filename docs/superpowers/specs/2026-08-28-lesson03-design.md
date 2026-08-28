# Thiết kế Lesson 3 ASP.NET Core MVC

## Mục tiêu

Tạo project `PQClession3` dựa trên cấu trúc giảng dạy của `TvcLesson03`, nhưng thay toàn bộ dấu hiệu nhận diện của tác giả mẫu bằng thông tin của sinh viên Phùng Quang Cường và thay dữ liệu linh kiện máy tính bằng danh mục điện thoại, phụ kiện di động.

Project minh họa ba cách đưa một danh sách sản phẩm ra khỏi Controller:

1. Trả trực tiếp dưới dạng JSON.
2. Truyền qua `ViewData` rồi ép kiểu trong Razor View.
3. Truyền bằng strongly typed Model.

## Phạm vi

- Thêm một project ASP.NET Core MVC mới tại `PQClession3`.
- Giữ nguyên các project Lesson 1, Lesson 2 và MVC hiện có.
- Dùng `.NET 10`, nullable reference types và implicit usings.
- Không thêm cơ sở dữ liệu, xác thực hay CRUD thật vì nằm ngoài nội dung buổi 3.
- Thêm project, commit và push lên nhánh `main` của repository hiện tại sau khi kiểm tra thành công.

## Định danh

- Project và namespace: `PQClession3`.
- Model: `PQCProduct`.
- Controller: `PQCProductController`.
- Sinh viên: Phùng Quang Cường.
- Mã sinh viên: `2410900015`.
- Lớp: `K24CNT1`.
- Học phần: Phát triển ứng dụng WEB với công nghệ .NET.

Mọi chuỗi, namespace, tên lớp, action, view và đường dẫn có tiền tố `Tvc` trong mẫu phải được đổi sang `PQC` hoặc `PQClession3` tương ứng.

## Cấu trúc và luồng dữ liệu

`PQCProduct` chứa mã, tên, năm phát hành và giá. `PQCProductController` giữ một danh sách mock gồm 10 điện thoại hoặc phụ kiện, mã từ `PQC-001` đến `PQC-010`, tên và giá khác hoàn toàn dữ liệu mẫu.

Controller cung cấp ba action:

- `Index()` trả danh sách bằng `Json(...)`.
- `PQCGetAllProduct()` đặt danh sách vào `ViewData["products"]`.
- `PQCGetListProduct()` truyền danh sách trực tiếp vào `View(...)` để Razor nhận bằng `@model`.

Hai Razor View hiển thị cùng một danh sách dưới dạng bảng Bootstrap để người học so sánh `ViewData` với strongly typed Model. Giá được định dạng theo VNĐ, cuối bảng có tổng số sản phẩm, còn Xem/Sửa/Xóa chỉ là liên kết minh họa.

## Giao diện

Trang Home giới thiệu Lesson 3 và tên sinh viên. Trang Privacy hiển thị họ tên, mã sinh viên, lớp và học phần. Layout mang thương hiệu `PQClession3` và có liên kết tới hai cách hiển thị danh sách sản phẩm.

## Xử lý lỗi và an toàn kiểu

- Các thuộc tính chuỗi của model được khởi tạo để tránh cảnh báo nullable.
- View dùng `ViewData` kiểm tra kết quả ép kiểu trước khi lặp.
- Strongly typed View khai báo đúng `List<PQCProduct>`.
- Giữ trang lỗi mặc định của ASP.NET Core MVC.

## Kiểm tra chấp nhận

1. `dotnet build` project thành công, không có lỗi hay cảnh báo.
2. Endpoint JSON trả đủ 10 sản phẩm.
3. Hai endpoint Razor trả HTTP 200, hiển thị đủ danh sách và tổng số sản phẩm.
4. Không còn `Tvc`, Trịnh Văn Chung hoặc sản phẩm linh kiện máy tính của mẫu trong source Lesson 3.
5. Git chỉ đưa project `PQClession3` và tài liệu thiết kế liên quan vào commit Lesson 3.
6. Commit trên máy khớp với `origin/main` sau khi push.
