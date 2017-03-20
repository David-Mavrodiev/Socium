let idOptionCheck = location.href.split("=")[1];

let bodyOpt = {
    id: idOptionCheck
};

$.ajax({
    url: "/Question/CheckOption",
    type: "post",
    cors: true,
    contentType: "application/json",
    data: JSON.stringify(bodyOpt),
    success: function (response) {
        console.log(response);
        if (response == "Yes") {
            $("#addOptionButton").prop("disabled", true);
        }
    }
});