function Main(input) {
    let lenght = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);

    let letersArea = (lenght * width * height) / 1000;
    console.log(letersArea * (1 - (Number(input[3]) / 100)));
}