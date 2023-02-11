function solve() {
  class Figure {
    constructor(units = 'cm') {
      this.units = units;

      if (new.target === Figure) {
        throw new TypeError('Figure class is abstract!');
      }
    }

    changeUnits(value) {
      this.units = value;
    }

    metricConversion(num) {
      if (this.units === 'm') {
        return (num /= 10);
      }

      if (this.units === 'mm') {
        return (num *= 10);
      }

      return num;
    }

    toString() {
      return `Figures units: ${this.units}`;
    }
  }

  class Circle extends Figure {
    #radius;

    constructor(radius, units) {
      super(units);

      this.#radius = radius;
    }

    get area() {
      return Math.PI * this.radius ** 2;
    }

    get radius() {
      return super.metricConversion(this.#radius);
    }

    toString() {
      return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`;
    }
  }

  class Rectangle extends Figure {
    #width;
    #height;

    constructor(width, height, units) {
      super(units);

      this.#width = width;
      this.#height = height;
    }

    get area() {
      return this.width * this.height;
    }

    get width() {
      return super.metricConversion(this.#width);
    }

    get height() {
      return super.metricConversion(this.#height);
    }

    toString() {
      return `${super.toString()} Area: ${this.area} - width: ${
        this.width
      }, height: ${this.height}`;
    }
  }

  return {
    Figure,
    Circle,
    Rectangle,
  };
}
