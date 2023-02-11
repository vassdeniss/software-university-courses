function createPerson(firstName, lastName) {
  const result = {
    firstName,
    lastName,
  };

  Object.defineProperty(result, 'fullName', {
    enumerable: true,
    configurable: true,
    get() {
      return `${result.firstName} ${result.lastName}`;
    },
    set(value) {
      if (!value) {
        return;
      }

      const [first, last] = value.split(' ');
      result.firstName = first;
      result.lastName = last;
    },
  });

  return result;
}

let person = createPerson('Peter', 'Ivanov');
console.log(person.fullName);
person.firstName = 'George';
console.log(person.fullName);
person.lastName = 'Peterson';
console.log(person.fullName);
person.fullName = 'Nikola Tesla';
console.log(person.firstName);
console.log(person.lastName);

let person2 = createPerson('Albert', 'Simpson');
console.log(person.fullName);
person2.firstName = 'Simon';
console.log(person.fullName);
person2.fullName = 'Peter';
console.log(person.firstName);
console.log(person.lastName);
