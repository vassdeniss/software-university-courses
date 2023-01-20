function createRegistry(info) {
  let towns = {};

  for (let i = 0; i < info.length; i++) {
    const curr = info[i].split(' <-> ');

    const town = curr[0];
    const population = Number(curr[1]);

    if (!towns.hasOwnProperty(town)) {
      towns[town] = 0;
    }

    towns[town] += population;
  }

  for (const [town, population] of Object.entries(towns)) {
    console.log(`${town} : ${population}`);
  }
}

createRegistry([
  'Sofia <-> 1200000',
  'Montana <-> 20000',
  'New York <-> 10000000',
  'Washington <-> 2345000',
  'Las Vegas <-> 1000000',
]);

createRegistry([
  'Istanbul <-> 100000',
  'Honk Kong <-> 2100004',
  'Jerusalem <-> 2352344',
  'Mexico City <-> 23401925',
  'Istanbul <-> 1000',
]);
