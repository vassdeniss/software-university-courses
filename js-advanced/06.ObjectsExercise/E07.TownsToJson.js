function jsonTowns(input) {
  const towns = [];
  for (let i = 1; i < input.length; i++) {
    const tokens = input[i].split(/\s*\|\s*/g);
    const town = tokens[1];
    const latitude = Number(tokens[2]).toFixed(2);
    const longitude = Number(tokens[3]).toFixed(2);

    towns.push({
      Town: town,
      Latitude: Number(latitude),
      Longitude: Number(longitude),
    });
  }

  console.log(JSON.stringify(towns));
}

jsonTowns([
  '| Town | Latitude | Longitude |',
  '| Sofia | 42.696552 | 23.32601 |',
  '| Beijing | 39.913818 | 116.363625 |',
]);

jsonTowns([
  '| Town | Latitude | Longitude |',
  '| Veliko Turnovo | 43.0757 | 25.6172 |',
  '| Monatevideo | 34.50 | 56.11 |',
]);
