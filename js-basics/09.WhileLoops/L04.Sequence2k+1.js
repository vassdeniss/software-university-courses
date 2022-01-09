function Main(args) {
    let step = 1;
    while (step <= Number(args[0])) {
        console.log(step);
        step = 2 * step + 1;
    }
}