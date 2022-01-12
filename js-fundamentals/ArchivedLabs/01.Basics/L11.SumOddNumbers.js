function Main(num) {
    let odd = 1;
    let sum = 0;
    for (let i = 0; i < num; i++) {
        console.log(odd);
        sum += odd;
        odd += 2;
    }

    console.log(`Sum: ${sum}`)
}