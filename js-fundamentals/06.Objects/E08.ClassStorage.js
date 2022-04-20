class Storage {
    constructor(capacity) {
        this.capacity = capacity;
        this.storage = [];
    }

    get totalCost() {
        return this.storage.reduce((x, y) => {
            return x + y.price * y.quantity;
        }, 0);
    }

    addProduct(product) {
        this.storage.push(product);
        this.capacity -= product.quantity;
        return;
    }

    getProducts() {
        let result = [];
        this.storage.forEach(x => {
            result.push(JSON.stringify(x));
        });
        return result.join('\n');
    }
}
