function Main(input) {
    const PREMIERE_PRICE = 12;
    const NORMAL_PRICE = 7.50;
    const DISCOUNT_PRICE = 5;

    let projectionType = input[0];
    let rows = Number(input[1]); 
    let columns = Number(input[2]);

    let totalSeats = rows * columns;
    let total = 0;

    switch (projectionType) {
        case "Premiere": total += totalSeats * PREMIERE_PRICE; break;
        case "Normal": total += totalSeats * NORMAL_PRICE; break;
        case "Discount": total += totalSeats * DISCOUNT_PRICE; break;
    }

    console.log(`${total.toFixed(2)} leva`);
}