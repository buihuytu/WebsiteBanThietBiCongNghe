$(function () {
    $('#buy-now').on('click', function (e) {
        e.preventDefault();

        $.ajax({
            url: '/Cart/Add',
            type: 'POST',
            data: {
                pid: $(this).data('id'),
                qty: 1
            },
            dataType: 'json',
            success: function (response) {
                if (response.result == 1) {
                    // Load giỏ hàng tại header
                    $('.items-cart').text(parseInt($('.items-cart').text()) + 1);
                    alert("Đã thêm sản phẩm vào giỏ hàng");

                } else if (response.result == 2) {
                    // Load giỏ hàng tại header
                    alert("Đã cập nhật lại số lượng sản phẩm trong giỏ hàng");
                }
            }
        })
    })
})

$(function () {
    $('.update').on('click', function (e) {
        e.preventDefault();

        $.ajax({
            url:"/Cart/Update",
            type: 'POST',
            data: { pid: $(this).data('id'), option: $(this).data('options') },
            dataType: 'json',
            success: function (res) {
                if (res == 1 || res == 2) {
                    $('#checkout').load('/Module/ICart');
                    return;
                } else if (res == 3) {
                    $('#checkout').load('/Module/ICart');
                    return;
                }
            }
        })
    })
})

$(document).ready(function () {
    $('.checkAuth').click(function (e) {
        alert("click")
        e.preventDefault();
        $.ajax({
            url: "/Cart/CheckAuth",
            type: 'POST',
            success: function (response) {
                if (response == 1) {
                    // chuyển hướng tới trang thanh toán 
                    window.location.href = "Checkout";
                } else {
                    // Thông báo yêu cầu đăng nhập để tiếp tục
                    alert("Vui lòng đăng nhập để tiếp tục");
                }
            }
        });
    });
});

function validateForm() {
    if ($('#email').val() == null || $('#email').val() == '') {
        alert('Vui lòng nhập email!');
        return false;
    } else if (($('#address').val().trim() == null || $('#address').val().trim() == '')) {
        alert('Vui lòng nhập địa chỉ nhận hàng!');
        return false;
    } else if (($('#phone').val().trim() == null || $('#phone').val().trim() == '')) {
        alert('Vui lòng nhập số điện thoại nhận hàng!');
        return false;
    }
    return true;
}

$(document).ready(function () {
    $('#thanh-toan').click(function (e) {
        e.preventDefault();
        if ($('#email').val() == null || $('#email').val() == '') {
            Swal.fire('Vui lòng nhập email!');
            return false;
        } else if (($('#address').val().trim() == null || $('#address').val().trim() == '')) {
            Swal.fire('Vui lòng nhập địa chỉ nhân hàng!');
            return false;
        } else if (($('#phone').val().trim() == null || $('#phone').val().trim() == '')) {
            alert('Vui lòng nhập số điện thoại nhận hàng!');
            return false;
        }
        $.ajax({
            url: "/Cart/Checkauth",
            type: 'POST',
            success: function (f) {
                if (f.f == 0) {
                    WIYN();
                } else {
                    $.ajax({
                        url: "/Cart/Payment",
                        type: 'POST',
                        data: {
                            Email: $('input[name=Email]').val(),
                            Phone: $('input[name=Phone]').val(),
                            Address: $('input[name=Address]').val(),
                            FullName: $('input[name=FullName]').val(),
                        },
                        dataType: 'json',
                        success: function (pig) {
                            if (!pig) {
                                console.log(pig);
                            } else {
                                window.location.href = "/Site/Home";
                            }
                        }
                    })
                }
            }
        })
    })
});