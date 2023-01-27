function solve() {
  const input = document.getElementById('text').value;
  const namingCase = document.getElementById('naming-convention').value;

  const result = document.getElementById('result');

  const toPascal = (text) =>
    text
      .split(' ')
      .map((w) => w[0].toUpperCase() + w.slice(1).toLowerCase())
      .join('');

  const toCamel = (text) => {
    text = toPascal(text);
    return text[0].toLowerCase() + text.slice(1);
  };

  if (namingCase === 'Pascal Case') {
    result.textContent = toPascal(input);
  } else if (namingCase === 'Camel Case') {
    result.textContent = toCamel(input);
  } else {
    result.textContent = 'Error!';
  }
}
