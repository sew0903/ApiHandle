﻿
var swiper = new Swiper('.swiper-container', {
    // Cấu hình Swiper ở đây
    slidesPerView: 3,
    spaceBetween: 30,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },
    autoplay: {
        delay: 3000, // Thời gian trễ (milliseconds) giữa các slide
        disableOnInteraction: false, // Tắt tự động lướt khi người dùng tương tác
    }
});

// Hiển thị hiệu ứng chờ loading

// Ẩn hiệu ứng chờ loading
function hideLoading() {
    document.getElementById("loading-container").style.display = "none";
}
function ShowGroupBl() {
    var e = document.getElementById("group-bl");
    e.style.display = "flex";
}

function RemoveActivePage() {
    document.getElementById("btnPage1").classList.remove("page-active");
    document.getElementById("btnPage2").classList.remove("page-active");
    document.getElementById("btnPage3").classList.remove("page-active");
}

function HandleChangePage(total,pageSize,idBtn) {

    let eBtn1 = document.getElementById("btnPage1");
    let eBtn2 = document.getElementById("btnPage2");
    let eBtn3 = document.getElementById("btnPage3");
    let btnValue = document.getElementById(idBtn);
    let maxPageValue = (total / pageSize);

    document.getElementById("input-PageValue").setAttribute("value", btnValue.textContent);
    RemoveActivePage();
    //handleChangePageNum
    if (idBtn == "btnPage1" && parseInt(btnValue.textContent) > 1) {
        eBtn2.textContent = document.getElementById(idBtn).textContent;
        eBtn3.textContent = parseInt(document.getElementById(idBtn).textContent) + 1;
        eBtn1.textContent = parseInt(document.getElementById("btnPage3").textContent) - 2;
        document.getElementById("btnPage2").classList.add("page-active");
    }
    else if (idBtn == "btnPage3" && parseInt(btnValue.textContent) < maxPageValue) {
        eBtn2.textContent = document.getElementById(idBtn).textContent;
        eBtn3.textContent = parseInt(document.getElementById(idBtn).textContent) + 1;
        eBtn1.textContent = parseInt(document.getElementById(idBtn).textContent) - 2;
        document.getElementById("btnPage2").classList.add("page-active");
    } else {
        document.getElementById(idBtn).classList.add("page-active");
    }
}
function ChangePage(total, pageSize, id,username,passwd,idfunction) {
    var str = '';
    let ePageValue = document.getElementById("input-PageValue");
    HandleChangePage(total, pageSize, id);

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: `http://thegioitainang.com/ww1/member.1/ThongBaoCongViec.asp?userid=${username}&pass=${passwd}&id=${idfunction}&pageid=` + ePageValue.value,
        success: (response) => {
            for (var i = 0; i < response[0].data.length; i++) {
                str += `<tr><td><a href="/${response[0].data[i].url}"style="cursor: pointer;">${response[0].data[i].tieude}</a></td><td>${response[0].data[i].diachiND}</td><td>${response[0].data[i].thoigian}</td></tr>`;
            }
            document.getElementById("tbody-phantrang-tbcv").innerHTML = str;
            window.scrollTo({
                top: 0,
                behavior: 'smooth' 
            });

        },
        error: (e) => { }
    })
}
document.addEventListener("DOMContentLoaded", function () {
    const backToTopButton = document.getElementById("backToTopButton");

    // Lắng nghe sự kiện cuộn trang
    window.addEventListener("scroll", function () {
        // Hiển thị hoặc ẩn nút khi người dùng cuộn trang
        if (window.scrollY > 300) {
            backToTopButton.style.display = "block";
        } else {
            backToTopButton.style.display = "none";
        }
    });

    // Xử lý khi nút được nhấp
    backToTopButton.addEventListener("click", function () {
        window.scrollTo({
            top: 0,
            behavior: "smooth" // Tạo hiệu ứng trượt mượt
        });
    });
});