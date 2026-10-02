/* ========================================================
   PQCLession13 - Custom JavaScript theo hướng dẫn Slide 19 - 21
   Tác giả: Phùng Quang Cường (2410900015)
   ======================================================== */

document.addEventListener("DOMContentLoaded", function () {
    console.log("PQCLession13 Custom JS Initialized - PQC Layout Demo");

    // Xử lý Slide 21: Link nào được click thì link đó có màu active tương ứng
    const navLinks = document.querySelectorAll(".pqc-nav-link, .pqc-sidebar-link");
    const currentUrl = window.location.pathname.toLowerCase();

    navLinks.forEach(function (link) {
        // Tự động kiểm tra URL hiện tại để kích hoạt class active
        const href = link.getAttribute("href");
        if (href && (href.toLowerCase() === currentUrl || (currentUrl.endsWith("/") && href.toLowerCase() === currentUrl.slice(0, -1)))) {
            link.classList.add("active");
        }

        // Sự kiện click chuyển màu ngay lập tức trên UI (slide 21)
        link.addEventListener("click", function () {
            navLinks.forEach(function (other) {
                other.classList.remove("pqc-clicked");
            });
            this.classList.add("pqc-clicked");
        });
    });

    // Thông báo Toast nhỏ khi thực hiện hành động demo
    window.pqcShowToast = function (message, type = "info") {
        const toast = document.createElement("div");
        toast.className = `alert alert-${type} shadow-lg position-fixed top-0 end-0 m-3`;
        toast.style.zIndex = "9999";
        toast.style.minWidth = "260px";
        toast.innerHTML = `<strong>PQC Thông báo:</strong> ${message}`;
        document.body.appendChild(toast);

        setTimeout(() => {
            toast.style.transition = "opacity 0.5s ease";
            toast.style.opacity = "0";
            setTimeout(() => toast.remove(), 500);
        }, 2500);
    };

    // Gán nút demo tương tác nếu có
    const demoButtons = document.querySelectorAll("[data-pqc-action]");
    demoButtons.forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            const action = this.getAttribute("data-pqc-action");
            window.pqcShowToast(`Bạn vừa chọn thao tác: [${action}]`, "success");
        });
    });
});
