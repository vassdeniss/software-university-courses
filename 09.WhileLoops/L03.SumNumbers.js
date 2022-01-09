function Main(args) {
    let base = Number(args[0]);
    let sum = 0;

    let iterator = 1;
    while (sum < base) {
        sum += Number(args[iterator]);
        iterator++;
    }

    console.log(sum);
}