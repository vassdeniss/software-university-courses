function createFormatter(seperator, symbol, symbolFirst, formatter) {
  return (value) => formatter(seperator, symbol, symbolFirst, value);
}

function currencyFormatter(separator, symbol, symbolFirst, value) {
  const result = Math.trunc(value) + separator + value.toFixed(2).substr(-2, 2);
  return symbolFirst ? `${symbol} ${result}` : `${result} ${symbol}`;
}

const dollarFormatter = createFormatter(',', '$', true, currencyFormatter);
console.log(dollarFormatter(5345));
console.log(dollarFormatter(3.1429));
console.log(dollarFormatter(2.709));
