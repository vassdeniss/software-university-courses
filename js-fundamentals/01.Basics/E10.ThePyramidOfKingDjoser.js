function Main(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let row = 0;
    
    while (base > 2) {
        let marbleArea = base * 4 - 4;
        let stoneArea = base * base - marbleArea;
        stone += stoneArea;
        
        row++;
        if (row % 5 === 0) lapis += marbleArea;
        else marble += marbleArea;

        base -= 2;
    }

    row++;
    let gold = base === 1 ? 1 : 4;

    stone = Math.ceil(stone * increment);
    marble = Math.ceil(marble * increment);
    lapis = Math.ceil(lapis * increment);
    gold = Math.ceil(gold * increment);
    let heigth = Math.floor(row * increment);

    console.log(`Stone required: ${stone}\n` +
    `Marble required: ${marble}\n` +
    `Lapis Lazuli required: ${lapis}\n` +
    `Gold required: ${gold}\n` +
    `Final pyramid height: ${heigth}`);
}
