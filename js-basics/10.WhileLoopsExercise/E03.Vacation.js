function Main(args) {
    let vacationMoney = Number(args[0]), avaliableMoney = Number(args[1]);
    let days = 0, spendingSpree = 0;

    let iterator = 2;
    while (true) {
        let action = args[iterator];
        let spendingMoney = Number(args[iterator + 1]);
        days++;

        if (action == "spend") {
            spendingSpree++;
            avaliableMoney -= spendingMoney;
            if (avaliableMoney < 0) avaliableMoney = 0;
        }

        if (action == "save") {
            spendingSpree = 0;
            avaliableMoney += spendingMoney;
        }

        if (spendingSpree == 5) {
            console.log(`You can't save the money.\n${days}`);
            return;
        }

        if (avaliableMoney >= vacationMoney) {
            console.log(`You saved the money for ${days} days.`);
            return;
        }

        iterator += 2;
    }
}