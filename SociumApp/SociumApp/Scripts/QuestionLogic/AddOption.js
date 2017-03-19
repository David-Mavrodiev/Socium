$("#addOptionButton").on("click", function (event) {
    let description = $("#optionDesc").val();
    let id = location.href.split("=")[1];
    let body = {
        id: id,
        description: description
    };

    $.ajax({
        url: "/Question/AddOption",
        type: "post",
        cors: true,
        contentType: "application/json",
        data: JSON.stringify(body),
        success: function (response) {
            location.reload();
        }
    });
});