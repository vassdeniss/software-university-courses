function getFibonator() {
  let num = 1;
  let prev = 0;

  function fib() {
    let fibNum = num + prev;
    num = prev;
    prev = fibNum;
    return fibNum;
  }

  return fib;
}

let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
