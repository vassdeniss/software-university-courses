function main(n) {
    function createBar(n) {
        let bar = "";
        for (let i = 0; i < n / 10; i++) bar += `%`;
        for (let i = 0; i < (100 - n) / 10; i++) bar += `.`;

        return bar;
    }

    if (n === 100) {
        console.log("100% Complete!");
        console.log("[%%%%%%%%%%]");
    } else {
        console.log(`${n}% [${createBar(n)}]`);
        console.log("Still loading...");
    }
}
