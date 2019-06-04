var updateList = function () {
    $("#unRegisteredUser").empty();
    $("#approvedUser").empty();
    $("#waitingApprovalUser").empty();
    $.ajax({
        url: "/shiori-chan/api/user/waiting-approval-users",
        type: "GET",
        dataType: "json"
    })
        .done(function (response) {
            let unRegisteredUsers = response.unRegisteredUsers;
            let waitingApprovalUsers = response.waitingApprovalUsers;
            let approvedUsers = response.approvedUsers;

            let unRegisteredHtml = "";
            for (let i = 0; i < unRegisteredUsers.length; i++) {
                let seq = unRegisteredUsers[i].seq;
                let name = unRegisteredUsers[i].name;
                let html = '<div><input type="radio" name="unRegistered" value="' + seq + '" />' + name + '</div>';
                unRegisteredHtml += html;
            }
            setTimeout(function () {
                $("#unRegisteredUser").append(unRegisteredHtml);
            }, 0);

            let waitingApprovalHtml = "";
            for (let i = 0; i < waitingApprovalUsers.length; i++) {
                let seq = waitingApprovalUsers[i].seq;
                let name = waitingApprovalUsers[i].userName;
                let html = '<div><input type="radio" name="waitingApproval" value="' + seq + '" />' + name + '</div>';
                waitingApprovalHtml += html;
            }
            setTimeout(function () {
                $("#waitingApprovalUser").append(waitingApprovalHtml);
            }, 0);

            let approvedHtml = "";
            console.log(approvedUsers.length);
            for (let i = 0; i < approvedUsers.length; i++) {
                let seq = approvedUsers[i].seq;
                let name = approvedUsers[i].name;
                let html = '<div><input type="radio" name="unRegistered" value="' + seq + '" />' + name + '</div>';
                approvedHtml += html;
            }
            setTimeout(function () {
                $("#approvedUser").append(approvedHtml);
            }, 0);

        });
};

$(function () {
    updateList();
    $("#setting").on(
        "click",
        function () {
            let unRegisteredUserSeq = $('input[name=unRegistered]:checked').val();
            let waitingApprovalUserSeq = $('input[name=waitingApproval]:checked').val();
            if (unRegisteredUserSeq === null || unRegisteredUserSeq === undefined) {
                return;
            }
            if (waitingApprovalUserSeq === null || waitingApprovalUserSeq === undefined) {
                return;
            }
            $.ajax({
                url: "/shiori-chan/api/user/approval/" + unRegisteredUserSeq + "/" + waitingApprovalUserSeq,
                type: "POST",
                dataType: "json"
            })
                .done(function () {
                    updateList();
                })
                .catch(function () {
                    updateList();
                });
        }
    );
});
