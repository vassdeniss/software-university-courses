function Main(input) {
    const SPRING_BOAT_RENT = 3000;
    const AUTUMN_SUMMER_BOAT_RENT = 4200;
    const WINTER_BOAT_RENT = 2600;

    let budget = Number(input[0]);
    let season = input[1];
    let peopleQuantity = Number(input[2]);

    let total = 0;
    switch (season) {
        case "Spring":
            total += SPRING_BOAT_RENT;
            if (peopleQuantity >= 12) total *= 0.75;
            else if (peopleQuantity >= 7 && peopleQuantity <= 11) total *= 0.85;
            else if (peopleQuantity <= 6) total *= 0.9;
            break;
        case "Summer":
        case "Autumn":
            total += AUTUMN_SUMMER_BOAT_RENT;
            if (peopleQuantity >= 12) total *= 0.75;
            else if (peopleQuantity >= 7 && peopleQuantity <= 11) total *= 0.85;
            else if (peopleQuantity <= 6) total *= 0.9;
            break;
        case "Winter":
            total += WINTER_BOAT_RENT;
            if (peopleQuantity >= 12) total *= 0.75;
            else if (peopleQuantity >= 7 && peopleQuantity <= 11) total *= 0.85;
            else if (peopleQuantity <= 6) total *= 0.9;
            break;
    }

    if (season != "Autumn" && peopleQuantity % 2 == 0) total *= 0.95;

    if (budget >= total)
        console.log(`Yes! You have ${(budget - total).toFixed(2)} leva left.`);
    else if (budget < total)
        console.log(`Not enough money! You need ${(total - budget).toFixed(2)} leva.`);
}