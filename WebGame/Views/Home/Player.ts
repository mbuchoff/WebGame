declare const pregameUrl: string
declare const gameStartedUrl: string
declare const roomId: number

$(document).ready(() => {
    let roomInfo = $('#roomInfo');

    repeatedlyCheck(pregameUrl, 2000, data => {
        roomInfo.text(data);
        let jsonData = JSON.parse(data);
        if (jsonData.GameStarted) {
            location.href = gameStartedUrl;
        }
    })

    $('#submitPlayerName').click(() => {
        $('#enterYourName').hide();
        $.ajax({
            method: "POST",
            url: 'AddPlayer',
            data: {
                roomId: roomId,
                playerName: $('#playerName').val()
            }
        }).done(response => {
            if (response.isFirst) {
                $('#beginGameButton').show();
            }
        });
    });
});