function createCalorie(foods) {
  return foods.reduce((acc, curr, index) => {
    if (index % 2 === 0) {
      acc[curr] = Number(foods[index + 1]);
    }

    return acc;
  }, {});
}

console.log(createCalorie(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(
  createCalorie(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42'])
);
