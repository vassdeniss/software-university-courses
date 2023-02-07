const { expect } = require('chai');
const { mathEnforcer } = require('./E04.MathEnforcer');

describe('mathEnforcer function', function () {
  describe('addFive function', () => {
    it('returns undefined with non number arguments', () => {
      expect(mathEnforcer.addFive('string')).to.be.undefined;
    });

    it('returns undefined with no arguments', () => {
      expect(mathEnforcer.addFive()).to.be.undefined;
    });

    it('returns 10 with 5', () => {
      expect(mathEnforcer.addFive(5)).to.equal(10);
    });

    it('returns -5.99 with -10.99', () => {
      expect(mathEnforcer.addFive(-10.99)).to.equal(-5.99);
    });

    it('returns 0 with -5', () => {
      expect(mathEnforcer.addFive(-5)).to.equal(0);
    });

    it('returns close to 6.99 with 1.999 argument', () => {
      expect(mathEnforcer.addFive(1.999)).closeTo(6.999, 0.001);
    });
  });

  describe('subtractTen function', () => {
    it('returns undefined with non number argument', () => {
      expect(mathEnforcer.subtractTen('string')).to.be.undefined;
    });

    it('returns undefined with no argument', () => {
      expect(mathEnforcer.subtractTen()).to.be.undefined;
    });

    it('returns 5 with 15', () => {
      expect(mathEnforcer.subtractTen(15)).to.equal(5);
    });

    it('returns -8.9 with 1.1', () => {
      expect(mathEnforcer.subtractTen(1.1)).to.equal(-8.9);
    });

    it('returns close to -9.01 with 0.99', () => {
      expect(mathEnforcer.subtractTen(0.99)).to.be.closeTo(-9.01, 0.01);
    });

    it('returns close to -6.86 with 3.14', () => {
      expect(mathEnforcer.subtractTen(3.14)).to.be.closeTo(-6.86, 0.01);
    });

    it('returns 0 with 10', () => {
      expect(mathEnforcer.subtractTen(10)).to.equal(0);
    });

    it('returns -10 with 0', () => {
      expect(mathEnforcer.subtractTen(0)).to.equal(-10);
    });

    it('returns close to -10.99 with -0.99', () => {
      expect(mathEnforcer.subtractTen(-0.99)).to.be.closeTo(-10.99, 0.01);
    });
  });

  describe('sum function', () => {
    it('returns undefined with first non number argument', () => {
      expect(mathEnforcer.sum('string', 2)).to.be.undefined;
    });

    it('returns undefined with second non number argument', () => {
      expect(mathEnforcer.sum(2, 'string')).to.be.undefined;
    });

    it('returns undefined with both non number arguments', () => {
      expect(mathEnforcer.sum()).to.be.undefined;
    });

    it('returns 10 with 5 and 5', () => {
      expect(mathEnforcer.sum(5, 5)).to.equal(10);
    });

    it('returns -10 with -5 and -5', () => {
      expect(mathEnforcer.sum(-5, -5)).to.equal(-10);
    });

    it('returns -1.9 with -5 and 3.1', () => {
      expect(mathEnforcer.sum(-5, 3.1)).to.be.closeTo(-1.9, 0.01);
    });

    it('returns close to -1.78 with -5 and 3.22', () => {
      expect(mathEnforcer.sum(-5, 3.22)).to.be.closeTo(-1.78, 0.01);
    });

    it('returns close to 6.1 with 2.7 and 3.4', () => {
      expect(mathEnforcer.sum(2.7, 3.4)).to.be.closeTo(6.1, 0.01);
    });
  });
});
