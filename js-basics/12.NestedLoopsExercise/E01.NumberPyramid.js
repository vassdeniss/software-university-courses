function Main(args) {
    let n = Number(args[0]);
    let result = ""
    let current = 1;
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= i; j++) {
            if (current > n) break;
            result += `${current} `;
            current++;
        }
        console.log(result);
        result = "";
    }
}