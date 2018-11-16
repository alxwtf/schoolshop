function addtocart(ProdId) {
    var xhr = new XMLHttpRequest();
    var orderId = document.getElementById('orderid').value;
    xhr.open("GET", "/test/Confirm?ProdId=" + ProdId +"&id="+orderId, true);
    xhr.send();
    xhr.onload = function () {
        if (JSON.parse(xhr.response)) {
            $('#modalWindow').arcticmodal();
            $('#answer').remove();
        }
    };
}

function pay(OrderId) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/order/Pay?id=" + OrderId, true);
    xhr.send();
    xhr.onload = function () {
        if (JSON.parse(xhr.response)) {
            $('#table_' + OrderId).remove();
        }
    }
}