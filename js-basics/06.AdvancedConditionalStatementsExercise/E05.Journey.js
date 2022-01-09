function Main(input) {
    let budget = Number(input[0]);
    let season = input[1];

    let location;
    let restPlace;
    let moneySpent = 0;
    if (budget <= 100) {
        location = "Bulgaria";
        if (season == "summer") {
            moneySpent = budget * 0.3;
            restPlace = "Camp"; 
        } else if (season == "winter") {
            moneySpent = budget * 0.7;
            restPlace = "Hotel";
        }
    } else if (budget <= 1000) {
        location = "Balkans";
        if (season == "summer") {
            moneySpent = budget * 0.4;
            restPlace = "Camp";
        } else if (season == "winter") {
            moneySpent = budget * 0.8;
            restPlace = "Hotel";
        }
    } else if (budget > 1000) {
        location = "Europe";
        moneySpent = budget * 0.9;
        restPlace = "Hotel";
    }

    console.log(`Somewhere in ${location}\n${restPlace} - ${moneySpent.toFixed(2)}`);
}