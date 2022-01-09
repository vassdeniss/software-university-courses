function Main(input) {
    let series = input[0];
    let episodeLenght = Number(input[1]);
    let breakLenght = Number(input[2]);

    let breakLeft = breakLenght - (breakLenght * 1 / 8) - (breakLenght * 1 / 4);
    if (breakLeft >= episodeLenght) console.log(`You have enough time to watch ${series} and left with ${Math.ceil(breakLeft - episodeLenght)} minutes free time.`);
    else console.log(`You don't have enough time to watch ${series}, you need ${Math.ceil(episodeLenght - breakLeft)} more minutes.`);
}