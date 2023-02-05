const { expect } = require('chai');
const { isSymmetric } = require('./L05.CheckForSymmetry');

describe('isSymmetric function', function () {
  it('should return false with string input', () => {
    expect(isSymmetric('string')).to.be.false;
  });

  it('should return false with number input', () => {
    expect(isSymmetric(2)).to.be.false;
  });

  it('should return false with object input', () => {
    expect(isSymmetric({})).to.be.false;
  });

  it('should return false with non symmetric input [1, 2, 3]', () => {
    const arr = [1, 2, 3];
    expect(isSymmetric(arr)).to.be.false;
  });

  it('should return true with symmetric input [2, 2, 2]', () => {
    const arr = [2, 2, 2];
    expect(isSymmetric(arr)).to.be.true;
  });

  describe('edge cases tests', () => {
    it('should return false with ["2",2]', () => {
      expect(isSymmetric(['2', 2])).to.be.false;
    });

    it('should return true with [1]', () => {
      expect(isSymmetric([1])).to.be.true;
    });

    it('should return true with []', () => {
      expect(isSymmetric([])).to.be.true;
    });

    it('should return true with [[1,2], [2], [1,2]]', () => {
      expect(isSymmetric([[1, 2], [2], [1, 2]])).to.be.true;
    });
  });
});
