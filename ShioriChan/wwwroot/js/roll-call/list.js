var update = function () {
    $.ajax({
        url: "/shiori-chan/api/roll-call/list",
        type: "POST",
        dataType: "json"
    })
        .done(function (response) {
            $("#list").empty();
            let html = "";
            for (let i = 0; i < response.length; i++) {
                let status = response[i].rollCall;
                let name = response[i].name;
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

    update();

});
