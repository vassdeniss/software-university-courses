function Main(input) {
    let degrees = Number(input[0]);
    let timeOfDay = input[1];
    let shirt;
    let shoes;

    switch (timeOfDay) {
        case "Morning": 
            if (degrees >= 10 && degrees <= 18) {
                shirt = "Sweatshirt";
                shoes = "Sneakers";
            } else if (degrees > 18 && degrees <= 24) {
                shirt = "Shirt";
                shoes = "Moccasins"; 
            } else if (degrees >= 25) {
                shirt = "T-Shirt";
                shoes = "Sandals";
            }
            break;
        case "Afternoon":
            if (degrees >= 10 && degrees <= 18) {
                shirt = "Shirt";
                shoes = "Moccasins";
            } else if (degrees > 18 && degrees <= 24) {
                shirt = "T-Shirt";
                shoes = "Sandals";
            } else if (degrees >= 25) {
                shirt = "Swim Suit";
                shoes = "Barefoot";
            }
            break;
        case "Evening":
            shirt = "Shirt";
            shoes = "Moccasins";
            break;
    }

    console.log(`It's ${degrees} degrees, get your ${shirt} and ${shoes}.`);
}