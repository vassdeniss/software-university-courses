function Main(input) {
    let vacationPrice = Number(input[0]);
    let puzzles = Number(input[1]);
    let dolls = Number(input[2]);
    let plushies = Number(input[3]);
    let minions = Number(input[4]);
    let trucks = Number(input[5]);

    let totalToys = puzzles + dolls + plushies + minions + trucks;
    let soldToys = puzzles * 2.6 + dolls * 3 + plushies * 4.1 + minions * 8.2 + trucks * 2;

    if (totalToys >= 50) soldToys *= 0.75;
    soldToys *= 0.9;

    if (soldToys >= vacationPrice) console.log(`Yes! ${(soldToys - vacationPrice).toFixed(2)} lv left.`);
    else console.log(`Not enough money! ${(vacationPrice - soldToys).toFixed(2)} lv needed.`);
}