
const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

let submitTimeout;

const RenderPartialViewMethodGet = (url, elementId, event) => {
    event.preventDefault();

    $('#spinner').prop('hidden', false);

    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            $('#' + elementId).html(data);
        },
        error: function () {
            alert(`Error RenderPartialViewMethodGet for elementId = ${elementId} , url: ${url}`);
        },
        complete: function () {
            $('#spinner').prop('hidden', true);
        }
    });
}

function RenderPartialView(formId, renderINId, event) {
    event.preventDefault();

    const $form = $('#' + formId);
    const formData = $form.serializeArray();
    const url = $form.attr('action');
    $('#spinner').prop('hidden', false);

    console.log(formData);

    $.ajax({
        url: url,
        type: $form.attr('method'),
        data: formData,
        success: function (html) {
            toastr["success"](" ", "Thành Công");
            $('#' + renderINId).html(html);
        },
        error: function (xhr, status, error) {
            toastr["error"](" ", "Thất bại");
            alert(`error RenderPartialView, formId: ${formId}, action: ${url}`);
        },
        complete: function () {
            $('#spinner').prop('hidden', true);
        }
    });
}

const HandlerCRUD = (e, event) => {
    event.preventDefault();

    $('#spinner').prop('hidden', false);

    let href = $(e).attr("href");
    let id = $(e).attr("IdValue");
    if (id) {
        href = `${href}/${id}`;
    }
    $.ajax({
        url: href,
        type: 'GET',
        success: function (data) {
            $('#modal-for-crud').html(data);
        },
        error: function () {
            alert("modal-for-crud: " + href);
        },
        complete: function () {
            $('#spinner').prop('hidden', true);
        }
    });
}

// < Login, Register >
function SubmitReloadPOST(element, event) {
    event.preventDefault();
    $('#spinner').prop('hidden', false);

    var form = $(element);
    var url = form.attr('action');
    var data = form.serialize();
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (response) {
            toastr["success"](" ", "Thành Công");
            location.reload();
        },
        error: function () {
            toastr["error"](" ", "Thất bại");
            alert(`Đã có lỗi xảy ra từ form: ${url}`);
        },
        complete: function () {
            $('#spinner').prop('hidden', true);
        }
    });
}

/*Home Index*/
function initSlickSliders() {
    $('.ranking-slider-for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: false,
        fade: true,
        autoplay: true,
        autoplaySpeed: 2000,
        vertical: false,
        asNavFor: '.ranking-slider-nav'
    });
    $('.ranking-slider-nav').slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        asNavFor: '.ranking-slider-for',
        dots: false,
        arrows: false,
        focusOnSelect: true,
        vertical: true
    });
}
const HandlerBestSelling = (categoryId) => {
    //initSlickSliders();
    $.ajax({
        url: `/GetData/TopSellingBooksByCategory/${categoryId}`,
        method: 'GET',
        success: function (response) {
            $('.ranking-slider-for').slick('unslick');
            $('.ranking-slider-nav').slick('unslick');

            $(`#tab-content_rankingTab`).html(response);
            initSlickSliders();
        },
        error: function (error) {
            console.error('Erro for TopSellingBooksByCategory');
        }
    });
}
/*End home index*/

/*Login, Register*/
function ShowHide(boxPasswordId) {
    var boxParent = document.getElementById(boxPasswordId);
    if (!boxParent) return;

    var passwordField = boxParent.querySelector('input');
    var toggleButton = boxParent.querySelector('button');
    if (!passwordField || !toggleButton) return;

    var isPasswordVisible = passwordField.type === 'text';
    passwordField.type = isPasswordVisible ? 'password' : 'text';
    toggleButton.innerHTML = isPasswordVisible
        ? '<i class="bi bi-eye"></i>'  // Hiển thị biểu tượng mắt đóng
        : '<i class="bi bi-eye-slash"></i>'; // Hiển thị biểu tượng mắt mở
}
/*End login, Register*/

/*cart item*/
CheckboxHandeler();
function CheckboxHandeler() {
    $('#select-all-checkbox').on('change', function () {
        $('.cartItem-checkbox').prop('checked', $(this).prop('checked'));
        updateTotal();
        updateButtonState();
    });

    $('.cartItem-checkbox').on('change', function () {
        if ($('.cartItem-checkbox:checked').length === $('.cartItem-checkbox').length) {
            $('#select-all-checkbox').prop('checked', true);
        } else {
            $('#select-all-checkbox').prop('checked', false);
        }
        updateTotal();
        updateButtonState();
    });
}
function updateTotal() {
    let total = 0;
    $('.cartItem-checkbox:checked').each(function () {
        total += parseFloat($(this).attr('price'));
    });
    $('#total-money').text(total.toLocaleString('en-US') + ' đ');
    $('#IntoMoney').val(total);
}
function updateButtonState() {
    if ($('.cartItem-checkbox:checked').length > 0) {
        $('#buyNowBtn').prop('disabled', false);
    } else {
        $('#buyNowBtn').prop('disabled', true);
    }
}
function SubmitUpdateCartItemUser(element) {
    if (submitTimeout) {
        clearTimeout(submitTimeout);
    }
    submitTimeout = setTimeout(() => {
        $('#spinner').prop('hidden', false);
        const data = {
            Id: $(element).attr('ciId'),
            UserId: $(element).attr('ciUserId'),
            CartId: $(element).attr('ciCartId'),
            BookId: $(element).attr('ciBookId'),
            Quantity: $(element).val()
        };

        $.ajax({
            type: 'POST',
            url: '/User/UserCartItem/Edit/' + $(element).attr('ciId'),
            data: data,
            success: function (response) {
                $('#Cart').html(response);
                toastr["success"](" ", "Thành Công");
            },
            error: function (error) {
                toastr["error"](" ", "Thất bại");
                console.log('Request failed:', error);
            },
            complete: function () {
                CheckboxHandeler();
                $('#spinner').prop('hidden', true);
            }
        });
    }, 1000);
}

/*end cart item*/