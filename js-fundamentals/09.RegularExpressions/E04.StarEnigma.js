function main(args) {
    const msgQty = args.shift();
    const pattern = /@(?<planet>[A-Za-z]+)([^@\-:!>]*):[\d]+([^@\-:!>]*)!(?<attack>[AD])!([^@\-:!>]*)->[\d]+([^@\-:!>]*)/;
    let attackedPlanets = [];
    let destroyedPlanets = [];

    for (let i = 0; i < msgQty; i++) {
        const line = args[i];
        const decryptKey = line.match(/[star]/gi) && line.match(/[star]/gi).length;

        let decryptedMsg = '';
        for (const letter of line) {
            const symbol = String.fromCharCode(letter.charCodeAt() - decryptKey);
            decryptedMsg += symbol;
        }

        const match = pattern.exec(decryptedMsg);
        if (match) {
            if (match.groups.attack === 'A') {
                attackedPlanets.push(match.groups.planet);
            } else {
                destroyedPlanets.push(match.groups.planet);
            }
        }
    }

    console.log(`Attacked planets: ${attackedPlanets.length}`);
    attackedPlanets.sort((a, b) => a.localeCompare(b));
    attackedPlanets.forEach(planet => console.log(`-> ${planet}`));

    console.log(`Destroyed planets: ${destroyedPlanets.length}`);
    destroyedPlanets.sort((a, b) => a.localeCompare(b));
    destroyedPlanets.forEach(planet => console.log(`-> ${planet}`));
}
