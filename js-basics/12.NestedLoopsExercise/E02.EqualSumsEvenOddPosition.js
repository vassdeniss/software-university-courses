function Main(args) {
    let one = Number(args[0]);
    let two = Number(args[1]);

    let result = "";
    for (let i = one; i <= two; i++) {
        let even = 0, odd = 0, num = String(i);

        for (let j = 0; j < num.length; j++) {
            let digit = Number(num.charAt(j));
            if (j % 2 === 0) even += digit;
            else odd += digit;
        }

        if (even == odd) result += `${i} `;
    }

    console.log(result);
}