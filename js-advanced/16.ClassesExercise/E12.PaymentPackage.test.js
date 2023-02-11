const { expect } = require('chai');
const { PaymentPackage } = require('./E12.PaymentPackage');

describe('PaymentPackage class', function () {
  let instance;

  beforeEach(() => {
    instance = new PaymentPackage('package', 200);
  });

  it('initialises instance correctly', () => {
    expect(instance.name).to.equal('package');
    expect(instance.value).to.equal(200);
    expect(instance.VAT).to.equal(20);
    expect(instance.active).to.be.true;
  });

  describe('name tests', () => {
    it('returns corrent name on get', () => {
      expect(instance.name).to.equal('package');
    });

    it('throws error on set name with non string value', () => {
      expect(() => (instance.name = 5)).to.throw(Error);
    });

    it('throws error on set name with length equal to zero', () => {
      expect(() => (instance.name = '')).to.throw(Error);
    });

    it('returns correct name on set name', () => {
      instance.name = 'test';

      expect(instance.name).to.equal('test');
    });
  });

  describe('value tests', () => {
    it('returns corrent value on get', () => {
      expect(instance.value).to.equal(200);
    });

    it('throws error on set value with non number value', () => {
      expect(() => (instance.value = 'string')).to.throw(Error);
    });

    it('throws error on set value with below zero value', () => {
      expect(() => (instance.value = -10)).to.throw(Error);
    });

    it('returns correct value on set value', () => {
      instance.value = 1000;

      expect(instance.value).to.equal(1000);
    });

    it('returns correct value on set value (decimal)', () => {
      instance.value = 10.5;

      expect(instance.value).to.equal(10.5);
    });

    it('doesnt throw on set value (0)', () => {
      expect(() => (instance.value = 0)).does.not.throw();
    });
  });

  describe('VAT tests', () => {
    it('returns corrent VAT on get', () => {
      expect(instance.VAT).to.equal(20);
    });

    it('throws error on set VAT with non number value', () => {
      expect(() => (instance.VAT = 'string')).to.throw(Error);
    });

    it('throws error on set VAT with below zero value', () => {
      expect(() => (instance.VAT = -10)).to.throw(Error);
    });

    it('returns correct value on set VAT', () => {
      instance.VAT = 100;

      expect(instance.VAT).to.equal(100);
    });

    it('returns correct value on set VAT (decimal)', () => {
      instance.VAT = 20.5;

      expect(instance.VAT).to.equal(20.5);
    });
  });

  describe('active tests', () => {
    it('returns corrent active on get', () => {
      expect(instance.active).to.be.true;
    });

    it('throws error on set active with non boolean value (string)', () => {
      expect(() => (instance.active = 'string')).to.throw(Error);
    });

    it('throws error on set active with non boolean value (number)', () => {
      expect(() => (instance.active = 200)).to.throw(Error);
    });

    it('throws error on set active with null value', () => {
      expect(() => (instance.active = null)).to.throw(Error);
    });

    it('returns correct active on set active', () => {
      instance.active = false;

      expect(instance.active).to.be.false;
    });
  });

  it('returns correct toString', () => {
    expect(instance.toString()).to.equal(
      'Package: package\n- Value (excl. VAT): 200\n- Value (VAT 20%): 240'
    );
  });

  it('returns correct toString with (inactive)', () => {
    instance.active = false;
    expect(instance.toString()).to.equal(
      'Package: package (inactive)\n- Value (excl. VAT): 200\n- Value (VAT 20%): 240'
    );
  });
});
