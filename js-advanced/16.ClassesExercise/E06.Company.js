class Company {
  #errorMessage;

  constructor() {
    this.departments = {};

    this.#errorMessage = 'Invalid input!';
  }

  addEmployee(name, salary, position, department) {
    Array.from(arguments).forEach((param) => {
      this._checkParameter(param);
    });

    if (salary < 0) {
      throw new Error(this.#errorMessage);
    }

    if (!this.departments.hasOwnProperty(department)) {
      this.departments[department] = [];
    }

    this.departments[department].push({
      name,
      salary,
      position,
    });

    return `New employee is hired. Name: ${name}. Position: ${position}`;
  }

  bestDepartment() {
    const averageDepartments = {};

    Object.keys(this.departments).forEach((key) => {
      const average =
        this.departments[key].reduce((acc, curr) => acc + curr.salary, 0) /
        this.departments[key].length;

      averageDepartments[key] = average;
    });

    const sorted = Object.entries(averageDepartments).sort(
      (a, b) => b[1] - a[1]
    );

    console.log(sorted);
    let result = `Best Department is: ${
      sorted[0][0]
    }\nAverage salary: ${sorted[0][1].toFixed(2)}`;

    this.departments[sorted[0][0]]
      .sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))
      .forEach(
        (employee) =>
          (result += `\n${employee.name} ${employee.salary} ${employee.position}`)
      );

    return result;
  }

  //! Judge doens't like private methods
  // #checkParameter
  _checkParameter(param) {
    if (param === '' || param === null || param === undefined) {
      throw new Error(this.#errorMessage);
    }
  }
}

let company = new Company();
company.addEmployee('Stanimir', 2000, 'engineer', 'Construction');
company.addEmployee('Pesho', 1500, 'electrical engineer', 'Construction');
company.addEmployee('Slavi', 500, 'dyer', 'Construction');
company.addEmployee('Stan', 2000, 'architect', 'Construction');
company.addEmployee('Stanimir', 1200, 'digital marketing manager', 'Marketing');
company.addEmployee('Pesho', 1000, 'graphical designer', 'Marketing');
company.addEmployee('Gosho', 1350, 'HR', 'Human resources');
console.log(company.bestDepartment());
