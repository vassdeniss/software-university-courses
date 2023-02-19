const { expect } = require('chai');
const { findNewApartment } = require('./FindApartment');

describe('findNewApartment object', function () {
  describe('isGoodLocation function', () => {
    it('throws if first param is not a string', () => {
      expect(() => findNewApartment.isGoodLocation(2, true)).to.throw(Error);
    });

    it('throws if second param is not a boolean', () => {
      expect(() => findNewApartment.isGoodLocation('teste', 2)).to.throw(Error);
    });

    it('returns correct string if locations are not Sofia, Plovdiv, Varna', () => {
      const expected = 'This location is not suitable for you.';

      expect(findNewApartment.isGoodLocation('Blagoevgrad', false)).to.equal(
        expected
      );
    });

    it('returns correct string if locations are Sofia, Plovdiv, Varna (Sofia, transport)', () => {
      const expected = 'You can go on home tour!';

      expect(findNewApartment.isGoodLocation('Sofia', true)).to.equal(expected);
    });

    it('returns correct string if locations are Sofia, Plovdiv, Varna (Plovdiv, transport)', () => {
      const expected = 'You can go on home tour!';

      expect(findNewApartment.isGoodLocation('Plovdiv', true)).to.equal(
        expected
      );
    });

    it('returns correct string if locations are Sofia, Plovdiv, Varna (Varna, transport)', () => {
      const expected = 'You can go on home tour!';

      expect(findNewApartment.isGoodLocation('Varna', true)).to.equal(expected);
    });

    it('returns correct string if locations are Sofia, Plovdiv, Varna (Sofia, no transport)', () => {
      const expected = 'There is no public transport in area.';

      expect(findNewApartment.isGoodLocation('Sofia', false)).to.equal(
        expected
      );
    });

    it('returns correct string if locations are Sofia, Plovdiv, Varna (Plovdiv, no transport)', () => {
      const expected = 'There is no public transport in area.';

      expect(findNewApartment.isGoodLocation('Plovdiv', false)).to.equal(
        expected
      );
    });

    it('returns correct string if locations are Sofia, Plovdiv, Varna (Varna, no transport)', () => {
      const expected = 'There is no public transport in area.';

      expect(findNewApartment.isGoodLocation('Varna', false)).to.equal(
        expected
      );
    });
  });

  describe('isLargeEnough function', () => {
    it('throws if first param is not an array', () => {
      expect(() => findNewApartment.isLargeEnough('string', 2)).to.throw(Error);
    });

    it('throws if second param is not a number', () => {
      expect(() => findNewApartment.isLargeEnough([200], 'test')).to.throw(
        Error
      );
    });

    it('throws if first array param is empty', () => {
      expect(() => findNewApartment.isLargeEnough([], 2)).to.throw(Error);
    });

    it('returns correct string with valid params', () => {
      const expected = '200, 500, 700, 1000';

      expect(
        findNewApartment.isLargeEnough([200, 500, 700, 1000, 20, 30], 200)
      ).to.equal(expected);
    });
  });

  describe('isItAffordable function', () => {
    it('throws if first param is not a number', () => {
      expect(() => findNewApartment.isItAffordable('string', 2)).to.throw(
        Error
      );
    });

    it('throws if second param is not a number', () => {
      expect(() => findNewApartment.isItAffordable(2, 'test')).to.throw(Error);
    });

    it('throws if first param is lower than 1', () => {
      expect(() => findNewApartment.isItAffordable(0, 2)).to.throw(Error);
    });

    it('throws if second param is lower than 1', () => {
      expect(() => findNewApartment.isItAffordable(2, 0)).to.throw(Error);
    });

    it('returns correct string with not enough budget', () => {
      const expected = "You don't have enough money for this house!";

      expect(findNewApartment.isItAffordable(200, 100)).to.equal(expected);
    });

    it('returns correct string with enough budget', () => {
      const expected = 'You can afford this home!';

      expect(findNewApartment.isItAffordable(100, 200)).to.equal(expected);
    });
  });
});
