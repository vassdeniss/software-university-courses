const { expect } = require('chai');
const { isOddOrEven } = require('./E02.EvenOrOdd');

describe('isOddOrEven function', function () {
  it('should return undefined with non-string input', () => {
    expect(isOddOrEven(5)).to.be.undefined;
  });

  it('should return odd with odd length of input', () => {
    expect(isOddOrEven('oddString')).to.equal('odd');
  });

  it('should return even with even length of input', () => {
    expect(isOddOrEven('evenString')).to.equal('even');
  });
});
