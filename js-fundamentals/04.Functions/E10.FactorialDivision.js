function main(first, second) {
    function factorial(n)
    {
        if (n === 0) return 1;
        return n * factorial(n - 1);
    }

    let firstFactorial = factorial(first);
    let secondFactorial = factorial(second);
    console.log(`${(firstFactorial / secondFactorial).toFixed(2)}`);
}
