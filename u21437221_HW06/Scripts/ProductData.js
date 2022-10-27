$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: "/Products/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Year + '</td>';
                html += '<td>' + item.Price + '</td>';
                html += '<td>' + item.Brand + '</td>';
                html += '<td>' + item.Category + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Name + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Name + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var newProduct = {
        Name: $('#Name').val(),
        Year: $('#Year').val(),
        Price: $('#Price').val(),
        Brand: $('#Brand').val(),
        Category: $('#Category').val(),
    };
    $.ajax({
        url: "Products/Add",
        data: JSON.stringify(newProduct),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "JSON",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Update() {
    var newProduct = {
        Name: $('#Name').val(),
        Year: $('#Year').val(),
        Price: $('#Price').val(),
        Brand: $('#Brand').val(),
        Category: $('#Category').val(),
    };
    $.ajax({
        url: "Products/Update",
        data: JSON.stringify(newProduct),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "JSON",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Name').val("");
            $('#Year').val("");
            $('#Price').val("");
            $('#Brand').val("");
            $('#Category').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "Products/Delete",
            data: JSON.stringify(newProduct),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "JSON",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#Name').val("");
    $('#Year').val("");
    $('#Price').val("");
    $('#Brand').val("");
    $('#Category').val("");
    $('#btnAdd').show();
}