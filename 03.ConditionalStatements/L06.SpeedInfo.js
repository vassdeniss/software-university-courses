function Main(input) {
    let speed = Number(input[0]);
    switch (true) {
        case (speed <= 10): console.log("slow"); break;
        case (speed > 10 && speed <= 50): console.log("average"); break;
        case (speed > 50 && speed <= 150): console.log("fast"); break;
        case (speed > 150 && speed <= 1000): console.log("ultra fast"); break;
        default: console.log("extremely fast"); break;
    }
}