function Main(args) {
    let lilyAge = Number(args[0]);
    let washingMachinePrice = Number(args[1]);
    let toyPrice = Number(args[2]);
    
    let moneyGift = 10;
    let toyQty = 0;
    let total = 0;
    for (let i = 1; i <= lilyAge; i++) {
        if (i % 2 == 0) {
            total += moneyGift - 1;
            moneyGift += 10;
        } else toyQty++;
    }

    total += toyQty * toyPrice;
    if (total >= washingMachinePrice) 
        console.log(`Yes! ${(total - washingMachinePrice).toFixed(2)}`);
    else if (total < washingMachinePrice)
        console.log(`No! ${(washingMachinePrice - total).toFixed(2)}`);
}