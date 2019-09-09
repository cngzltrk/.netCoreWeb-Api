// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//function faiz() {
//    var f = document.getElementById("faiz").textContent;
//    $("#fz"). = parseFloat(f).toFixed(2);
//    console.log(f);
//}
function kredi() {
    $("#tutar").attr("placeholder", "Kredi giriniz");
}
function ayKredi() {
    $("#tutar").attr("placeholder", "Tutar giriniz");
}
function ih() {
    $("#tur").attr("value", "ihtiyac");
    $.ajax({
        type: 'GET',
        url: '/Users/Ihtiyac?id=1'
    }).done(function (data) {
        console.log(JSON.parse(data));
        document.getElementById("faiz").innerHTML = JSON.parse(data).value;
        //faiz();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        //$('#value1').text(jqXHR.responseText || textStatus);
    });
}
function ko() {
    $("#tur").attr("value", "konut");
    $.ajax({
        type: 'GET',
        url: '/Users/Konut?id=2'
    }).done(function (data) {
        console.log(JSON.parse(data));
        document.getElementById("faiz").innerHTML = JSON.parse(data).value;
        //var f = document.getElementById("faiz").textContent;
        //$("#fz").attr("value", f);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        //$('#value1').text(jqXHR.responseText || textStatus);
    });
}
function ta() {
    $("#tur").attr("value", "tasıt");
    $.ajax({
        type: 'GET',
        url: '/Users/Tasit?id=3'
    }).done(function (data) {
        console.log(JSON.parse(data));
        document.getElementById("faiz").innerHTML = JSON.parse(data).value;
        //var f = document.getElementById("faiz").textContent;
        //$("#fz").attr("value", f);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        //$('#value1').text(jqXHR.responseText || textStatus);
    });
}
$("#idForm").submit(function (e) {
    e.preventDefault();
    var form = $(this);
    $.ajax({
        type: "GET",
        url: "/Home/Hesap",
        data: form.serialize(),
        success: function (data) {
            var str = data.split(" ");
            document.getElementById("topp").innerHTML = str[1];
            document.getElementById("ayy").innerHTML = str[2];

            var obj = JSON.parse(str[0]);
            $("tr:has(td)").remove();
            $.each(obj, function (i, item) {
                var $tr = $('<tr>').append(
                    $('<td>').text(item.taksitNo),
                    $('<td>').text(item.taksitTutar),
                    $('<td>').text(item.odenenFaiz),
                    $('<td>').text(item.odenenTutar),
                    $('<td>').text(item.kalanAna)

                ).appendTo("#records_table");
                //trHTML += '<tr><td>' + item[i].taksitNo + '</td><td>' + item.taksitTutar + '</td><td>' + item.odenenFaiz + '</td><td>' + item.odenenTutar + '</td><td>' + item.kalanAna + '</td></tr>';
               // $("#records_table").append(trHTML);
            });
            console.log(str[0]);
        }
    });
});
function show() {
    $("#assd").toggle()
}
$(document).ready(function () {
    $("#assd").hide();
});


