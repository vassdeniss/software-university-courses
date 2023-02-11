function getBrands(input) {
  const brands = new Map();

  for (const line of input) {
    const [brand, model, produced] = line.split(' | ');
    if (!brands.has(brand)) {
      brands.set(brand, new Map());
    }

    if (!brands.get(brand).has(model)) {
      brands.get(brand).set(model, 0);
    }

    brands
      .get(brand)
      .set(model, brands.get(brand).get(model) + Number(produced));
  }

  let result = '';
  for (const brand of brands) {
    result += `${brand[0]}\n`;
    for (const model of brand[1]) {
      result += `###${model[0]} -> ${model[1]}\n`;
    }
  }

  return result;
}

console.log(
  getBrands([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10',
  ])
);
