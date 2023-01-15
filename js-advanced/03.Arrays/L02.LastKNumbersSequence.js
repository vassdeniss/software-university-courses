function getSequence(n, k) {
  let result = [1];

  for (let i = 1; i < n; i++) {
    result[i] = getLastK(result, k);
  }

  function getLastK(arr, k) {
    k = arr.length > k 
      ? k 
      : arr.length;

    let sum = 0;
    for (let i = 1; i <= k; i++) {
      sum += arr[arr.length - i];
    }

    return sum;
  }

  return result;
}

console.log(getSequence(6, 3));
console.log(getSequence(8, 2));
