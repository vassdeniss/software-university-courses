function Main(input) {
    let power = Number(input[0]); 
    for (let i = 0; i <= power; i += 2 ) console.log(Math.pow(2, i));
}