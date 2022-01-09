function Main(input) {
    let budget = Number(input[0]);
    let videoCards = Number(input[1]);
    let processors = Number(input[2]);
    let ram = Number(input[3]);
    let totalVideoCards = videoCards * 250;

    let total = totalVideoCards + 
        processors * (totalVideoCards * 0.35) + 
        ram * (totalVideoCards * 0.1);
    if (videoCards > processors) total *= 0.85;
    if (budget >= total) console.log(`You have ${(budget - total).toFixed(2)} leva left!`);
    else console.log(`Not enough money! You need ${(total - budget).toFixed(2)} leva more!`);
}
