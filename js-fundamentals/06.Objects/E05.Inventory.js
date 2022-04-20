function main(args) {
    let heroes = [];
    for (let el of args) {
        let [name, level, items] = el.split(' / ');
        let hero = {
            name: name,
            level: level,
            items: items
        };

        heroes.push(hero);
    }

    heroes.sort((a, b) => a.level - b.level).forEach(x => {
        console.log(`Hero: ${x.name}`);
        console.log(`level => ${x.level}`);
        console.log(`items => ${x.items}`);
    });
}
