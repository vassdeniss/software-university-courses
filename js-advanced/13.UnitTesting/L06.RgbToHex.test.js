const { expect } = require('chai');
const { rgbToHexColor } = require('./L06.RgbToHex');

describe('rgbToHexColor function', function () {
  describe('invalid red values', () => {
    it('should return undefined with non integer red value', () => {
      expect(rgbToHexColor('red')).to.equal(undefined);
    });

    it('should return undefined with below zero red value', () => {
      expect(rgbToHexColor(-1)).to.equal(undefined);
    });

    it('should return undefined with above 255 red value', () => {
      expect(rgbToHexColor(256)).to.equal(undefined);
    });
  });

  describe('invalid green values', () => {
    it('should return undefined with non integer green value', () => {
      expect(rgbToHexColor(20, 'green')).to.equal(undefined);
    });

    it('should return undefined with below zero green value', () => {
      expect(rgbToHexColor(50, -1)).to.equal(undefined);
    });

    it('should return undefined with above 255 green value', () => {
      expect(rgbToHexColor(100, 256)).to.equal(undefined);
    });
  });

  describe('invalid blue values', () => {
    it('should return undefined with non integer blue value', () => {
      expect(rgbToHexColor(20, 20, 'blue')).to.equal(undefined);
    });

    it('should return undefined with below zero blue value', () => {
      expect(rgbToHexColor(50, 50, -1)).to.equal(undefined);
    });

    it('should return undefined with above 255 blue value', () => {
      expect(rgbToHexColor(100, 100, 256)).to.equal(undefined);
    });
  });

  it('should return correct hex for orange color', () => {
    expect(rgbToHexColor(255, 165, 0)).to.equal('#FFA500');
  });
});
