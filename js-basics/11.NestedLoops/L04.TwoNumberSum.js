function Main(args) {
    let start = Number(args[0]), end = Number(args[1]); 
    let magicNumber = Number(args[2]);
    let combinations = 0;

    for (let i = start; i <= end; i++) {
        for (let j = start; j <= end; j++) {
            combinations++;
            if (i + j == magicNumber) {
                console.log(`Combination N:${combinations} (${i} + ${j} = ${magicNumber})`);
                return;
            }
        }
    }

    console.log(`${combinations} combinations - neither equals ${magicNumber}`);
}