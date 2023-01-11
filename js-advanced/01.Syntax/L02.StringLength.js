function calcLength(a, b, c) {
  let lengthOne = a.length;
  let lengthTwo = b.length;
  let lengthThree = c.length;

  let total = lengthOne + lengthTwo + lengthThree;

  console.log(total);
  console.log(Math.floor(total / 3));
}

calcLength('chocolate', 'ice cream', 'cake');
calcLength('pasta', '5', '22.3');
