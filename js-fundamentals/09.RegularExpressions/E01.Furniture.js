function main(args) {
    let total = 0;
    let furniture = [];

    for (const line of args) {
        if (line === 'Purchase') break;
        
        let regex = />>(?<item>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<qty>\d+)/;
        let match = regex.exec(line);
        if (match) {
            let item = match.groups.item;
            let price = parseFloat(match.groups.price);
            let qty = parseInt(match.groups.qty);

            furniture.push(item);
            total += price * qty;
        }
    }

    console.log('Bought furniture:');
    furniture.forEach(x => console.log(x));
    console.log(`Total money spend: ${total.toFixed(2)}`);
}
