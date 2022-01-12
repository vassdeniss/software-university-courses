function Main(numOne, operator, numTwo) {
    switch (operator) {
        case "+": console.log(`${(numOne + numTwo).toFixed(2)}`); break;
        case "-": console.log(`${(numOne - numTwo).toFixed(2)}`); break;
        case "*": console.log(`${(numOne * numTwo).toFixed(2)}`); break;
        case "/": console.log(`${(numOne / numTwo).toFixed(2)}`); break;
    }
}