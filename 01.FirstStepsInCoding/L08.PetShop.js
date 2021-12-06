function Main(input) {
    const dogFoodPrice = 2.50;
    const catFoodPrice = 4;

    let dogFood = Number(input[0]);
    let catFood = Number(input[1]);

    let totalDogFoodPrice = dogFood * dogFoodPrice;
    let totalCatFoodPrice = catFood * catFoodPrice;

    console.log(`${totalCatFoodPrice + totalDogFoodPrice} lv.`);
}