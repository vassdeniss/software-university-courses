function getTotalFruitPrice(fruit, grams, pricePerKilo) {
  let fruitKilos = grams / 1000;
  let total = fruitKilos * pricePerKilo;

  console.log(
    `I need $${total.toFixed(2)} to buy ${fruitKilos.toFixed(2)} kilograms ${fruit}.`
  );
}

getTotalFruitPrice('orange', 2500, 1.8);
getTotalFruitPrice('apple', 1563, 2.35);
