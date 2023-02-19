const findNewApartment = {
  isGoodLocation(city, nearPublicTransportation) {
    if (
      typeof city !== 'string' ||
      typeof nearPublicTransportation !== 'boolean'
    ) {
      throw new Error('Invalid input!');
    }
    if (city !== 'Sofia' && city !== 'Plovdiv' && city !== 'Varna') {
      return 'This location is not suitable for you.';
    } else {
      if (nearPublicTransportation == true) {
        return 'You can go on home tour!';
      } else {
        return 'There is no public transport in area.';
      }
    }
  },
  isLargeEnough(apartments, minimalSquareMeters) {
    let resultArr = [];
    if (
      !Array.isArray(apartments) ||
      typeof minimalSquareMeters !== 'number' ||
      apartments.length == 0
    ) {
      throw new Error('Invalid input!');
    }
    apartments.map((apartment) => {
      if (apartment >= minimalSquareMeters) {
        resultArr.push(apartment);
      }
    });
    return resultArr.join(', ');
  },
  isItAffordable(price, budget) {
    if (
      typeof price !== 'number' ||
      typeof budget !== 'number' ||
      price <= 0 ||
      budget <= 0
    ) {
      throw new Error('Invalid input!');
    }
    let result = budget - price;
    if (result < 0) {
      return "You don't have enough money for this house!";
    } else {
      return 'You can afford this home!';
    }
  },
};

module.exports = {
  findNewApartment,
};
