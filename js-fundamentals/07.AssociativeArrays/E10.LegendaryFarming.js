function main(args) {
    let materials = {
        shards: 0,
        fragments: 0,
        motes: 0
    };
    let junk = {};

    let sword;
    let splitted = args.split(' ');
    for (let i = 0; i < splitted.length; i += 2) {
        let amount = parseInt(splitted[i]);
        let material = splitted[i + 1].toLowerCase();
        if (Object.hasOwnProperty.call(materials, material)) {
            materials[material] += amount;
        } else {
            if (!Object.hasOwnProperty.call(junk, material)) {
                junk[material] = 0;
            }

            junk[material] += amount;
        }

        if (materials.shards >= 250) {
            materials.shards -= 250;
            sword = 'Shadowmourne';
            break;
        } else if (materials.fragments >= 250) {
            materials.fragments -= 250;
            sword = 'Valanyr';
            break;
        } else if (materials.motes >= 250) {
            materials.motes -= 250;
            sword = 'Dragonwrath';
            break;
        }
    }

    console.log(`${sword} obtained!`);
    Object.entries(materials)
        .sort((a, b) => b[1] - a[1] || a[0].localeCompare(b[0]))
        .forEach(x => console.log(`${x[0]}: ${x[1]}`));
    Object.entries(junk)
        .sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(x => console.log(`${x[0]}: ${x[1]}`));
}
