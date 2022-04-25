function main(args) {
    let cardInfo = {
        '2': 2, '3': 3, '4': 4, '5': 5, '6': 6, '7': 7, '8': 8, '9': 9, '10': 10,
        'J': 11, 'Q': 12, 'K': 13, 'A': 14,
        'S': 4, 'H': 3, 'D': 2, 'C': 1
    };

    let people = {};
    let personUsedCards = {};
    for (const curr of args) {
        let [name, cards] = curr.split(': ');
        
        if (!Object.hasOwnProperty.call(personUsedCards, name)) {
            personUsedCards[name] = new Set();
        }
        
        let cardsArr = cards.split(', ');
        
        let cardsPower = 0;
        for (const card of cardsArr) {
            if (!personUsedCards[name].has(card)) {
                let power = card.length == 3 ? `${card[0]}${card[1]}` : `${card[0]}`;
                let type = card.length == 3 ? `${card[2]}` : `${card[1]}`;
                cardsPower += cardInfo[power] * cardInfo[type];
                personUsedCards[name].add(card);
            }
        }

        if (!Object.hasOwnProperty.call(people, name)) {
            people[name] = 0;
        }

        people[name] += cardsPower;
    }

    for (const key in people) {
        if (Object.hasOwnProperty.call(people, key)) {
            console.log(`${key}: ${people[key]}`);
        }
    }
}
