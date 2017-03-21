let id = location.href.split("=")[1];

let body = {
    id: id
};

$.ajax({
    url: "/Question/CheckVote",
    type: "post",
    cors: true,
    contentType: "application/json",
    data: JSON.stringify(body),
    success: function (response) {
        console.log(response);
        if(response == "Yes"){
            $("#vote").prop("disabled", true);
            $("#message-vote").text("Вече е даден глас!");
        }
    }
});