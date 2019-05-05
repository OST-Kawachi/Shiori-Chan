var update = function () {
    $.ajax({
        url: "/shiori-chan/api/roll-call/list",
        type: "POST",
        dataType: "json"
    })
        .done(function (response) {
            $("#list").empty();
            let html = "";
            for (let i = 0; i < response.result.length; i++) {
                let status = response.result[i].rollCall;
                let name = response.result[i].name;
                html += "<div>" + status + " " + name + "</div>";
            }
            $("#list").append(html);
        });
}

$(function () {

    $("#notify").on(
        "click" ,
        function () {
            $.ajax({
                url: "/shiori-chan/api/roll-call/notify",
                type: "POST",
                dataType: "json"
            })
                .done(function () {
                    update();
                });
        }
    );

    $("#update").on(
        "click",
        function () {
            update();
        }
    );

    update();

});
