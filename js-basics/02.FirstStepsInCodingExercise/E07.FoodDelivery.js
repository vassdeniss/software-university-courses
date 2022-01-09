function Main(input) {
    const DELIVERY_PRICE = 2.50;

    let chickenMenuTotal = Number(input[0]) * 10.35;
    let fishMenuTotal = Number(input[1]) * 12.40;
    let vegeterianMenuTotal = Number(input[2]) * 8.15;
    let dessertPrice = (chickenMenuTotal + fishMenuTotal + vegeterianMenuTotal) * 0.20;
    let total = chickenMenuTotal + fishMenuTotal + vegeterianMenuTotal + dessertPrice + DELIVERY_PRICE;

    console.log(total)
}