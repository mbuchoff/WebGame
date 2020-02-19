declare const qrUrl: string;
declare const qrcode: (typeNumber:string, errorCorrectionLevel:string) => QrObject

interface QrObject {
    addData: (data: string, mode?: string) => void;
    make: () => void;
    createSvgTag: (cellSize: number, margin?: number, alt?: string, title?: string) => string;
}

var qr = qrcode("0", "M");
qr.addData(qrUrl);
qr.make();

$('#qr').html(qr.createSvgTag(10));

$(function () {
    let roomInfo = $('#roomInfo');

    repeatedlyCheck("@Model.PregameUrl", 2000, function (data) {
        roomInfo.text(data);
        let jsonData = JSON.parse(data);
        if (jsonData.GameStarted) {
            location.href = '@Url.Action("GameStarted", "Home" )';
        }
    })
});
