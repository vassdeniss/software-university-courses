function Main(args) {
    let maxNum = Number.MIN_SAFE_INTEGER;
    
    let iterator = 0;
    while (args[iterator] != "Stop") {
        let num = Number(args[iterator]);
        if (num > maxNum) maxNum = num;
        iterator++;
    }

    console.log(maxNum);
}