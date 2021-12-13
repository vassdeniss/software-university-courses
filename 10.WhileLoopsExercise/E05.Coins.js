function Main(args) {
    let change = Number(args[0]);
    let requiredCoins = 0;

    let wholeChange = parseInt(change * 100);
    while (wholeChange > 0) {
        requiredCoins++;
        if (wholeChange - 200 >= 0) wholeChange -= 200;
        else if (wholeChange - 100 >= 0) wholeChange -= 100;
        else if (wholeChange - 50 >= 0) wholeChange -= 50;
        else if (wholeChange - 20 >= 0) wholeChange -= 20;
        else if (wholeChange - 10 >= 0) wholeChange -= 10;
        else if (wholeChange - 5 >= 0) wholeChange -= 5;
        else if (wholeChange - 2 >= 0) wholeChange -= 2;
        else if (wholeChange - 1 >= 0) wholeChange -= 1;
    }

    console.log(requiredCoins);
}