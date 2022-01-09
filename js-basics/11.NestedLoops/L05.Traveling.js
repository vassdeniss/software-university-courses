function Main(args) {
    let location;
    while (location !== "End") {
        location = args.shift();
        let vacationPrice = Number(args.shift());
        let savings = 0;
        while (savings < vacationPrice) savings += Number(args.shift());
        if (savings >= vacationPrice) console.log(`Going to ${location}!`);
    }
}