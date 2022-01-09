function Main(args) {
    let n = Number(args[0]);

    let result = "";
    for (let i = 1111; i <= 9999; i++) {
        let num = String(i);

        let isValid = true;
        for (let j = 0; j < num.length; j++) {
            let digit = Number(num[j]);
            if (n % digit !== 0 || digit === 0) {
                isValid = false; 
                break;
            }
        }

        if (isValid) result += `${i} `;
    }

    console.log(result);
}