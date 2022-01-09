function Main(input) {
    let num = Number(input[0]);
    let numTwo = Number(input[1]);

    let sum = 0;
    for (let i = num; i <= numTwo; i++) {
        if (i % 9 == 0) sum += i;
    }

    console.log(`The sum: ${sum}`);
    for (let i = num; i <= numTwo; i++) {
        if (i % 9 == 0) console.log(i);
    }
}