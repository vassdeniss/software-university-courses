function squareOfStars(size = 5) {
  for (let row = 0; row < size; row++) {
    console.log('* '.repeat(size));
  }
}

squareOfStars(1);
squareOfStars(2);
squareOfStars(5);
squareOfStars(7);
