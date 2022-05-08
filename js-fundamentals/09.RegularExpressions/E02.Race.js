function main(args) {
    let racers = args.shift().split(', ');
    let scores = {};

    let nameRegex = /(?<letters>[A-Za-z])/g;
    let digitRegex = /(?<digits>\d)/g;

    for (const line of args) {
        if (line === 'end of race') break;

        let name = '';
        let letters = line.match(nameRegex);
        Array.from(letters).forEach(x => name += x);

        if (racers.includes(name)) {
            let score = 0;
            let digits = line.match(digitRegex);
            Array.from(digits).forEach(x => score += parseInt(x));

            if (!Object.hasOwnProperty.call(scores, name)) {
                scores[name] = 0;
            }

            scores[name] += score;
        }
    }

    let idx = 0;
    const places = [ '1st', '2nd', '3rd' ];
    const sorted = Object.entries(scores).sort((a, b) => b[1] - a[1]);
    for (const obj of sorted) {
        if (idx > 2) break;
        console.log(`${places[idx++]} place: ${obj[0]}`);
    }
}
