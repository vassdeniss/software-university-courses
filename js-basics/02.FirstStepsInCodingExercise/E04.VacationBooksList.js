function Main(input) {
    let pages = Number(input[0]);
    let pagesPerHour = Number(input[1]);
    let days = Number(input[2]);

    console.log((pages / pagesPerHour) / days);
}