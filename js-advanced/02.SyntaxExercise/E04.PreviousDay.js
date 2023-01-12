function getPrevDay(year, month, day) {
  const thisDay = new Date(year, month - 1, day - 1);

  const newYear = thisDay.getFullYear();
  const newMonth = thisDay.getMonth();
  const newDate = thisDay.getDate();

  console.log(`${newYear}-${newMonth + 1}-${newDate}`);
}

getPrevDay(2016, 9, 30);
getPrevDay(2015, 5, 10);
