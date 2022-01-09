function Main(input) {
    const OFFSET = 15;
    let hour = Number(input[0]);
    let minutes = Number(input[1]);

    minutes += OFFSET;
    if (minutes >= 60) { minutes -= 60; hour++; }
    if (hour > 23) hour = 0;

    let minutesFormat = minutes < 10 ? `0${minutes}` : minutes;
    console.log(`${hour}:${minutesFormat}`);
}