function getLowestPrices(info) {
  const products = info.reduce((acc, curr) => {
    const [town, product, price] = curr.split(' | ');

    if (!acc.hasOwnProperty(product)) {
      acc[product] = {
        town,
        lowestPrice: Number(price),
      };
    } else if (Number(price) < acc[product].lowestPrice) {
      acc[product].town = town;
      acc[product].lowestPrice = Number(price);
    }

    return acc;
  }, {});

  Object.entries(products).forEach((el) => {
    console.log(`${el[0]} -> ${el[1].lowestPrice} (${el[1].town})`);
  });
}

getLowestPrices([
  'Sample Town | Sample Product | 1000',
  'Sample Town | Orange | 2',
  'Sample Town | Peach | 1',
  'Sofia | Orange | 3',
  'Sofia | Peach | 2',
  'New York | Sample Product | 1000.1',
  'New York | Burger | 10',
]);
