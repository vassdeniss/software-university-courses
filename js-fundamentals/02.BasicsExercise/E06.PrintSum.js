function Main(start, end) {
    let result = "";
    let sum = 0;
    for (let i = start; i <= end; i++) {
        if (i == end) result += `${i}`;
        else result += `${i} `;
        sum += i;
    }

    console.log(`${result}\nSum: ${sum}`);
}