function solution() {
  const recipes = {
    apple: {
      carbohydrate: 1,
      flavour: 2,
    },
    lemonade: {
      carbohydrate: 10,
      flavour: 20,
    },
    burger: {
      carbohydrate: 5,
      fat: 7,
      flavour: 3,
    },
    eggs: {
      protein: 5,
      fat: 1,
      flavour: 1,
    },
    turkey: {
      protein: 10,
      carbohydrate: 10,
      fat: 10,
      flavour: 10,
    },
  };

  const ingredients = {
    protein: 0,
    carbohydrate: 0,
    fat: 0,
    flavour: 0,
  };

  function manager(instructions) {
    let [command, ingridient, amount] = instructions.split(' ');
    amount = Number(amount);

    if (command === 'restock') {
      ingredients[ingridient] += amount;
      return 'Success';
    } else if (command === 'prepare') {
      const recipe = recipes[ingridient];

      for (const key in recipe) {
        if (recipe[key] * amount > ingredients[key]) {
          return `Error: not enough ${key} in stock`;
        }
      }

      if (cookFood(recipe, amount)) {
        return 'Success';
      }
    } else if (command === 'report') {
      const result = [];
      for (const key in ingredients) {
        result.push(`${key}=${ingredients[key]}`);
      }

      return result.join(' ');
    }

    // Cool func, can't use with judge
    // function ensureEnoughIngredients(recipe, amount) {
    //   for (const key in recipe) {
    //     if (recipe[key] * amount > ingredients[key]) {
    //       return `Error: not enough ${key} in stock`;
    //     }
    //   }
    // }

    function cookFood(recipe, amount) {
      for (const key in recipe) {
        ingredients[key] -= recipe[key] * amount;
      }

      return true;
    }
  }

  return manager;
}

let manager = solution();
console.log(manager('restock flavour 50'));
console.log(manager('prepare lemonade 4'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));

let manager2 = solution();
console.log(manager2('prepare turkey 1'));
console.log(manager2('restock protein 10'));
console.log(manager2('prepare turkey 1'));
console.log(manager2('restock carbohydrate 10'));
console.log(manager2('prepare turkey 1'));
console.log(manager2('restock fat 10'));
console.log(manager2('prepare turkey 1'));
console.log(manager2('restock flavour 10'));
console.log(manager2('prepare turkey 1'));
console.log(manager2('report'));
