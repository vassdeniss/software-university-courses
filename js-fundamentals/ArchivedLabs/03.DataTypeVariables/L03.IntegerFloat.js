function Main(numOne, numTwo, numThree) {
    let result = numOne + numTwo + numThree;
    result % 1 === 0 ? result += " - Integer" : result += " - Float";
    console.log(result);
}