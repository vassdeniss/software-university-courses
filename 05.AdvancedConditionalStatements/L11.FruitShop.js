function Main(input) {
    const BANANA_PRICE = 2.50;
    const APPLE_PRICE = 1.20;
    const ORANGE_PRICE = 0.85;
    const GRAPEFRUIT_PRICE = 1.45;
    const KIWI_PRICE = 2.70;
    const PINEAPPLE_PRICE = 5.50;
    const GRAPE_PRICE = 3.85;

    let fruit = input[0];
    let day = input[1];
    let quantity = Number(input[2]);

    let total = 0.0;
    switch (day) {
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
            switch (fruit) {
                case "banana": total += BANANA_PRICE * quantity; break;
                case "apple": total += APPLE_PRICE * quantity; break;
                case "orange": total += ORANGE_PRICE * quantity; break;
                case "grapefruit": total += GRAPEFRUIT_PRICE * quantity; break;
                case "kiwi": total += KIWI_PRICE * quantity; break;
                case "pineapple": total += PINEAPPLE_PRICE * quantity; break;
                case "grapes": total += GRAPE_PRICE * quantity; break;
                default: console.log("error"); break;
            }
            break;
        case "Saturday":
        case "Sunday":
            switch (fruit) {
                case "banana": total += (BANANA_PRICE + 0.20) * quantity; break;
                case "apple": total += (APPLE_PRICE + 0.05) * quantity; break;
                case "orange": total += (ORANGE_PRICE + 0.05) * quantity; break;
                case "grapefruit": total += (GRAPEFRUIT_PRICE + 0.15) * quantity; break;
                case "kiwi": total += (KIWI_PRICE + 0.30) * quantity; break;
                case "pineapple": total += (PINEAPPLE_PRICE + 0.10) * quantity; break;
                case "grapes": total += (GRAPE_PRICE + 0.35) * quantity; break;
                default: console.log("error"); break;
            }
            break;
        default: console.log("error"); break;
    }

    if (total != 0.0) console.log(`${total.toFixed(2)}`);
}