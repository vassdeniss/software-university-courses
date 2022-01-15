function Main(yield) {
    let days = 0;
    let total = 0;
    let taken = 0;

    while (yield >= 100)
    {
        days++;
        total += yield;
        if (total >= 26) taken += 26;
        yield -= 10;
    }

    if (total >= 26) taken += 26;
    total -= taken;

    console.log(`${days}\n${total}`);
}
