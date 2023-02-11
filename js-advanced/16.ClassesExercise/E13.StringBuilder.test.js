const { expect } = require('chai');
const { StringBuilder } = require('./E13.StringBuilder');

describe('StringBuilder class', function () {
  it('throws type error on non string type', () => {
    expect(() => new StringBuilder(5)).to.throw(TypeError);
  });

  it('returns correct toString with string input', () => {
    const test = new StringBuilder('test');

    expect(test.toString()).to.equal('test');
  });

  it('returns empty string for undefined type', () => {
    const test = new StringBuilder(undefined);

    expect(test.toString()).to.equal('');
  });

  it('throws type error on non string type for append', () => {
    const test = new StringBuilder('test');

    expect(() => test.append(5)).to.throw(TypeError);
  });

  it('returns correct string when appending', () => {
    const test = new StringBuilder('test');
    test.append('2');

    expect(test.toString()).to.equal('test2');
  });

  it('throws type error on non string type for prepend', () => {
    const test = new StringBuilder('test');

    expect(() => test.prepend(5)).to.throw(TypeError);
  });

  it('returns correct string when prepending', () => {
    const test = new StringBuilder('test');
    test.prepend('2');

    expect(test.toString()).to.equal('2test');
  });

  it('throws type error on non string type for insertAt', () => {
    const test = new StringBuilder('test');

    expect(() => test.insertAt(5)).to.throw(TypeError);
  });

  it('returns correct string when inserting at index', () => {
    const test = new StringBuilder('test');
    test.insertAt('2', 1);

    expect(test.toString()).to.equal('t2est');
  });

  it('returns correct string when deleting at index', () => {
    const test = new StringBuilder('test');
    test.remove(0, 2);

    expect(test.toString()).to.equal('st');
  });

  it('works correctly with toString', () => {
    const expected = '\n A \n\r B\t123   ';
    const obj = new StringBuilder();

    expected.split('').forEach((s) => {
      obj.append(s);
      obj.prepend(s);
    });

    obj.insertAt('test', 4);

    obj.remove(2, 4);

    expect(obj.toString()).to.equal('  st21\tB \r\n A \n\n A \n\r B\t123   ');
  });
});
