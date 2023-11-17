var swiper = new Swiper('.swiper-container', {
    slidesPerView: 1,
    spaceBetween: 30,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },
    autoplay: {
        delay: 3000, 
        disableOnInteraction: false, 
    }
});
var swiperSS = new Swiper('.swiper-container.image', {
    slidesPerView: 1,
    spaceBetween: 30,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});
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

function HandleChangePage(total, pageSize, idBtn) {

    let eBtn1 = document.getElementById("btnPage1");
    let eBtn2 = document.getElementById("btnPage2");
    let eBtn3 = document.getElementById("btnPage3");
    let btnValue = document.getElementById(idBtn);
    let maxPageValue = (total / pageSize);

    document.getElementById("input-PageValue").setAttribute("value", btnValue.textContent);
    RemoveActivePage();
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
function HandleChangePageTC(total, pageSize, idBtn) {
    let eBtn1 = document.getElementById("btnPage1");
    let eBtn2 = document.getElementById("btnPage2");
    let eBtn3 = document.getElementById("btnPage3");
    let btnValue = document.getElementById(idBtn);
    let maxPageValue = (total / pageSize);
    document.getElementById("input-PageValue").setAttribute("value", btnValue.textContent);
    RemoveActivePage();
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
function ChangePage(total, pageSize, id, username, passwd, idfunction) {
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
function ChangePageTC(total, pageSize, idBtn,functionName,url) {
    var str = '';
    let ePageValue = document.getElementById("input-PageValue");
    HandleChangePageTC(total, pageSize, idBtn);

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: `http://nhipcautamgiao.net/ww2/module.${functionName}.trangchu.asp?url=${url} &pageid=`+ePageValue.value,
        success: (response) => {
            for (var i = 0; i < response[0].data.length; i++) {
                str += `<div class="tintuc">
                                                    <div class="wrap-ndct">
                                                        <div class="ct">
                                                                <div class="ngdang">${response[0].data[i].ngaydang}</div>
                                                                <h3>
                                                                    <a href="/Home/ChiTietTinTuc?keyword=${response[0].data[i].url}">
                                                                        ${response[0].data[i].tieude}
                                                                    </a>
                                                                </h3>
                                                                <div class="ttct">
                                                                    ${response[0].data[i].noidungtomtat}
                                                                </div>
                                                        </div>
                                                    </div>
                                                </div>`;
            }
            document.getElementById("phantrang").innerHTML = str;
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
    window.addEventListener("scroll", function () {
        if (window.scrollY > 300) {
            backToTopButton.style.display = "block";
        } else {
            backToTopButton.style.display = "none";
        }
    });


    backToTopButton.addEventListener("click", function () {
        window.scrollTo({
            top: 0,
            behavior: "smooth" 
        });
    });
});
document.addEventListener('DOMContentLoaded', function () {
    var myCarousels = new bootstrap.Carousel(document.getElementById('myCarousel'));
    setInterval(function () {
        myCarousel.next();
    }, 3000);
});
