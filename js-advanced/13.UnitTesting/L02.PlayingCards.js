function getCard(face, suit) {
  const faces = [
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '10',
    'J',
    'Q',
    'K',
    'A',
  ];
  const suits = {
    S: '\u2660',
    H: '\u2665',
    D: '\u2666',
    C: '\u2663',
  };

  if (!faces.includes(face)) {
    throw new Error(`Invalid face '${face}'!`);
  }

  if (!suits.hasOwnProperty(suit)) {
    throw new Error(`Invalid suit '${suit}'!`);
  }

  return {
    face,
    suit,
    toString() {
      return this.face + suits[this.suit];
    },
  };
}

const cards = [getCard('A', 'S'), getCard('10', 'H')];
console.log(cards.join('\n'));
