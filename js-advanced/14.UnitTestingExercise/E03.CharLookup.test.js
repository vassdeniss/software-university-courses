const { expect } = require('chai');
const { lookupChar } = require('./E03.CharLookup');

describe('lookupChar function', function () {
  let errorMessage;

  beforeEach(() => {
    errorMessage = 'Incorrect index';
  });

  it('should return undefined if first parameter is not a string', () => {
    expect(lookupChar(2, 5)).to.be.undefined;
  });

  it('should return undefined if second parameter is not an integer', () => {
    expect(lookupChar('string', 'index')).to.be.undefined;
  });

  it('should return error message if index is a negative number', () => {
    expect(lookupChar('string', -2)).to.equal(errorMessage);
  });

  it('should return error message if index is equal to strings length', () => {
    expect(lookupChar('string', 6)).to.equal(errorMessage);
  });

  it('should return error message if index is bigger than strings length', () => {
    expect(lookupChar('string', 7)).to.equal(errorMessage);
  });

  it('should return correct letter for valid index', () => {
    expect(lookupChar('string', 0)).to.equal('s');
  });

  describe('edge tests', () => {
    it('should return error message for empty string', () => {
      expect(lookupChar('', 0)).to.equal(errorMessage);
    });
  });

  describe('overload tests', () => {
    it('should return undefined if second parameter is not a number (it is a float)', () => {
      expect(lookupChar('string', 1.2)).to.be.undefined;
    });
    it('should return correct letter for valid index (2)', () => {
      expect(lookupChar('test', 0)).to.equal('t');
    });
    it('should return correct letter for valid index (3)', () => {
      expect(lookupChar('MyName', 3)).to.equal('a');
    });
  });
});
