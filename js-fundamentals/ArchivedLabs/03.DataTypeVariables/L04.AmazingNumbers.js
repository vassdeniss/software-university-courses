function Main(input) {
    let sum = 0;
    let n = input.toString(); 
    for (let i = 0; i < n.length; i++) {
        sum += Number(n[i]);
    }

    let result = sum.toString().includes('9');
    console.log(result 
        ? `${input} Amazing? True` 
        : `${input} Amazing? False`);
}