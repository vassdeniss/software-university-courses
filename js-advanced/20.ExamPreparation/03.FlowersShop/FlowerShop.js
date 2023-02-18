const flowerShop = {
  calcPriceOfFlowers(flower, price, quantity) {
    if (
      typeof flower != 'string' ||
      !Number.isInteger(price) ||
      !Number.isInteger(quantity)
    ) {
      throw new Error('Invalid input!');
    } else {
      let result = price * quantity;
      return `You need $${result.toFixed(2)} to buy ${flower}!`;
    }
  },
  checkFlowersAvailable(flower, gardenArr) {
    if (gardenArr.indexOf(flower) >= 0) {
      return `The ${flower} are available!`;
    } else {
      return `The ${flower} are sold! You need to purchase more!`;
    }
  },
  sellFlowers(gardenArr, space) {
    let shop = [];
    let i = 0;
    if (
      !Array.isArray(gardenArr) ||
      !Number.isInteger(space) ||
      space < 0 ||
      space >= gardenArr.length
    ) {
      throw new Error('Invalid input!');
    } else {
      while (gardenArr.length > i) {
        if (i != space) {
          shop.push(gardenArr[i]);
        }
        i++;
      }
    }
    return shop.join(' / ');
  },
};

module.exports = {
  flowerShop,
};
