function registerHero(stats) {
  return JSON.stringify(
    stats.reduce((acc, curr) => {
      const [name, level, items] = curr.split(' / ');

      acc.push({
        name,
        level: Number(level),
        items: items ? items.split(', ') : [],
      });

      return acc;
    }, [])
  );
}

console.log(
  registerHero([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara',
  ])
);

console.log(registerHero(['Jake / 1000 / Gauss, HolidayGrenade']));
