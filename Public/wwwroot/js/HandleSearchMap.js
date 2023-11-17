var nameState = '';
var nameDistrict = '';
var nameWard = '';

var idState = '';
var idDistrict = '';
var idWard = '';
function GetState() {
    let str = '';
    ClearDataInput();
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'http://thegioitainang.com/ww2/dialy.tinhthanh.asp',
        success: (response) => {
            for (var i = 0; i < response.length; i++) {
                str += `<option onclick="GetDistrict(${response[i].id})" data-bs-target="#districtModalToggle" data-bs-toggle="modal" value="${response[i].id}">${response[i].ten} </option>`;
            }
            document.querySelector(".form-select.state").innerHTML = str;
        },
        error: (e) => { }
    })
}
function GetDistrict(id) {
    InsertValueState();
    let str = '';
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'http://thegioitainang.com/ww2/dialy.quanhuyen.asp?id='+id,
        success: (response) => {
            for (var i = 0; i < response.length; i++) {
                str += `<option onclick="GetWard(${response[i].id})" data-bs-target="#wardModalToggle" data-bs-toggle="modal" value="${response[i].id}">${response[i].ten} </option>`;
            }
            document.querySelector(".form-select.district").innerHTML = str;
        },
        error: (e) => { }
    })
}
function GetWard(id) {
    InsertValueDistrict();
    let str = '';
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'http://thegioitainang.com/ww2/dialy.phuongxa.asp?id=' + id,
        success: (response) => {
            for (var i = 0; i < response.length; i++) {
                str += `<option onclick="InsertValueWard()" data-bs-dismiss="modal" value="${response[i].id}">${response[i].ten} </option>`;
            }
            document.querySelector(".form-select.ward").innerHTML = str;
        },
        error: (e) => { }
    })
}
function InsertDataToInput() {
    let e = document.querySelector(".item.item-city input");
    let eId = document.getElementById("input-arr-id-address");
    let stringResult = nameState + nameDistrict + nameWard;
    let arrIdResult = idState + idDistrict + idWard;

    eId.setAttribute("value", arrIdResult);
    e.setAttribute("value", stringResult);
}
function InsertValueState() {
    let state = document.getElementById("selected-state");
    let stateName = state.options[state.selectedIndex].text;
    nameState = stateName;
    idState = state.value;
    InsertDataToInput();
}
function InsertValueDistrict() {
    let district = document.getElementById("selected-district");
    let districtName = "," + district.options[district.selectedIndex].text;
    nameDistrict = districtName;
    idDistrict = "," + district.value;
    InsertDataToInput();
}
function InsertValueWard() {
    let ward = document.getElementById("selected-ward");
    let wardName = "," + ward.options[ward.selectedIndex].text;
    nameWard = wardName;
    idWard = "," + ward.value;
    InsertDataToInput();
}
function ClearDataInput() {
    let eId = document.getElementById("input-arr-id-address");
    let e = document.getElementById("input-str-address");
    eId.setAttribute("value", "");   
    e.setAttribute("value", "");

    nameState = '';
    nameDistrict = '';
    nameWard = '';

    idState = '';
    idDistrict = '';
    idWard = '';
}
function RemoveState() {
    let e = document.getElementById("input-str-address");
    let eId = document.getElementById("input-arr-id-address");
    e.setAttribute("value", "");
    eId.setAttribute("value", "");

    nameState = '';
    nameDistrict = '';
    nameWard = '';
    idState = '';
    idDistrict = '';
    idWard = '';
}
function RemoveDistrict() {
    let e = document.getElementById("input-str-address");
    let eId = document.getElementById("input-arr-id-address");

    nameDistrict = '';
    nameWard = '';
    e.setAttribute("value", nameState);
    eId.setAttribute("value", idState);
}
function RemoveWard() {
    let e = document.getElementById("input-str-address");
    let eId = document.getElementById("input-arr-id-address");

    let stringResult = nameState + nameDistrict;
    let stringId = idState + idDistrict;

    nameDistrict = '';
    nameWard = '';
    idDistrict = '';
    idWard = '';

    e.setAttribute("value", stringResult);
}