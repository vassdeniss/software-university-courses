function Main(input) {
    let examTime = Number(input[0]) * 60 + Number(input[1]);
    let arrivalTime = Number(input[2]) * 60 + Number(input[3]);

    if (examTime < arrivalTime) {
        console.log("Late");

        let diff = Math.abs(arrivalTime - examTime);
        let h = Math.floor(diff / 60);
        let m = diff % 60;
        if (h >= 1) {
            let hasLeadingZero = m < 10 ? `0${m}` : `${m}`;
            console.log(`${h}:${hasLeadingZero} hours after the start`);
        } else console.log(`${m} minutes after the start`);
    } else if (arrivalTime === examTime || examTime - arrivalTime <= 30) {
        console.log("On time");

        let diff = Math.abs(arrivalTime - examTime);
        if (diff !== 0) console.log(`${diff % 60} minutes before the start`);
    } else {
        console.log("Early");

        let diff = Math.abs(examTime - arrivalTime);
        let h = Math.floor(diff / 60); 
        let m = diff % 60;
        if (h >= 1) {
            let hasLeadingZero = m < 10 ? `0${m}` : `${m}`;
            console.log(`${h}:${hasLeadingZero} hours before the start`);
        } else console.log(`${m} minutes before the start`);
    }
}