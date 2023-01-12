function isSame(num) {
  let numAsString = String(num);
  let first = numAsString[0];

  let sum = 0;
  let isSame = true;
  for (let i = 0; i < numAsString.length; i++) {
    if (numAsString[i] !== first) {
      isSame = false;
    }

    sum += Number(numAsString[i]);
  }

  console.log(isSame);
  console.log(sum);
}

isSame(2222222);
isSame(1234);
