function rgbToHexColor(red, green, blue) {
  if (!Number.isInteger(red) || red < 0 || red > 255) {
    return undefined;
  }

  if (!Number.isInteger(green) || green < 0 || green > 255) {
    return undefined;
  }

  if (!Number.isInteger(blue) || blue < 0 || blue > 255) {
    return undefined;
  }

  return (
    '#' +
    ('0' + red.toString(16).toUpperCase()).slice(-2) +
    ('0' + green.toString(16).toUpperCase()).slice(-2) +
    ('0' + blue.toString(16).toUpperCase()).slice(-2)
  );
}

module.exports = {
  rgbToHexColor,
};
