function Main(input) {
    const ROSES_PRICE = 5;
    const DAHLIA_PRICE = 3.80;
    const TULIP_PRICE = 2.80;
    const NARCISSUS_PRICE = 3;
    const GLADIOLUS_PRICE = 2.50;

    let flowerType = input[0];
    let flowerQuantity = Number(input[1]);
    let budget = Number(input[2]);

    let total = 0.0;
    switch (flowerType) {
        case "Roses": 
            total += flowerQuantity * ROSES_PRICE;
            if (flowerQuantity > 80) total *= 0.9;
            break;
        case "Dahlias":
            total += flowerQuantity * DAHLIA_PRICE;
            if (flowerQuantity > 90) total *= 0.85;
            break;
        case "Tulips":
            total += flowerQuantity * TULIP_PRICE;
            if (flowerQuantity > 80) total *= 0.85;
            break;
        case "Narcissus":
            total += flowerQuantity * NARCISSUS_PRICE;
            if (flowerQuantity < 120) total *= 1.15;
            break;
        case "Gladiolus":
            total += flowerQuantity * GLADIOLUS_PRICE;
            if (flowerQuantity < 80) total *= 1.20;
            break;
    }

    if (budget >= total)
        console.log(`Hey, you have a great garden with ${flowerQuantity} ${flowerType} and ${(budget - total).toFixed(2)} leva left.`);
    else if (budget < total)
        console.log(`Not enough money, you need ${(total - budget).toFixed(2)} leva more.`);
}