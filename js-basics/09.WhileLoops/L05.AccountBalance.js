function Main(args) {
    let total = 0;

    let iterator = 0;
    while (args[iterator] != "NoMoreMoney") {
        let account = Number(args[iterator]);
        if (account < 0) {
            console.log("Invalid operation!");
            break;
        }

        total += account;
        console.log(`Increase: ${account.toFixed(2)}`);
        iterator++;
    }

    console.log(`Total: ${total.toFixed(2)}`);
}