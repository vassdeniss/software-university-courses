function main(args) {
    let gladiators = {};
    for (const line of args) {
        if (line == 'Ave Cesar') {
            break;
        }

        const elements = line.split(' ');
        if (elements[1] == '->') {
            let gladiator = elements[0];
            let technique = elements[2];
            let skill = parseInt(elements[4]);

            if (!Object.hasOwnProperty.call(gladiators, gladiator)) {
                gladiators[gladiator] = {};
            }

            if (!Object.hasOwnProperty.call(gladiators[gladiator], technique)
                || gladiators[gladiator][technique] < skill) {
                gladiators[gladiator][technique] = skill;
            }
        } else if (elements[1] == 'vs') {
            let gladiatorOne = elements[0];
            let gladiatorTwo = elements[2];
            if (Object.hasOwnProperty.call(gladiators, gladiatorOne) 
                && Object.hasOwnProperty.call(gladiators, gladiatorTwo)) {
                let techniquesOne = gladiators[gladiatorOne];
                let techniquesTwo = gladiators[gladiatorTwo];
                for (const tech in techniquesOne) {
                    if (Object.hasOwnProperty.call(techniquesTwo, tech)) {
                        if (techniquesOne[tech] > techniquesTwo[tech]) {
                            delete gladiators[gladiatorTwo];
                        } else if (techniquesOne[tech] < techniquesTwo[tech]) {
                            delete gladiators[gladiatorOne];
                        }
                    }
                }
            }
        }
    }

    for (const gladiator in gladiators) {
        let total = 0;
        let gladiatorTech = gladiators[gladiator];
        for (const skill in gladiatorTech) {
            total += gladiatorTech[skill];
        }

        gladiatorTech.total = total;
    }

    Object.entries(gladiators)
        .sort((a, b) => b[1].total - a[1].total || a[0].localeCompare(b[0]))
        .forEach(x => {
            console.log(`${x[0]}: ${x[1].total} skill`);
            delete x[1].total;
            Object.entries(x[1])
                .sort((a, b) => b[1] - a[1] || a[0].localeCompare(b[0]))
                .forEach(x => {
                    console.log(` - ${x[0]} <!> ${x[1]}`);
                });
        });
}
