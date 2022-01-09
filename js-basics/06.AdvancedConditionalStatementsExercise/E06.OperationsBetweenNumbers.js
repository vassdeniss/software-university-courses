function Main(input) {
    let num = Number(input[0]);
    let numTwo = Number(input[1]);
    let numOperator = input[2];

    let evenOdd;
    let result = 0;
    switch (numOperator) {
        case "+":
            result = num + numTwo;
            if (result % 2 == 0) evenOdd = "even"; 
            else evenOdd = "odd";
            console.log(`${num} ${numOperator} ${numTwo} = ${result} - ${evenOdd}`);
            break;
        case "-":
            result = num - numTwo;
            if (result % 2 == 0) evenOdd = "even"; 
            else evenOdd = "odd";
            console.log(`${num} ${numOperator} ${numTwo} = ${result} - ${evenOdd}`);
            break;
        case "*":
            result = num * numTwo;
            if (result % 2 == 0) evenOdd = "even"; 
            else evenOdd = "odd";
            console.log(`${num} ${numOperator} ${numTwo} = ${result} - ${evenOdd}`);
            break;
        case "/":
            if (numTwo == 0) console.log(`Cannot divide ${num} by zero`);
            else {
                result = num / numTwo;
                console.log(`${num} ${numOperator} ${numTwo} = ${result.toFixed(2)}`);
            }
            break;
        case "%":
            if (numTwo == 0) console.log(`Cannot divide ${num} by zero`);
            else {
                result = num % numTwo;
                console.log(`${num} ${numOperator} ${numTwo} = ${result}`);
            }
            break;
    }
}