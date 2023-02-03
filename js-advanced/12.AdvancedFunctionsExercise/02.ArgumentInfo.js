function countArgs() {
  const map = new Map();

  Array.from(arguments).forEach((arg) => {
    const type = typeof arg;

    if (!map.has(type)) {
      map.set(type, 0);
    }

    map.set(type, map.get(type) + 1);
    console.log(`${type}: ${arg}`);
  });

  Array.from(map.entries())
    .sort((a, b) => b[1] - a[1])
    .forEach((el) => console.log(`${el[0]} = ${el[1]}`));
}

countArgs('cat', 42, function () {
  console.log('Hello world!');
});
