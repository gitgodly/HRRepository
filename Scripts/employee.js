
function save() {

    var form = new FormData();
    form.append("name", $("#name").val());
    form.append("gender", $("#gender").val());
    form.append("age", $("#age").val());

    var settings = {
        "url": "/employee/save",
        "method": "POST",
        "timeout": 0,
        "processData": false,
        "mimeType": "multipart/form-data",
        "contentType": false,
        "data": form
    };

    $.ajax(settings).done(function (response) {
        load();
        $("#name").val(''); $("#gender").val(''); $("#age").val('');
    });
}
function load() {
    var settings = {
        "url": "/employee/get",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (r) {
        $("#emplist").html(r);
    });
}