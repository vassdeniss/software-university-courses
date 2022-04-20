function main(args) {
    let catalogue = [];
    for (let i = 0; i < args.length; i++) {
        let [name, price] = args[i].split(' : ');
        let product = {
            name: name,
            price: parseFloat(price) 
        };
        catalogue.push(product);
    }

    catalogue.sort((a, b) => a.name.localeCompare(b.name));

    let currLetter = '';
    for (const product of catalogue) {
        if (product.name.charAt(0).toUpperCase() == currLetter) {
            console.log(`  ${product.name}: ${product.price}`);
        } else {
            currLetter = product.name.charAt(0).toUpperCase();
            console.log(currLetter);
            console.log(`  ${product.name}: ${product.price}`);
        }
    }
}
