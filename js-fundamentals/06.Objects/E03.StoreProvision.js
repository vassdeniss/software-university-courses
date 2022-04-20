function main(stock, ordered) {
    let products = {};
    for (let i = 0; i < stock.length; i += 2) {
        products[stock[i]] = Number(stock[i + 1]);
    }

    for (let i = 0; i < ordered.length; i += 2) {
        if (products.hasOwnProperty(ordered[i])) {
            products[ordered[i]] += Number(ordered[i + 1]);
        } else {
            products[ordered[i]] = Number(ordered[i + 1]);
        }
    }

    for (const [key, value] of Object.entries(products)) {
        console.log(`${key} -> ${value}`);
    }
}
