declare const qrcode: (typeNumber:string, errorCorrectionLevel:string) => QrObject
interface QrObject {
    addData: (data: string, mode?: string) => void;
    make: () => void;
    createSvgTag: (options: Object) => string;
}

function room(qrSuffix: string) {
    let currentUrl = window.location.href;
    let lastChar = currentUrl.charAt(currentUrl.length - 1);
    if (lastChar != '/') currentUrl += '/';

    var qrUrl = `${currentUrl}${qrSuffix}`;
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
}