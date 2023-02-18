const { expect } = require('chai');
const { flowerShop } = require('./FlowerShop');

describe('flowerShop object', function () {
  describe('calcPriceOfFlowers method', () => {
    it('throws error when first param is not a string', () => {
      expect(() => flowerShop.calcPriceOfFlowers(2, 2, 2)).to.throw(Error);
    });

    it('throws error when second param is not an integer (string)', () => {
      expect(() => flowerShop.calcPriceOfFlowers('test', 'test', 2)).to.throw(
        Error
      );
    });

    it('throws error when second param is not an integer (double)', () => {
      expect(() => flowerShop.calcPriceOfFlowers('test', 2.5, 2)).to.throw(
        Error
      );
    });

    it('throws error when third param is not an integer (string)', () => {
      expect(() => flowerShop.calcPriceOfFlowers('test', 2, 'test')).to.throw(
        Error
      );
    });

    it('throws error when third param is not an integer (double)', () => {
      expect(() => flowerShop.calcPriceOfFlowers('test', 2, 2.5)).to.throw(
        Error
      );
    });

    it('returns correct string with valid params', () => {
      const expected = 'You need $50.00 to buy orange tulip!';

      expect(flowerShop.calcPriceOfFlowers('orange tulip', 25, 2)).to.equal(
        expected
      );
    });
  });

  describe('checkFlowersAvailable method', () => {
    it('returns correct string when flower is available', () => {
      const expected = 'The red tulips are available!';

      expect(
        flowerShop.checkFlowersAvailable('red tulips', ['red tulips'])
      ).to.equal(expected);
    });

    it('returns correct string when flower is not available', () => {
      const expected = 'The red tulips are sold! You need to purchase more!';

      expect(
        flowerShop.checkFlowersAvailable('red tulips', ['orange tulips'])
      ).to.equal(expected);
    });
  });

  describe('sellFlowers method', () => {
    it('throws error when first param is not an array', () => {
      expect(() => flowerShop.sellFlowers(2, 10)).to.throw(Error);
    });

    it('throws error when second param is not an integer (string)', () => {
      expect(() => flowerShop.sellFlowers([], '')).to.throw(Error);
    });

    it('throws error when second param is not an integer (double)', () => {
      expect(() => flowerShop.sellFlowers([], 2.5)).to.throw(Error);
    });

    it('throws error when second param is a negative number', () => {
      expect(() => flowerShop.sellFlowers([], -2)).to.throw(Error);
    });

    it('throws error when second param is bigger than the array', () => {
      expect(() => flowerShop.sellFlowers(['item'], 2)).to.throw(Error);
    });

    it('returns correct string with valid params', () => {
      const expected = 'item1 / item2 / item4 / item5';

      expect(
        flowerShop.sellFlowers(['item1', 'item2', 'item3', 'item4', 'item5'], 2)
      ).to.equal(expected);
    });
  });
});
