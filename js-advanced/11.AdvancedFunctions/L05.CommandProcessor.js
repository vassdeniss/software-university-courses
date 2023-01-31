function solution() {
  let str = '';

  return {
    append: (s) => (str += s),
    removeStart: (n) => (str = str.substring(n)),
    removeEnd: (n) => (str = str.substring(0, str.length - n)),
    print: () => console.log(str),
  };
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();

let secondZeroTest = solution();
secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();
