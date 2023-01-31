function solution(input) {
  let num = input;

  return (add) => {
    return num + add;
  };
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));
