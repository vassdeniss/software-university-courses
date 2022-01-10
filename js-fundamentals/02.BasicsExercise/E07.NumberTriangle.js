function Main(n) {
    for (let i = 1; i <= n; i++) {
        let result = "";
        for (let j = 1; j <= i; j++) {
            result += `${i}`;
            if (i > 1) result += " ";
        }

        console.log(result);
    }
}