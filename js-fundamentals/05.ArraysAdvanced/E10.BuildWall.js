function main(arr) {
    let parsed = arr.map(Number);
    let crew = parsed.filter(x => x < 30).length;
    let daily = [];
    let total = 0;

    while (crew !== 0) {
        let totalToday = 0;
        for (let i = 0; i < parsed.length; i++) {
            if (parsed[i] !== 30) {
                parsed[i]++;
                totalToday += 195;
                if (parsed[i] === 30) crew--;
            }
        }

        total += totalToday;
        daily.push(totalToday);
    }

    console.log(daily.join(", "));
    console.log(`${total * 1900} pesos`);
}
