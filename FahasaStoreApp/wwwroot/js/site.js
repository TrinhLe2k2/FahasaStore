
const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

const RenderPartialView = (url, elementId) => {
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            $('#' + elementId).html(data);
        },
        error: function () {
            console.log("Error render for elementId = " + elementId);
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
        url: `/Home/TopSellingBooksByCategory/${categoryId}`,
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