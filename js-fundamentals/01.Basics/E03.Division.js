function Main(n) {
    if (n % 10 == 0) console.log("The number is divisible by 10");
    else if (n % 7 == 0) console.log("The number is divisible by 7");
    else if (n % 6 == 0) console.log("The number is divisible by 6");
    else if (n % 3 == 0) console.log("The number is divisible by 3");
    else if (n % 2 == 0) console.log("The number is divisible by 2");
    else console.log("Not divisible");
}
