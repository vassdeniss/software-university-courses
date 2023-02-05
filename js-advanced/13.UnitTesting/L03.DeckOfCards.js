function printDeck(cards) {
  const madeCards = [];
  for (const card of cards) {
    try {
      const face = card.slice(0, card.length - 1);
      const suit = card.slice(card.length - 1);
      madeCards.push(makeCard(face, suit).toString());
    } catch (err) {
      console.log(`Invalid card: ${card}`);
    }
  }

  console.log(madeCards.join(' '));

  function makeCard(face, suit) {
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
}

printDeck(['AS', '10D', 'KH', '2C']);
printDeck(['5S', '3D', 'QD', '1C']);
