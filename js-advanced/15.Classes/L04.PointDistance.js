class Point {
  constructor(x, y) {
    this.x = x;
    this.y = y;
  }

  static distance(a, b) {
    const x = b.x - a.x;
    const y = b.y - a.y;

    const distance = Math.sqrt(x ** 2 + y ** 2);

    return distance;
  }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
