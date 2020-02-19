$(document).ready(function () {
    let roomInfo = $('#roomInfo');

    repeatedlyCheck(pregameUrl, 2000, function (data) {
        roomInfo.text(data);
        let jsonData = JSON.parse(data);
        if (jsonData.GameStarted) {
            location.href = gameStartedUrl;
        }
    })
    $('#submitPlayerName').click(function () {
        $('#enterYourName').hide();
        $.ajax({
            method: "POST",
            url: 'AddPlayer',
            data: {
                roomId: roomId,
                playerName: $('#playerName').val()
            }
        }).done(function (response) {
            if (response.isFirst) {
                $('#beginGameButton').show();
            }
        });
    });
});