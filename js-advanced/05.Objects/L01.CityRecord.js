function createRecord(name, population, treasury) {
  const record = {
    name,
    population,
    treasury,
  };

  return record;
}

console.log(createRecord('Tortuga', 7000, 15000));
console.log(createRecord('Santo Domingo', 12000, 23500));
