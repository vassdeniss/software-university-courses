function Main(args) {
    let minNum = Number.MAX_SAFE_INTEGER;
    
    let iterator = 0;
    while (args[iterator] != "Stop") {
        let num = Number(args[iterator]);
        if (num < minNum) minNum = num;     
        iterator++;
    }

    console.log(minNum);
}