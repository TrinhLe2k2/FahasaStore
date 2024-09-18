$(function () {
    AcctiveSidebar();
});

const AcctiveSidebar = () => {
    var active = $('#accordionSidebar').attr("active");
    var listNavItem = $('#accordionSidebar li.nav-item');
    listNavItem.map((index, item) => {
        if (index == active) {
            $(item).addClass("active");
            var navLink = $(item).find(".nav-link.collapsed");
            if (navLink.length > 0) {
                var urlCurrent = $('#accordionSidebar').attr("urlCurrent");
                $(navLink).removeClass("collapsed");
                $(item).find(".collapse").addClass("show");
                $(item).find(".collapse-item").filter('[href="' + urlCurrent + '"]').addClass("active");
            }
        }
    });
}

const HandlerCRUD = (e, event) => {
    event.preventDefault();
    var href = $(e).attr("href");
    var id = $(e).attr("IdValue");
    if (id) {
        href = `${href}/${id}`;
    }
    $.ajax({
        url: href,
        type: 'GET',
        success: function (data) {
            $('#modal-for-crud').html(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var errorMessage = `Error fetching data: ${jqXHR.status} ${jqXHR.statusText}`;
            if (jqXHR.responseText) {
                errorMessage += `\nResponse: ${jqXHR.responseText}`;
            }
            alert(errorMessage);
        }
    });
}

function RenderPartialView(formId, renderINId, event) {
    event.preventDefault();

    const $form = $('#' + formId);
    //const formData2 = $form.serializeArray();
    const formData = new FormData($form[0]);
    const url = $form.attr('action');
    $('#spinner').prop('hidden', false);

    console.log(formData);

    $.ajax({
        url: url,
        type: $form.attr('method'),
        data: formData,
        processData: false,
        contentType: false,
        success: function (html) {
            toastr["success"](" ", "Thành Công");
            $('#' + renderINId).html(html);
        },
        error: function (xhr, status, error) {
            toastr["error"](" ", "Thất bại");

            console.log("AJAX Error Details:");
            console.log("Status: " + status);
            console.log("Error: " + error);
            console.log("Response Text: " + xhr.responseText);
            console.log("Ready State: " + xhr.readyState);
            console.log("Status Code: " + xhr.status);

            alert(`error RenderPartialView, formId: ${formId}, action: ${url}`);
        },
        complete: function () {
            $('#spinner').prop('hidden', true);
        }
    });
}

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