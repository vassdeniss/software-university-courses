function Main(input) {
    let timeToBeat = Number(input[0]);
    let distance = Number(input[1]);
    let metersPerSecond = Number(input[2]);
    let slowedDown = Math.floor(distance / 15) * 12.5;

    let time = (distance * metersPerSecond) + slowedDown;
    if (time < timeToBeat) console.log(`Yes, he succeeded! The new world record is ${(time).toFixed(2)} seconds.`);
    else console.log(`No, he failed! He was ${(time - timeToBeat).toFixed(2)} seconds slower.`);
}