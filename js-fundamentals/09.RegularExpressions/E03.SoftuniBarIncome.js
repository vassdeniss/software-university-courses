function main(args) {
    let total = 0;
        
    args.forEach((line) => {
        const regex = /%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<qty>[0-9]+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]*)\$/gm;
        const match = regex.exec(line);
        if (match) {
            const name = match.groups.name;
            const product = match.groups.product;
            const price = parseFloat(match.groups.price) * parseInt(match.groups.qty);
            total += price;
            console.log(`${name}: ${product} - ${price.toFixed(2)}`);
        }
    });

    console.log(`Total income: ${total.toFixed(2)}`);
}
