function InsertDataContentTab(functionName, id, idpart) {
    let e = document.getElementById(functionName + "-" + id);
    let str = "";
    let urlApi = `http://nhipcautamgiao.net/ww2/module.${functionName}.trangchu.asp?id=${idpart}`;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: urlApi,
        success: (response) => {
            let SiteNameImage = "http://nhipcautamgiao.net:7787";
            for (var i = 0; i < response[0].data.length; i++) {
                srcImg = SiteNameImage + response[0].data[i].hinhdaidien;
                str += `<div style="width:calc(30% - 2px);margin:5px" class="tintuc">
                                                                                <div class="wrap-ndct">
                                                                                    <div class="hinh">
                                                                                        <a href="/Home/ChiTietTinTuc?keyword=${response[0].data[i].url}">
                                                                                            <img class="border" src="${srcImg}" alt="">
                                                                                        </a>
                                                                                    </div>
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
            e.innerHTML = str;
        },
        error: (e) => { }
    })
}
function InsertDataSlider(functionName, functionModule, id, idPart) {
    let key = functionModule + "-" + id;
    let eSelect = document.querySelector(".form-select.noidungtab." + key);
    let eWrapper = document.querySelector(".swiper-wrapper." + key);
    let strSelects = "";
    let strSliders = "";
    let urlApi = `http://nhipcautamgiao.net/ww2/module.${functionName}.trangchu.asp?id=${idPart}`;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: urlApi,
        success: (response) => {
            let SiteNameImage = "http://nhipcautamgiao.net:7787";
            for (var i = 0; i < response[0].data.length; i++) {
                srcImg = SiteNameImage + response[0].data[i].hinhdaidien;
                strSelects += `<option value="/Home/ChiTietTinTuc?keyword=${response[0].data[i].url}" selected="">${response[0].data[i].tieude}</option> `;
                strSliders += `<div class="swiper-slide image" role="group" aria-label="${i+1} / 20" style="width: 546px; margin-right: 30px;">
                    <img src="${srcImg}" alt="">
                    <div class="content">           
                        <p>${response[0].data[i].tieude}</p>
                    </div>
                </div>     `;
            }
            eSelect.innerHTML = strSelects;
            eWrapper.innerHTML = strSliders;
        },
        error: (e) => { }
    })
}


