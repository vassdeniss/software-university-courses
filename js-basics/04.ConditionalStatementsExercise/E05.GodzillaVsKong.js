function Main(input) {
    let movieBudget = Number(input[0]);
    let extras = Number(input[1]);
    let clothesPrice = Number(input[2]);
    let decor = movieBudget * 0.1;
    let extrasClothing = extras * clothesPrice;
    if (extras > 150) extrasClothing *= 0.9;

    let neededBudget = decor + extrasClothing;
    if (movieBudget >= neededBudget) {
        console.log("Action!");
        console.log(`Wingard starts filming with ${(movieBudget - neededBudget).toFixed(2)} leva left.`);
    } else {
        console.log("Not enough money!");
        console.log(`Wingard needs ${(neededBudget - movieBudget).toFixed(2)} leva more.`);
    }
}