function solve() {
  document.querySelector('#btnSend').addEventListener('click', onClick);

  const text = document.querySelector('#inputs>textarea');

  const bestRestaurantText = document.querySelector('#bestRestaurant>p');
  const workersText = document.querySelector('#outputs #workers p');

  function onClick() {
    const arr = JSON.parse(text.value);

    let restaurants = {};
    arr.forEach((item) => {
      const split = item.split(' - ');
      const restaurant = split[0];

      let workers = [];
      split[1].split(', ').forEach((worker) => {
        const tokens = worker.split(' ');
        const name = tokens[0];
        const salary = Number(tokens[1]);

        workers.push({
          name,
          salary,
        });
      });

      if (restaurants[restaurant]) {
        workers = workers.concat(restaurants[restaurant].workers);
      }

      workers.sort((a, b) => b.salary - a.salary);

      const bestSalary = workers[0].salary;
      const averageSalary =
        workers.reduce((acc, curr) => acc + curr.salary, 0) / workers.length;

      restaurants[restaurant] = {
        workers,
        averageSalary,
        bestSalary,
      };
    });

    let bestSalary = 0;
    let bestRestaurant = undefined;

    for (const name in restaurants) {
      if (restaurants[name].averageSalary > bestSalary) {
        bestSalary = restaurants[name].averageSalary;
        bestRestaurant = { name, ...restaurants[name] };
      }
    }

    bestRestaurantText.textContent = `Name: ${
      bestRestaurant.name
    } Average Salary: ${bestRestaurant.averageSalary.toFixed(
      2
    )} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

    let workersResult = [];
    bestRestaurant.workers.forEach((worker) =>
      workersResult.push(`Name: ${worker.name} With Salary: ${worker.salary}`)
    );

    workersText.textContent = workersResult.join(' ');
  }
}
