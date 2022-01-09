function Main(args) {
    let musala = 0, monblanck = 0, kilimanjaro = 0, k2 = 0, everest = 0;
    let total = 0;

    let groups = Number(args[0]);
    for (let i = 0; i < groups; i++) {
        let groupSize = Number(args[i + 1]);
        if (groupSize <= 5) musala += groupSize;
        else if (groupSize >= 6 && groupSize <= 12) monblanck += groupSize;
        else if (groupSize >= 13 && groupSize <= 25) kilimanjaro += groupSize;
        else if (groupSize >= 26 && groupSize <= 40) k2 += groupSize;
        else if (groupSize >= 41) everest += groupSize;
        total += groupSize;
    }

    console.log(`${((musala / total) * 100).toFixed(2)}%`);
    console.log(`${((monblanck / total) * 100).toFixed(2)}%`);
    console.log(`${((kilimanjaro / total) * 100).toFixed(2)}%`);
    console.log(`${((k2 / total) * 100).toFixed(2)}%`);
    console.log(`${((everest / total) * 100).toFixed(2)}%`);
}