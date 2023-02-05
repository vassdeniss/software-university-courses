const { expect } = require('chai');
const { sum } = require('./L04.SumOfNumbers');

describe('function sum', function () {
  it('should sum correctly with an array of numbers', () => {
    const nums = [1, 2, 3, 4, 5];

    const expected = nums.reduce((acc, curr) => acc + curr, 0);
    const actual = sum(nums);

    expect(actual).to.equal(expected);
  });
});
