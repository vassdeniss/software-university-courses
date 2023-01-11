function getArea(param) {
  let type = typeof param;
  if (type === 'number') {
    let result = Math.pow(param, 2) * Math.PI;
    console.log(result.toFixed(2));
  } else {
    console.log(
      `We can not calculate the circle area, because we receive a ${type}.`
    );
  }
}

getArea(5);
getArea('name');
