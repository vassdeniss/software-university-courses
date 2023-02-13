class CarDealership {
  constructor(name) {
    this.name = name;
    this.avaliableCars = [];
    this.soldCars = [];
    this.totalIncome = 0;
  }

  addCar(model, horsepower, price, mileage) {
    if (
      !model ||
      !Number.isInteger(horsepower) ||
      horsepower < 0 ||
      price < 0 ||
      mileage < 0
    ) {
      throw new Error('Invalid input!');
    }

    this.avaliableCars.push({
      model,
      horsepower,
      price,
      mileage,
    });

    return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(
      2
    )} km - ${price.toFixed(2)}$`;
  }

  sellCar(model, desiredMileage) {
    const car = this.avaliableCars.find((c) => c.model === model);

    if (!car) {
      throw new Error(`${model} was not found!`);
    }

    let soldPrice = 0;

    const diff = car.mileage - desiredMileage;
    if (diff <= 0) {
      soldPrice = car.price;
    } else if (diff <= 40000) {
      soldPrice = car.price - car.price * 0.05;
    } else {
      soldPrice = car.price - car.price * 0.1;
    }

    this.avaliableCars.splice(this.avaliableCars.indexOf(car), 1);
    this.soldCars.push({
      model: car.model,
      horsepower: car.horsepower,
      soldPrice,
    });

    this.totalIncome += soldPrice;

    return `${car.model} was sold for ${soldPrice.toFixed(2)}$`;
  }

  currentCar() {
    if (this.avaliableCars.length <= 0) {
      return 'There are no available cars';
    }

    let result = '-Available cars:';

    for (const car of this.avaliableCars) {
      result += `\n---${car.model} - ${
        car.horsepower
      } HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$`;
    }

    return result;
  }

  salesReport(criteria) {
    if (criteria !== 'horsepower' && criteria !== 'model') {
      throw new Error('Invalid criteria!');
    }

    let result = `-${
      this.name
    } has a total income of ${this.totalIncome.toFixed(2)}$\n-${
      this.soldCars.length
    } cars sold:`;

    if (criteria === 'horsepower') {
      this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
    } else if (criteria === 'model') {
      this.soldCars.sort((a, b) => a.model.localeCompare(b.model));
    }

    for (const car of this.soldCars) {
      result += `\n---${car.model} - ${
        car.horsepower
      } HP - ${car.soldPrice.toFixed(2)}$`;
    }

    return result;
  }
}
