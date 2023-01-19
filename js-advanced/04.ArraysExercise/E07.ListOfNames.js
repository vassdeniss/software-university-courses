function orderNames(names) {
  console.log(
    names
      .sort((a, b) => a.localeCompare(b))
      .map((name, index) => `${++index}.${name}`)
      .join('\n')
  );
}

orderNames(['John', 'Bob', 'Christina', 'Ema']);
