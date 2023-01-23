function orderStore(products) {
  const catalog = products.reduce((acc, curr) => {
    const [product, price] = curr.split(' : ');

    const firstLetter = product[0];
    if (!acc.hasOwnProperty(firstLetter)) {
      acc[firstLetter] = {};
    }

    acc[firstLetter][product] = Number(price);
    return acc;
  }, {});

  Object.keys(catalog)
    .sort((a, b) => a.localeCompare(b))
    .forEach((key) => {
      console.log(key);
      Object.keys(catalog[key])
        .sort((a, b) => a.localeCompare(b))
        .forEach((product) => {
          console.log(`  ${product}: ${catalog[key][product]}`);
        });
    });
}

orderStore([
  'Appricot : 20.4',
  'Fridge : 1500',
  'TV : 1499',
  'Deodorant : 10',
  'Boiler : 300',
  'Apple : 1.25',
  'Anti-Bug Spray : 15',
  'T-Shirt : 10',
]);
