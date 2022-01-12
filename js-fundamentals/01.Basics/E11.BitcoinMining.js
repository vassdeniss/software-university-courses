function Main(args) {
    const BITCOIN_PRICE = 11949.16;
    const GOLD_PRICE = 67.51;

    let day = 0;
    let lv = 0;

    let firstCoin = 0;
    let bitcoin = 0;
    for (let i = 0; i < args.length; i ++) {
        day++;
        let gold = args[i];

        if (day % 3 == 0) gold *= 0.7;
        lv += gold * GOLD_PRICE;

        if (lv >= BITCOIN_PRICE) {
            if (bitcoin == 0) firstCoin = day; 

            let bought = Math.floor(lv / BITCOIN_PRICE)
            bitcoin += bought;
            lv -= bought * BITCOIN_PRICE
        }
    }

    console.log(`Bought bitcoins: ${bitcoin}`);
    if (bitcoin > 0) console.log(`Day of the first purchased bitcoin: ${firstCoin}`);
    console.log(`Left money: ${lv.toFixed(2)} lv.`);
}