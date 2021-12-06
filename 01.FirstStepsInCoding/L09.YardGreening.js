function Main(input) {
    let squareMeters = Number(input[0]);
    let yard = squareMeters * 7.61;
    let discount = yard * 0.18;
    let total = yard - discount;

    console.log(`The final price is: ${total} lv.`);
    console.log(`The discount is: ${discount} lv.`);
}
Main(["500.23"]);