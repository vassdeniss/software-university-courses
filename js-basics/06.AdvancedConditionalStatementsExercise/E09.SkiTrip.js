function Main(input) {
    const ONE_PERSON_ROON = 18;
    const APARTMENT = 25;
    const PRESIDENT_APARTMENT = 35;

    let days = Number(input[0]);
    let roomType = input[1];
    let review = input[2];
    
    let total = 0;
    if (roomType === "room for one person") {
        total = (days - 1) * ONE_PERSON_ROON;
        if (review === "positive") total *= 1.25;
        else total *= 0.90;
    } else if (roomType === "apartment") {
        total = (days - 1) * APARTMENT;
        if ((days - 1) > 15) total *= 0.5;
        else if ((days - 1) >= 10 && (days - 1) <= 15) total *= 0.65;
        else if ((days - 1) < 10) total *= 0.7;
        if (review === "positive") total *= 1.25;
        else total *= 0.90;
    } else if (roomType === "president apartment") {
        total = (days - 1) * PRESIDENT_APARTMENT;
        if ((days - 1) > 15) total *= 0.8;
        else if ((days - 1) >= 10 && (days - 1) <= 15) total *= 0.85;
        else if ((days - 1) < 10) total *= 0.9;
        if (review === "positive") total *= 1.25;
        else total *= 0.90;
    }

    console.log(`${total.toFixed(2)}`);
}