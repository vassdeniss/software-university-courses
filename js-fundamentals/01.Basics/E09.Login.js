function Main(args) {
    let username = args.shift();
    let password = username.split("").reverse().join("");

    let input = args.shift();
    let tries = 4;
    while (input != password) {
        tries--;
        if (tries == 0) {
            console.log(`User ${username} blocked!`);
            return;
        }
        console.log("Incorrect password. Try again.");
        input = args.shift();
    }

    console.log(`User ${username} logged in.`);
}
