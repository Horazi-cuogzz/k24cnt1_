# LabGuide06 - Thao tác dữ liệu với Entity Framework Core


--- [Trang 1] ---

LabGuide06
Bài thực hành 06
Thao tác dữ liệu với Entity Framework Core
1. Mục tiêu
● Cài đặt Entity FrameworkCore vào dự án
● Tạo model bằng phương pháp DB-First
● Tạo DB bằng phương pháp Code-First
● Các thao tác CRUD cơ bản
● Bổ sung CURD sản phẩm có upload ảnh
● Bổ sung datatype cho culumn
2. Bài thực hành Step by Step (Kế thừa các lab trước )
Bài 1: Cài đặt Entity FrameworkCore cho dự án hiện tại
Bước 1: Tạo project ASP.NET Core mới
Đặt tên là NetCoreLAB6_EF
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 2] ---

Bước 2: Click phải chuột lện thư mục dự án bên cửa sổ Explorer và chọn
đến Manage NuGet Packages *Xem hình sau )
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 3] ---

Bước 3: Tại cửa số hiện lên chọn Browse sau đó tìm Entity. Chọn
EntityFrameWorkCore, Microsoft.EntityFrameworkCore.SqlServer. Chọn
Version rồi Install
Chú ý: Chọn phiên bản >= TargetFramework
Khi cài đặt có hỏi thì chọn I Accept như hình
Sau khi cài xong kiểm tra trong thư mục Dependentcies
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 4] ---

Bài tập 2: Tạo bảng cho CSDL bằng phương pháp Code-First
Bước 1: Tạo CSDL NetCoreCRUD, mở SQL Management Studio lên và gõ lệnh tạo
Bước 2: Cấu hình kết nối tới CSDL NetCoreCRUD vừa tạo
Mở file appsettings.json và thêm chuỗi kết nối có dạng như sau đây
Chuỗi kết nối, cần có các thông tin để kết nối tới SQL server gồm
1. Server: là tên máy chủ SQL VD: localhost hoặc DESKTOP-DDT96LG\\SQL2017,
tùy vào thông tin sql serve bạn cài trên máy
2. Database: Tên CSDL cần kết nối, VD NetCoreCRUD
3. Uid là tên tài khoản đăng nhập vào, VD sa
4. Password là mật khẩu đăng nhập vào VD 12456
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 5] ---

5. MultipleActiveResultSets:True cho phép thực hiện nhiều command trên một
connect
{
"Logging": {
"LogLevel": {
"Default": "Warning"
}
},
"AllowedHosts": "*",
"ConnectionStrings": {
"AppConnection": "Server=DESKTOP- OUAQBDR;Database=NetCoreCRUD;uid=sa;pwd=123456;MultipleActiveResultSets=True;"
}
}
Bước 3: Tạo các model theo thứ tự sau đây
Chú ý: Sử dụng thuộc tính [Column] đê định nghĩa kiểu dữ liệu, cú pháp
[Column(TypeName = "kiểu dữ liệu")]
Kiể dữ liệu khai báo như quy tắc củ SQL
Model Category
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreLAB6_EF.Models
{
[Table("Category")]
public class Category
{
[Key]
public int Id { get; set; }
[Required(ErrorMessage = "Tên danh mục không được để trống")]
[StringLength(100)]
[Column(TypeName = "nvarchar(100)")]
public string Name { get; set; }
[Column(TypeName = "tinyint")]
public byte Status { get; set; }
public DateTime CreatedDate { get; set; }
// danh sách sản phẩm theo danh mục
public ICollection<Product> Products { get; set; }
}
}
Model Product
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreLAB6_EF.Models
{
[Table("Product")]
public class Product
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 6] ---

{
[Key]
public int Id { get; set; }
[Required(ErrorMessage = "Tên sản phẩm không được để trống")]
[StringLength(150,ErrorMessage = "Tên sản phẩm giới hạn 150 ký tự")]
[Column(TypeName = "nvarchar(150)")]
public string Name { get; set; }
[Column(TypeName = "varchar(150)")]
public string Image { get; set; }
[Required(ErrorMessage = "Giá sản phẩm không được để trống")]
public float Price { get; set; }
public float SalePrice { get; set; }
public byte Status { get; set; }
[StringLength(1000,ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
[Column(TypeName = "ntext")]
public string Descriptions { get; set; }
[Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
public int CategoryId { get; set; }
public DateTime CreatedDate { get; set; }
// khóa ngoại tới bảng Categoru
public Category Category { get; set; }
}
}
Bước 4: Tạo lớp AppDbContext
Trước tiên nên tạo thư mục mới đặt tên là Entities
TIếp theo tạo class AppDbContext bằng cách
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 7] ---

Click phải chuột vào thư mục Entities mới tạo và chọn Add -> Class Đặt tên là
AppDbContext (Hình sau đây là nội dung cúa Class AppDbContext )
using Microsoft.EntityFrameworkCore;
using NetCoreLAB6_EF.Models;
namespace NetCoreLAB6_EF.Data
{
public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
public DbSet<Category> Categories { get; set; }
public DbSet<Product> Products { get; set; }
}
}
Bước 5: Cấu hình kết nối CSDL trong class Startup
Mở file Program.cs lên thêm cấu hình kết nối, tham khảo code
public static void Main(string[] args)
{
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

//Cấu hình kết nối
var connectionString =
builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");
// The default HSTS value is 30 days. You may want to change this for
production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
}
}
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 8] ---

Bước 6: Mở Package Manager Console lên bằng chỉ dẫn sau
Vào Menu Tools -> NuGet Package Manager -> Package Manager Console
Xem hình sau
Ở phía dưới có cửa sô hiện lên cho phép gõ lệnh command
Bước 7: Tuần tự gõ các lệnh sau đây
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 9] ---

Nếu lệnh này thành công, thì trong dự án sẽ có thêm thư mục Migrations
Tiếp tục chạy lệnh Update-Database
Nếu lệnh này thành công, thì cấu trúc các bảng sẽ được tạo có thiết kế như sau
Các bảng được tạo
Kiểu dữ liệu các cột tương ứng với kiểu đã khai báo trong model
Sơ đồ liên kết các bảng
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 10] ---

Bài tập 3: Tạo chức năng CRUD cho bảng Category
Bước 1: Tạo CategoryController theo các thao tác sau .
Click phải chuột vào thư mục Controllers chọn Add -> Controller
Sau đó chọn template MVC Controller with views using Entity Framework
Bước 2: Tại màn hình tiếp theo chọn như sau
1. Model Class: Chọn đến model Category đã tạo ở bước 3 bài 2
2. Data context class: AppDbContext đã tạo bước 4 bài 2
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 11] ---

3. Controller name: Đặt tên là CategoriesController
Lưu ý: Phải đổi TargetFramework lên NET 7.0 và các NuGet Packages lên 7.0
Sau khi click Add đợi một lúc thì Visual Studio sẽ tạo CategoryController với đầy đủ các
Action với đủ chức năng CRUD cho bảng Category đồng thời tạo ra các view tương ứng
Category Controller tham khảo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLAB6_EF.Data;
using NetCoreLAB6_EF.Models;
namespace NetCoreLAB6_EF.Controllers
{
public class CategoriesController : Controller
{
private readonly AppDbContext _context;
public CategoriesController(AppDbContext context)
{
_context = context;
}
// GET: Categories
public async Task<IActionResult> Index()
{
return _context.Categories != null ?
View(await _context.Categories.ToListAsync()) :
Problem("Entity set 'AppDbContext.Categories' is null.");
}
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 12] ---

// GET: Categories/Details/5
public async Task<IActionResult> Details(int? id)
{
if (id == null || _context.Categories == null)
{
return NotFound();
}
var category = await _context.Categories
.FirstOrDefaultAsync(m => m.Id == id);
if (category == null)
{
return NotFound();
}
return View(category);
}
// GET: Categories/Create
public IActionResult Create()
{
return View();
}
// POST: Categories/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Name,Status,CreatedDate")] Category category)
{
if (ModelState.IsValid)
{
_context.Add(category);
await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));
}
return View(category);
}
// GET: Categories/Edit/5
public async Task<IActionResult> Edit(int? id)
{
if (id == null || _context.Categories == null)
{
return NotFound();
}
var category = await _context.Categories.FindAsync(id);
if (category == null)
{
return NotFound();
}
return View(category);
}
// POST: Categories/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,CreatedDate")] Category category)
{
if (id != category.Id)
{
return NotFound();
}
if (ModelState.IsValid)
{
try
{
_context.Update(category);
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 13] ---

await _context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException)
{
if (!CategoryExists(category.Id))
{
return NotFound();
}
else
{
throw;
}
}
return RedirectToAction(nameof(Index));
}
return View(category);
}
// GET: Categories/Delete/5
public async Task<IActionResult> Delete(int? id)
{
if (id == null || _context.Categories == null)
{
return NotFound();
}
var category = await _context.Categories
.FirstOrDefaultAsync(m => m.Id == id);
if (category == null)
{
return NotFound();
}
return View(category);
}
// POST: Categories/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
if (_context.Categories == null)
{
return Problem("Entity set 'AppDbContext.Categories' is null.");
}
var category = await _context.Categories.FindAsync(id);
if (category != null)
{
_context.Categories.Remove(category);
}

await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));
}
private bool CategoryExists(int id)
{
return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
}
}
}
Các view được tạo
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 14] ---

Bước 3: Build lại dự án sau đó truy cập link có dạng https://localhost:44375/Category
Hãy thử thực hiện các thao tác thêm sửa xóa
Màn hình Danh sách https://localhost:44375/Category
Màn hình thêm mới https://localhost:44375/Category/Create
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 15] ---

Mà hình chỉnh sửa Màn hình thêm mới https://localhost:44375/Category/ Edit/1
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 16] ---

Bước 4: Chỉnh sửa giao diện cho View trên
Mở file Views/Category/Index.cshtml và sửa lại như sau
@model IEnumerable<NetCoreLAB6_EF.Models.Category>
@{
ViewData["Title"] = "Danh sách danh mục";
}
<h2>Danh sách danh mục</h2>
<p>
<a class="btn btn-sm btn-success" asp-action="Create">Thêm mới danh mục</a>
</p>
<table class="table">
<thead>
<tr>
<th>
@Html.DisplayNameFor(model => model.Name)
</th>
<th>
@Html.DisplayNameFor(model => model.Status)
</th>
<th>
@Html.DisplayNameFor(model => model.CreatedDate)
</th>
<th></th>
</tr>
</thead>
<tbody>
@foreach (var item in Model) {
<tr>
<td>
@Html.DisplayFor(modelItem => item.Name)
</td>
<td>
@Html.DisplayFor(modelItem => item.Status)
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 17] ---

</td>
<td>
@Html.DisplayFor(modelItem => item.CreatedDate)
</td>
<td>
<a class="btn btn-sm btn-primary" asp-action="Edit" asp-route-id="@item.Id">Edit</a> |
<a class="btn btn-sm btn-success" sp-action="Details" asp-route-id="@item.Id">Details</a> |
<a class="btn btn-sm btn-danger" asp-action="Delete" asp-route-id="@item.Id">Delete</a>
</td>
</tr>
}
</tbody>
</table>
Giao diện sau khi sửa có dạng sau ( Đã thêm mới một số danh mục )
Tương tụ hãy sửa lại giao diện các view khác
Màn hình thêm mới
Chú ý: Tại các form thêm mới và chỉnh sửa, bỏ mục CreatedDate, vì mục này có thể đặt
mặc định trong lệnh thêm mới tại Controller
@model NetCoreLAB6_EF.Models.Category
@{
ViewData["Title"] = "Thêm mới danh mục";
}
<h2>Thêm mới danh mục</h2>
<hr />
<div class="row">
<div class="col-md-4">
<form asp-action="Create">
<div asp-validation-summary="ModelOnly" class="text-danger"></div>
<div class="form-group">
<label asp-for="Name" class="control-label"></label>
<input asp-for="Name" class="form-control" />
<span asp-validation-for="Name" class="text-danger"></span>
</div>
<div class="form-group">
<label asp-for="Status" class="control-label"></label>
<input asp-for="Status" class="form-control" />
<span asp-validation-for="Status" class="text-danger"></span>
</div>
<div class="form-group">
<input type="submit" value="Create" class="btn btn-sm btn-success" />
<a class="btn btn-sm btn-danger" asp-action="Index">Back to List</a>
</div>
</form>
</div>
</div>
@section Scripts {
@{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 18] ---

}
Màn hình chỉnh sửa
@model NetCoreLAB6_EF.Models.Category
@{
ViewData["Title"] = "Chỉnh sửa danh mục";
}
<h2>Chỉnh sửa danh mục</h2>
<hr />
<div class="row">
<div class="col-md-4">
<form asp-action="Edit">
<div asp-validation-summary="ModelOnly" class="text-danger"></div>
<input type="hidden" asp-for="Id" />
<div class="form-group">
<label asp-for="Name" class="control-label"></label>
<input asp-for="Name" class="form-control" />
<span asp-validation-for="Name" class="text-danger"></span>
</div>
<div class="form-group">
<label asp-for="Status" class="control-label"></label>
<input asp-for="Status" class="form-control" />
<span asp-validation-for="Status" class="text-danger"></span>
</div>
<div class="form-group">
<input type="submit" value="Cập nhật" class="btn btn-sm btn-success" />
<a class="btn btn-sm btn-danger" asp-action="Index">Back to List</a>
</div>
</form>
</div>
</div>
@section Scripts {
@{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 19] ---

Bước 5: Chỉnh lại code trong phương thức Create và Edit của CategoryController
TÌm đến phương thức Create
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Name,Status,CreatedDate")] Category category)
{
if (ModelState.IsValid)
{
category.CreatedDate = DateTime.Now;
_context.Add(category);
await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));
}
return View(category);
}
TÌm đến phương thức Edit
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,CreatedDate")] Category category)
{
if (id != category.Id)
{
return NotFound();
}
if (ModelState.IsValid)
{
try
{
category.CreatedDate = DateTime.Now;
_context.Update(category);
await _context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException)
{
if (!CategoryExists(category.Id))
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 20] ---

{
return NotFound();
}
else
{
throw;
}
}
return RedirectToAction(nameof(Index));
}
return View(category);
}
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 21] ---

BÀI TẬP TỰ LÀM
BÀI 1: Sinh viên thực hiện tương tự cho model Product, có phần upload ảnh tương tự lab
04
Các màn hình gợi ý
Màn hình danh sách sản phảm (Action Index)
Màn hình thêm mới hoặc chỉnh sửa sản phẩm (Action Create)
Code upload khi submit form thêm thêm mưới hoạc chỉnh sửa
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Product product)
{
if (ModelState.IsValid)
{
// upload file vào thư mục wwwroot/Product
var files = HttpContext.Request.Form.Files;
if (files.Count() > 0 && files[0].Length > 0)
{
var file = files[0];
var FileName = file.FileName;
var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Product", FileName);
using (var stream = new FileStream(path, FileMode.Create))
{
file.CopyTo(stream);
product.Image = FileName; // gán tên ảnh cho thuộc tinh Image
}
}
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 22] ---

_context.Add(product);
await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));
}
ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
return View(product);
}
BÀI 2: Sinh viên tạo thêm IActionResult Product cho HomeController và hiển thị dữ liệu sản
phẩm có dạng cột có dạng
BÀI 3: SInh viên tạo chức năng CRUD vơi model Banner gồm các thuộc tính
Id, Name, Image, Description, CreatedDate Status
Giao điện danh sách và các form tương tự như Product ở trên
BÀI 4: Sinh viên hãy hiển thị banner trên trang chủ của dự án
BÀI 5: Sinh viên hãy áp dụng Entity Code First tạo model và Add-Migration sao cho tạo
được mô hình quan hệ bảng của CSDL tên là StudentManager như hình dưới đây
Xem mô hình qun hệ bảng sau khi tao và tham khảo cấu trúc các bảng sau đây
Mô hình quan hệ có dạng
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 23] ---

Tham khảo câu trúc các bảng
Bảng StdClass
Tên cột Kiểu DL Ràng buộc
Id Int Khóa chính, tự tăng
CLassName nvarchar(100) Không rỗng
Bảng Student
Tên cột Kiểu DL Ràng buộc
Id Int Khóa chính, tự tăng
StudentName nvarchar(100) Không rỗng
StudentEmail nvarchar(100) Không rỗng, không trùng
StudentPhone nvarchar(50) Không rỗng, không trùng
StudentAddress nvarchar(150) Không rỗng
StudentAvatar nvarchar(100 Không rỗng
StudentBirthday Date Không rỗng
CLassId Int Không rỗng, khóa ngoại bảng StdClass
Bảng Subjects
Tên cột Kiểu DL Ràng buộc
Id Int Khóa chính, tự tăng
SubjectName nvarchar(100) Không rỗng, không trùng
Bảng Marks
https://devmaster.edu.vn Học Cùng Doanh Nghiệp


--- [Trang 24] ---

Tên cột Kiểu DL Ràng buộc
SubjectId Int Không rỗng, khóa ngoại bảng Subjects
StudentId Int Không rỗng, khóa ngoại bảng Student
Score Float Không rỗng
Khóa chính trên 2 cột (SubjectId,StudentId)
BÀI 6: Sinh viên hãy Tạo các chức năng CRUD trên các bảng trên đây
Chú ý validate dữ liệu đầy đủ phù hợp với kiểu dữ liệu và rang buộc của bảng
https://devmaster.edu.vn Học Cùng Doanh Nghiệp