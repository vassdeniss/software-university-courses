function Main(input) {
    const NAYLONE_PRICE = 1.50;
    const PAINT_PRICE = 14.50;
    const PAINT_THINNER_PRICE = 5.00;

    let naylonePrice = (Number(input[0]) + 2) * NAYLONE_PRICE;
    let paintPrice = (Number(input[1]) * 1.1) * PAINT_PRICE;
    let paintThinnerPrice = Number(input[2]) * PAINT_THINNER_PRICE;
    let materialCost = naylonePrice + paintPrice + paintThinnerPrice + 0.4;
    let totalWage = (materialCost * 0.3) * Number(input[3]);

    console.log((materialCost + totalWage).toFixed(2));
}