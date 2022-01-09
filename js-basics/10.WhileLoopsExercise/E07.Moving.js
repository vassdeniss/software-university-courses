function Main(args) {
    let avaliableWidth = Number(args[0]);
    let avaliableLength = Number(args[1]);
    let avaliableHeight = Number(args[2]);
    let cubicMetersHouse = avaliableHeight * avaliableLength * avaliableWidth;

    let iterator = 3;
    while (args[iterator] != "Done") {
        let boxesToMove = Number(args[iterator]);
        cubicMetersHouse -= boxesToMove;
        if (cubicMetersHouse <= 0) break;
        iterator++;
    }

    if (cubicMetersHouse > 0) console.log(`${cubicMetersHouse} Cubic meters left.`);
    else console.log(`No more free space! You need ${Math.abs(cubicMetersHouse)} Cubic meters more.`);
}