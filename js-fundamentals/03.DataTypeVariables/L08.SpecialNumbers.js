function Main(n) {
    for (let i = 1; i <= n; i++) {
        let sum = 0;

        i = i.toString();
        for (let j = 0; j < i.length; j++) {
            sum += Number(i[j]);
        }

        let result = sum === 5 || sum === 7 || sum === 11;
        console.log(result ? `${i} -> True` : `${i} -> False`);
    }
}