const { expect } = require('chai');
const { rentCar } = require('./RentCar');

describe('rentCar object', function () {
  describe('searchCar function', () => {
    it('throws error when first param is not an array', () => {
      expect(() => rentCar.searchCar('', 'a')).to.throw(Error);
    });

    it('throws error when second param is not a string', () => {
      expect(() => rentCar.searchCar([], 2)).to.throw(Error);
    });

    it('throws error when such model doesnt exist', () => {
      expect(() => rentCar.searchCar(['model1'], 'model2')).to.throw(Error);
    });

    it('returns correct string when model is found', () => {
      expect(
        rentCar.searchCar(['model1', 'model1', 'model1'], 'model1')
      ).to.equal('There is 3 car of model model1 in the catalog!');
    });
  });

  describe('calculatePriceOfCar function', () => {
    it('throws error when first param is not a string', () => {
      expect(() => rentCar.calculatePriceOfCar(2, '')).to.throw(Error);
    });

    it('throws error when second param is not an integer', () => {
      expect(() => rentCar.calculatePriceOfCar('a', 'a')).to.throw(Error);
    });

    it('throws error when second param is not an integer (its double)', () => {
      expect(() => rentCar.calculatePriceOfCar('a', 2.2)).to.throw(Error);
    });

    it('throws error when such model doesnt exist', () => {
      expect(() => rentCar.calculatePriceOfCar('doest exist', 2)).to.throw(
        Error
      );
    });

    it('returns correct string when model is found', () => {
      expect(rentCar.calculatePriceOfCar('Toyota', 7)).to.equal(
        'You choose Toyota and it will cost $280!'
      );
    });
  });

  describe('checkBudget function', () => {
    it('throws error when first param is not an integer', () => {
      expect(() => rentCar.checkBudget('', 2, 2)).to.throw(Error);
    });

    it('throws error when first param is not an integer (its double)', () => {
      expect(() => rentCar.checkBudget(2.2, 2, 2)).to.throw(Error);
    });

    it('throws error when second param is not an integer', () => {
      expect(() => rentCar.checkBudget(2, '', 2)).to.throw(Error);
    });

    it('throws error when second param is not an integer (its double)', () => {
      expect(() => rentCar.checkBudget(2, 2.2, 2)).to.throw(Error);
    });

    it('throws error when third param is not an integer', () => {
      expect(() => rentCar.checkBudget(2, 2, '')).to.throw(Error);
    });

    it('throws error when third param is not an integer (its double)', () => {
      expect(() => rentCar.checkBudget(2, 2, 2.2)).to.throw(Error);
    });

    it('returns correct string when budget is low', () => {
      expect(rentCar.checkBudget(30, 5, 100)).to.equal(
        'You need a bigger budget!'
      );
    });

    it('returns correct string when budget is enough (edge)', () => {
      expect(rentCar.checkBudget(20, 5, 100)).to.equal('You rent a car!');
    });

    it('returns correct string when budget is enough', () => {
      expect(rentCar.checkBudget(20, 5, 300)).to.equal('You rent a car!');
    });
  });
});
