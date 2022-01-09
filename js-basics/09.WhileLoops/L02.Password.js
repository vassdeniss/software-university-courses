function Main(args) {
    let username = args[0];
    let password = args[1];

    let iterator = 2;
    let input = args[iterator];
    while (input !== password) {
        input = args[iterator]
        iterator++;
    }

    console.log(`Welcome ${username}!`);
}