function Main(lostFights, helmet, sword, shield, armor) {
    let sum = 0;
    let shieldBreaks = 0;
    for (let i = 1; i <= lostFights; i++) {
        if (i % 2 === 0) sum += helmet;

        if (i % 3 === 0) sum += sword;

        if (i % 2 === 0 && i % 3 === 0) {
            sum += shield;
            shieldBreaks++;
        }

        if (shieldBreaks === 0) continue;
        if (shieldBreaks % 2 === 0) {
            sum += armor;
            shieldBreaks = 0;
        }
    }

    console.log(`Gladiator expenses: ${sum.toFixed(2)} aureus`);
}
