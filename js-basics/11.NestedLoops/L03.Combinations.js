function Main(args) {
    let limit = Number(args[0]);
    
    let combinations = 0;
    for (let i = 0; i <= limit; i++) {
        for (let j = 0; j <= limit; j++) {
            for (let k = 0; k <= limit; k++) {
                if (i + j + k == limit) combinations++;
            }
        }
    }

    console.log(combinations);
}