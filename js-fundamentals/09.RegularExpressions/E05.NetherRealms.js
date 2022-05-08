function main(args) {
    const healthRegex = /[^0-9./+*-]/gm;
    const numberRegex = /[+-]?\d+\.?\d*/gm;
    const arithmeticRegex = /\*|\//gm;

    let inputDemons = args.split(/[,\s]+/gm);
    let demons = {};
    for (const demon of inputDemons) {
        let hp = 0;
        const chars = demon.match(healthRegex);
        if (chars) {
            for (const match of chars) {
                hp += match.charCodeAt(0);
            }
        }

        let dmg = 0;
        const numbers = demon.match(numberRegex);
        if (numbers) {
            for (const match of numbers) {
                dmg += parseFloat(match);
            }
        }

        const arithmetics = demon.match(arithmeticRegex);
        if (arithmetics) {
            for (const match of arithmetics) {
                if (match === '*') dmg *= 2;
                else dmg /= 2;
            }
        }

        demons[demon] = {
            health: hp,
            damage: dmg
        };
    }

    let ordered = Object.entries(demons).sort((a, b) => a[0].localeCompare(b[0]));
    for (const [name, inner] of ordered) {
        console.log(`${name} - ${inner.health} health, ${inner.damage.toFixed(2)} damage`);
    }
}
