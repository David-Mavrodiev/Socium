$("#vote").on("click", function (event) {
    let id = location.href.split("=")[1];
    let optionId;
    $("#cb-wrapper input:checked").each(function () {
        optionId = $(this).attr("item-id");
        let body = {
            id: id,
            optionId: optionId
        };

        $.ajax({
            url: "/Question/AddVote",
            type: "post",
            cors: true,
            contentType: "application/json",
            data: JSON.stringify(body),
            success: function (response) {
                location.reload();
            }
        });
    });
});