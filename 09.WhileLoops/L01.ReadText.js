function Main(args) {
    let iterator = 0;
    while (args[iterator] !== "Stop") {
        console.log(args[iterator]);
        iterator++;
    }
}