function Main(args) {
    let tournaments = Number(args[0]);
    let startPoints = Number(args[1]);
    
    let points = startPoints;
    let wins = 0;
    for (let i = 0; i < tournaments; i++) {
        let finish = String(args[i + 2]);
        switch (finish) {
            case "W": points += 2000; wins++; break;
            case "F": points += 1200; break;
            case "SF": points += 720; break;
        }
    }

    console.log(`Final points: ${points}`);
    console.log(`Average points: ${Math.floor((points - startPoints) / tournaments)}`);
    console.log(`${((wins / tournaments) * 100).toFixed(2)}%`);
}