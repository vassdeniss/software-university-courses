const { expect } = require('chai');
const { createCalculator } = require('./L07.AddSubtract');

describe('createCalculator function', function () {
  let calculator;

  beforeEach(() => {
    calculator = createCalculator();
  });

  it('should return 0 on get', () => {
    expect(calculator.get()).to.equal(0);
  });

  describe('with whole numbers', () => {
    it('should return 5 after adding 2 and 3', () => {
      calculator.add(2);
      calculator.add(3);

      const expected = 5;
      const actual = calculator.get();

      expect(actual).to.equal(expected);
    });

    it('should return -8 after subtracting 3 and 5', () => {
      calculator.subtract(3);
      calculator.subtract(5);

      const expected = -8;
      const actual = calculator.get();

      expect(actual).to.equal(expected);
    });
  });

  describe('with real numbers', () => {
    it('should return 3.2 after adding 4 and subtracting 0.8', () => {
      calculator.add(4);
      calculator.subtract(0.8);

      const expected = 3.2;
      const actual = calculator.get();

      expect(actual).to.equal(expected);
    });

    it('should return -2.3 after subtracting 3 and adding 0.7', () => {
      calculator.subtract(3);
      calculator.add(0.7);

      const expected = -2.3;
      const actual = calculator.get();

      expect(actual).to.equal(expected);
    });
  });

  describe('with invalid input', () => {
    it('should return NaN for string addition', () => {
      calculator.add('string');

      expect(calculator.get()).to.be.NaN;
    });

    it('should return NaN for string subtraction', () => {
      calculator.subtract('string');

      expect(calculator.get()).to.be.NaN;
    });
  });
});
