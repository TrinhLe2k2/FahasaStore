
const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

//const RenderPartialView = (url, elementId) => {
//    $.ajax({
//        url: url,
//        type: 'GET',
//        success: function (data) {
//            $('#' + elementId).html(data);
//        },
//        error: function () {
//            alert("Error render for elementId = " + elementId);
//        }
//    });
//}

function RenderPartialView(formId, renderINId) {
    const $form = $('#' + formId);
    const formData = $form.serializeArray();

    var htmlSpinner = '<div class="position-fixed d-flex justify-content-center align-items-center bg-light top-0 bottom-0 start-0 end-0 opacity-25"> <div class="spinner-border" role="status"> <span class="visually-hidden">Loading...</span> </div> </div>';
    $('#' + renderINId).html(htmlSpinner);

    $.ajax({
        url: $form.attr('action'),
        type: $form.attr('method'),
        data: formData,
        success: function (html) {
            $('#' + renderINId).html(html);
        },
        error: function (xhr, status, error) {
            alert("error RenderPartialView" + formId);
        }
    });
}

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

const HandlerCRUD = (e, event) => {
    event.preventDefault();
    let href = $(e).attr("href");
    //let id = $(e).attr("IdValue");
    //if (id) {
    //    href = `${href}/${id}`;
    //}
    $.ajax({
        url: href,
        type: 'GET',
        success: function (data) {
            $('#modal-for-crud').html(data);
        },
        error: function () {
            alert("modal-for-crud: " + href);
        }
    });
}