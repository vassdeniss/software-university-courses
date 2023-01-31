function car(commands) {
  const commanExecutor = createHelpers();

  commands.forEach((element) => {
    const parts = element.split(' ');

    const command = parts[0];
    if (command === 'create') {
      let obj = {};

      commanExecutor.create(obj, parts[1]);

      if (parts[2] !== undefined) {
        commanExecutor.inherit(obj, parts[3]);
      }

      commanExecutor.add(obj);
    } else if (command === 'set') {
      commanExecutor.set(parts[1], parts[2], parts[3]);
    } else if (command === 'print') {
      commanExecutor.print(parts[1]);
    }
  });

  function createHelpers() {
    let carObjs = [];

    function getProperties(obj) {
      let arr = [];
      for (const key in obj) {
        if (key === 'name') {
          continue;
        }

        if (typeof obj[key] !== 'object') {
          arr.push(`${key}:${obj[key]}`);
        }
      }

      if (obj.parent !== undefined) {
        getProperties(obj.parent).forEach((element) => arr.push(element));
      }

      return arr;
    }

    return {
      create: (obj, name) => (obj.name = name),
      inherit: (obj, parent) =>
        (obj.parent = carObjs.find((car) => car.name === parent)),
      set: (name, key, value) =>
        (carObjs.find((car) => car.name === name)[key] = value),
      print: (name) =>
        console.log(
          getProperties(carObjs.find((x) => x.name == name)).join(',')
        ),
      add: (obj) => carObjs.push(obj),
    };
  }
}

car([
  'create c1',
  'create c2 inherit c1',
  'set c1 color red',
  'set c2 model new',
  'print c1',
  'print c2',
]);

car([
  'create pesho',
  'create gosho inherit pesho',
  'create stamat inherit gosho',
  'set pesho rank number1',
  'set gosho nick goshko',
  'print stamat',
]);
