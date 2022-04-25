function main(args) {
    let travelInfo = {};
    for (const info of args) {
        const [country, town, cost] = info.split(' > ');
        
        if (!Object.hasOwnProperty.call(travelInfo, country)) {
            travelInfo[country] = {};
        }

        if (!Object.hasOwnProperty.call(travelInfo[country], town)
            || cost < travelInfo[country][town]) {
            travelInfo[country][town] = cost;
        }
    }

    let sorted = Object.keys(travelInfo).sort((a, b) => a.localeCompare(b));
    for (const key of sorted) {
        let result = [];
        let innerSorted = Object.entries(travelInfo[key]).sort((a, b) => a[1] - b[1]);
        for (const inner of innerSorted) {
            result.push(`${inner[0]} -> ${inner[1]}`);
        }

        console.log(`${key} -> ${result.join(' ')}`);
    }
}
