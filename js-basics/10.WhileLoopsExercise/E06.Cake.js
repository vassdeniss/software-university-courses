function Main(args) {
    let cakeWidth = Number(args[0]);
    let cakeLength = Number(args[1]);
    let totalCake = cakeLength * cakeWidth;
    
    let iterator = 2;
    while (args[iterator] != "STOP") {
        totalCake -= Number(args[iterator]);
        if (totalCake <= 0) break;
        iterator++;
    }

    if (totalCake > 0) console.log(`${totalCake} pieces are left.`);
    else console.log(`No more cake left! You need ${Math.abs(totalCake)} pieces more.`);
}