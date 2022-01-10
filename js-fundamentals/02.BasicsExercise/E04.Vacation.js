function Main(people, type, day) {
    let price = 0;
    switch (day) {
        case "Friday":
            switch (type) {
                case "Students": price = 8.45; break;
                case "Business": price = 10.9; break;
                case "Regular": price = 15.0; break;
            }
            break;
        case "Saturday":
            switch (type) {
                case "Students": price = 9.8; break;
                case "Business": price = 15.6; break;
                case "Regular": price = 20.0; break;
            }
            break;
        case "Sunday":
            switch (type) {
                case "Students": price = 10.46; break;
                case "Business": price = 16; break;
                case "Regular": price = 22.5; break;
            }
            break;
    }

    let total = people * price;
    if (type === "Students" && people >= 30) total *= 0.85;
    else if (type === "Business" && people >= 100) total -= price * 10;
    else if (type === "Regular" && people >= 10 && people <= 20) total *= 0.95;

    console.log(`Total price: ${total.toFixed(2)}`);
}