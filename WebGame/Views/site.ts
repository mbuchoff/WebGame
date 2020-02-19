function repeatedlyCheck(url:string, intervalMillis:number, f:(data:string) => void) {
    { $.get(url).done(f) }
    setInterval(function () { $.get(url).done(f) }, intervalMillis);
}