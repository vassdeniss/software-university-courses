function Main(args) {
    let input = args.shift();
    let prime = 0, noPrime = 0;
    while (input !== "stop") {
        let n = Number(input);
        if (n < 0) {
            console.log("Number is negative.");
            input = args.shift();
            continue;
        }

        if (n === 1) {
            noPrime += n;
            input = args.shift();
            continue;
        }

        let isPrime = true;
        for (let i = 2; i < n; i++) {
            if (n % i === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime) prime += n;
        else noPrime += n;

        input = args.shift();
    }

    console.log(`Sum of all prime numbers is: ${prime}`);
    console.log(`Sum of all non prime numbers is: ${noPrime}`);
}