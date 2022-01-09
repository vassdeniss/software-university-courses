function Main(input) {
    const PENS_PRICE = 5.80;
    const MARKERS_PRICE = 7.20;
    const CHEMICAL = 1.20;

    let totalPrice = (Number(input[0]) * PENS_PRICE 
        + Number(input[1]) * MARKERS_PRICE
        + Number(input[2]) * CHEMICAL) * ((100 - Number(input[3])) / 100);
    console.log(totalPrice.toFixed(2));
}