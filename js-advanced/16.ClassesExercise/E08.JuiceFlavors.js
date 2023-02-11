function makeBottles(input) {
  const juices = new Map();
  const bottles = new Map();

  for (const line of input) {
    const [juice, quantity] = line.split(' => ');

    if (!juices.has(juice)) {
      juices.set(juice, 0);
    }

    juices.set(juice, juices.get(juice) + Number(quantity));
    if (juices.get(juice) >= 1000) {
      if (!bottles.has(juice)) {
        bottles.set(juice, 0);
      }

      while (juices.get(juice) >= 1000) {
        bottles.set(juice, bottles.get(juice) + 1);
        juices.set(juice, juices.get(juice) - 1000);
      }
    }
  }

  for (const bottle of bottles) {
    console.log(`${bottle[0]} => ${bottle[1]}`);
  }
}

makeBottles([
  'Orange => 2000',
  'Peach => 1432',
  'Banana => 450',
  'Peach => 600',
  'Strawberry => 549',
]);

makeBottles([
  'Kiwi => 234',
  'Pear => 2345',
  'Watermelon => 3456',
  'Kiwi => 4567',
  'Pear => 5678',
  'Watermelon => 6789',
]);
