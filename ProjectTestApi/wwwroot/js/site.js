var strNameMap = "";
var strIdMap = "";
function SearchClick() {
    var str = '';;
    RemoveValueState();
    RemoveValueDistrict();
    RemoveValueWards();
    document.getElementById("input-searchJob").setAttribute("value", "");
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: `http://ww2.tuyennhansu.vn/dialy.tinhthanh.asp`,
        success: (response) => {
            for (var i = 0; i < response.length; i++) {
                str += '<option onclick="GetState()" data-bs-target="#exampleModalToggle2" data-bs-toggle="modal" data-bs-dismiss="modal" value="'
                    + response[i].id
                    + '">' + response[i].ten
                    + '</option>';
            }
            document.getElementById('selected-state').innerHTML = str;
        },
        error: (e) => { }
    })
}
function GetState() {
    var str = '';
    let e = document.getElementById("selected-state");
    let text = e.options[e.selectedIndex].text;
    document.getElementById("input-state").setAttribute("value", text);
    document.getElementById("input-IdState").setAttribute("value", e.value);
    InsertNameMap();
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: `http://ww2.tuyennhansu.vn/dialy.quanhuyen.asp?id=` + e.value,
        success: (response) => {
            for (var i = 0; i < response.length; i++) {
                str += '<option onclick="GetDistrict()" data-bs-target="#exampleModalToggle3" data-bs-toggle="modal" data-bs-dismiss="modal" value="'
                    + response[i].id
                    + '">' + response[i].ten
                    + '</option>';
            }
            document.getElementById('selected-district').innerHTML = str;
        },
        error: (e) => { }
    })
}
function GetDistrict() {
    var str = '';
    let e = document.getElementById("selected-district");
    let text = "," + e.options[e.selectedIndex].text;
    document.getElementById("input-district").setAttribute("value", text);
    document.getElementById("input-IdDistrict").setAttribute("value", "," + e.value);
    InsertNameMap();
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: `http://ww2.tuyennhansu.vn/dialy.phuongxa.asp?id=` + e.value,
        success: (response) => {
            for (var i = 0; i < response.length; i++) {
                str += '<option onclick="GetWards()" data-bs-target="#exampleModalToggle3" data-bs-toggle="modal" data-bs-dismiss="modal" value="'
                    + response[i].id
                    + '">' + response[i].ten
                    + '</option>';
            }
            document.getElementById('selected-wards').innerHTML = str;
        },
        error: (e) => { }
    })
}
function GetWards() {
    let e = document.getElementById("selected-wards");
    let text = "," + e.options[e.selectedIndex].text;
    document.getElementById("input-wards").setAttribute("value", text);
    document.getElementById("input-IdWards").setAttribute("value", "," + e.value);
    InsertNameMap();
}
function InsertNameMap() {
    strNameMap = document.getElementById("input-state").value
        + document.getElementById("input-district").value
        + document.getElementById("input-wards").value;
    strIdMap = document.getElementById("input-IdState").value
        + document.getElementById("input-IdDistrict").value
        + document.getElementById("input-IdWards").value;
    document.getElementById("input-searchJob").setAttribute("value", strNameMap);
    document.getElementById("input-ArrayIdMap").setAttribute("value", strIdMap);
}

function RemoveValueState() {
    document.getElementById("input-state").setAttribute("value", "");
    document.getElementById("input-IdState").setAttribute("value", "");
}

function RemoveValueDistrict() {
    document.getElementById("input-district").setAttribute("value", "");
    document.getElementById("input-IdDistrict").setAttribute("value", "");
}
function RemoveValueWards() {
    document.getElementById("input-wards").setAttribute("value", "");
    document.getElementById("input-IdWards").setAttribute("value", "");
}

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
function showLoading() {
    document.getElementById("loading-container").style.display = "block";
}

// Ẩn hiệu ứng chờ loading
function hideLoading() {
    document.getElementById("loading-container").style.display = "none";
}
function ShowGroupBl() {
    var e = document.getElementById("group-bl");
    e.style.display = "flex";
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