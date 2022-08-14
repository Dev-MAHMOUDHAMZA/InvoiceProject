
let ddlCategoryId = document.getElementById("ddlCategoryId");
let ddlProduct = document.getElementById("ddlProduct");
let quntity = document.getElementById("quntity");
let price = document.getElementById("price");


//Retuer Product Where CategoryId

ShowProduct = () => {
    if ($('#ddlCategoryId').val() == "") {
        $('#ddlProduct').html(`<option value="">اختر نوع الفئة</option>`);
    }
    else {

        $.ajax({
            url: `/Home/GetProduct/${ddlCategoryId.value}`,
            method: 'GET',
            cache: false,
            success: (data) => {

                let Product = '';
                Product += `<option value="">أختر المنتج .....</option>`;
                for (x in data) {

                    Product += `<option value="${data[x].productId}">${data[x].productName}</option>`;
                }
                $('#ddlProduct').html(Product);
            }
        });
    }
   

}

ShowPrice = () => {
    $.ajax({
        url: `/Home/GetPriceProduct/${$('#ddlProduct').val()}`,
        method: 'GET',
        cache: false,
        success: (data) => {
           
            $('#price').val(data.price);
        }
    });
}

SavaPrducts = () => {

    let objPrduct = {

        CategoryId: ddlCategoryId.value,
        ProductId: ddlProduct.value,
        Price: price.value,
        Quntity: quntity.value,
        Total: price.value * quntity.value
    };
    let data = JSON.stringify(objPrduct);
    $.ajax({
        url: '/api/APIInvoice',
        method: 'POST',
        contentType: 'application/json',
        data: data,
        cache: false,
        success: (data) => {
            //alert('Sava Data');
            ResetData();
            ShowTable();
            GetTotal();
        }

    });

};

ResetData = () => {
    ddlCategoryId.value = '';
    ddlProduct.value = '';
    quntity.value = 1;
    price.value = 0;
};

ShowTable = () => {

    $.ajax({

        url: '/api/APIInvoice',
        method: 'GET',
        cache: false,
        success: (data) => {

            let Table = '';

            for (x in data) {

                Table += `
                  <tr>
                    <td>#</td>
                    <td>${data[x].category.categoryName}</td>
                    <td>${data[x].product.productName}</td>
                    <td>${data[x].price}</td>
                    <td>${data[x].quntity}</td>
                    <td>${data[x].total}</td>
                    <td><a class="btn btn-danger" onclick="DeleteProduct(${data[x].invoiceId})" style="color:#ffff"><i class="fa fa-trash"></i></a></td>
                </tr>`;
            }
            $('#tablebody').html(Table);
        }
    });

};

DeleteProduct = (id) => {
    if (confirm('هل انت متأكد من الحذف؟؟؟؟؟؟') == true) {
        $.ajax({
            url: `/api/APIInvoice/${id}`,
            method: 'DELETE',
            cache: false,
            success: () => {
                alert('تم الحذف بنجاح');
                ShowTable();
                GetTotal();
            }
        });
    }
    

};

GetTotal = () => {

    $.ajax({
        url: `/api/APIInvoice/GetAllTotal`,
        method: 'GET',
        cache: false,
        success: (data) => {
            $('#allTotal').val(data);
            $('#afterDescount').val(data);

        }
    });

};

Discount = () => {

    $('#afterDescount').val($('#allTotal').val() - $('#discount').val());
};

document.getElementById("discount").addEventListener('change', Discount);
document.getElementById("discount").addEventListener('keyup', Discount);

$(document).ready(()=>{
    ShowTable();
    GetTotal();
});

