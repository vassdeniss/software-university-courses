function getPies(pieArray, pieStart, pieEnd) {
  const pieStartIndex = pieArray.indexOf(pieStart);
  const pieEndIndex = pieArray.indexOf(pieEnd);

  return pieArray.slice(pieStartIndex, pieEndIndex + 1);
}

console.log(
  getPies(
    [
      'Pumpkin Pie',
      'Key Lime Pie',
      'Cherry Pie',
      'Lemon Meringue Pie',
      'Sugar Cream Pie',
    ],
    'Key Lime Pie',
    'Lemon Meringue Pie'
  )
);

console.log(
  getPies(
    [
      'Apple Crisp',
      'Mississippi Mud Pie',
      'Pot Pie',
      'Steak and Cheese Pie',
      'Butter Chicken Pie',
      'Smoked Fish Pie',
    ],
    'Pot Pie',
    'Smoked Fish Pie'
  )
);
