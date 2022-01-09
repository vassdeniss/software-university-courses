function Main(args) {
    let num = Number(args[0]);
    for (let i = 1; i <= 10; i++) console.log(`${i} * ${num} = ${num * i}`);
}