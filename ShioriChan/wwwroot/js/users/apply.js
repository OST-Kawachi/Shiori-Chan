let userSeq = "";
$(function () {
    $("#complete").hide();
    let href = location.href;
    let splittedHref = href.split("/");
    userSeq = splittedHref[splittedHref.length - 1];
    $("#registerButton").on(
        "click",
        function () {
            let name = $("#userName").val();
            if (name === null || name === undefined || name === "") {
                $("#errorMessage").empty();
                $("#errorMessage").append("名前を入力してください");
                return;
            }
            $.ajax({
                url: "/shiori-chan/api/user/apply",
                type: "POST",
                data: JSON.stringify({
                    userSeq: userSeq,
                    name: name
                }),
                dataType: "json"
            })
                .done(function () {
                    $("#input").empty();
                    $("#complete").show();
                });
        }
    );

});
