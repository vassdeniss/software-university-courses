function factory(library, orders) {
  const result = [];

  for (const order of orders) {
    const current = Object.assign({}, order.template);
    for (const part of order.parts) {
      current[part] = library[part];
    }

    result.push(current);
  }

  return result;
}

const library = {
  print() {
    console.log(`${this.name} is printing a page`);
  },
  scan() {
    console.log(`${this.name} is scanning a document`);
  },
  play(artist, track) {
    console.log(`${this.name} is playing '${track}' by ${artist}`);
  },
};

const orders = [
  {
    template: { name: 'ACME Printer' },
    parts: ['print'],
  },
  {
    template: { name: 'Initech Scanner' },
    parts: ['scan'],
  },
  {
    template: { name: 'ComTron Copier' },
    parts: ['scan', 'print'],
  },
  {
    template: { name: 'BoomBox Stereo' },
    parts: ['play'],
  },
];

const products = factory(library, orders);
console.log(products);
