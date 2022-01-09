function Main(input) {
    let totalSeconds = Number(input[0]) + Number(input[1]) + Number(input[2]);
    let minutes = Math.floor(totalSeconds / 60);
    let seconds = totalSeconds % 60;
    let secondsFormatted = seconds < 10 ? `0${seconds}` : seconds;
    console.log(`${minutes}:${secondsFormatted}`);
}