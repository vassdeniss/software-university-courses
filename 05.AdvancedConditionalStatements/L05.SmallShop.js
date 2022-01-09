function Main(input) {         
    let product = input[0];
    let city = input[1];
    let quantity = Number(input[2]);
    
    let totalPrice = 0;
    switch (product) {
        case "coffee":
            if (city === "Sofia") totalPrice += quantity * 0.50;
            if (city === "Plovdiv") totalPrice += quantity * 0.40;
            if (city === "Varna") totalPrice += quantity * 0.45;
            break;
        case "water":
            if (city === "Sofia") totalPrice += quantity * 0.80;
            if (city === "Plovdiv") totalPrice += quantity * 0.70;
            if (city === "Varna") totalPrice += quantity * 0.70;
            break;
        case "beer":
            if (city === "Sofia") totalPrice += quantity * 1.20;
            if (city === "Plovdiv") totalPrice += quantity * 1.15;
            if (city === "Varna") totalPrice += quantity * 1.10;
            break;
        case "sweets":
            if (city === "Sofia") totalPrice += quantity * 1.45;
            if (city === "Plovdiv") totalPrice += quantity * 1.30;
            if (city === "Varna") totalPrice += quantity * 1.35;
            break;
        case "peanuts":
            if (city === "Sofia") totalPrice += quantity * 1.60;
            if (city === "Plovdiv") totalPrice += quantity * 1.50;
            if (city === "Varna") totalPrice += quantity * 1.55;
            break;
    }
    
    console.log(totalPrice)
}