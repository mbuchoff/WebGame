declare const qrUrl: string;
declare const qrcode: (typeNumber:string, errorCorrectionLevel:string) => QrObject

interface QrObject {
    addData: (data: string, mode?: string) => void;
    make: () => void;
    createSvgTag: (options: Object) => string;
}

$(document).ready(() => {
    var qr = qrcode("0", "M");
    qr.addData(qrUrl);
    qr.make();

    $('#qr').html(qr.createSvgTag({
        cellSize: 10,
        scalable: true
    }));

    $(() => {
        let roomInfo = $('#roomInfo');

        repeatedlyCheck(pregameUrl, 2000, (data) => {
            roomInfo.text(data);
            let jsonData = JSON.parse(data);
            if (jsonData.GameStarted) {
                location.href = gameStartedUrl;
            }
        })
    });
});